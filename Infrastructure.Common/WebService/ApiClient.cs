using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Infrastructure.Common.Utils;
using Newtonsoft.Json;

namespace Infrastructure.Common.WebService
{
    /// <summary>
    /// Sends requests to web services.
    /// </summary>
    public class ApiClient
    {
        public string ApiUrl { get; set; }
        public string ApiVersion { get; set; }
        public string EntityName { get; set; }
        public HttpContentType ContentType { get; set; } = HttpContentType.Json;

        public ApiClient(string apiUrl = null, string apiVersion = null, string entityName = null)
        {
            ApiUrl = apiUrl;
            ApiVersion = apiVersion;
            EntityName = entityName;
        }
        
        #region MakeRequest
        public TResponse MakeRequest<TResponse>(HttpMethod method) => 
	        BaseMakeRequest<object, TResponse>(method);

	    public TResponse MakeRequest<TDto, TResponse>(HttpMethod method, TDto dto) => 
		    BaseMakeRequest<TDto, TResponse>(method, action: null, id: null, parameters: null, dto: dto);

	    public TResponse MakeRequest<TDto, TResponse>(HttpMethod method, long id, TDto dto) => 
		    BaseMakeRequest<TDto, TResponse>(method, action: null, id: id, parameters: null, dto: dto);

	    public TResponse MakeRequest<TResponse>(HttpMethod method, string action, UrlParams parameters) => 
		    BaseMakeRequest<object, TResponse>(method, action, id: null, parameters: parameters);
	    #endregion

        private TResponse BaseMakeRequest<TDto, TResponse>(HttpMethod method, string action = null, long? id = null, UrlParams parameters = null, TDto dto = default)
        {
            var requestUri = GetUri(id, action, parameters);
            var responseBytes = SendRequest(requestUri, method, dto);
            try
            {
                return DeserializeResponse<TResponse>(responseBytes);
            }
            catch (WebException ex) when (ex.Status == WebExceptionStatus.ProtocolError)
            {
	            // If Bad Request returns JSON with the error message
				throw new InvalidOperationException(DeserializeResponse<dynamic>(responseBytes), ex);
            }
        }

        private byte[] SendRequest<TDto>(Uri uri, HttpMethod method, TDto dto = default)
        {
            var request = WebRequest.Create(uri);
            request.Method = method.ToString();
            request.ContentType = ContentType.ToString();

            if (dto != null)
            {
                using (var requestDataStream = request.GetRequestStream())
                {
                    var bodyBytes = SerializeBody(dto);
                    requestDataStream.Write(bodyBytes, 0, bodyBytes.Length);
                }
            }

            using (var response = request.GetResponse())
            {
                using (var dataStream = response.GetResponseStream())
                {
                    return dataStream.ReadFully();
                }
            }
        }

        private Uri GetUri(long? id = null, string action = null, UrlParams parameters = null)
        {
            var uriBuilder = new UriBuilder(ApiUrl)
            {
                Path = Path.Combine(
	                ApiVersion ?? string.Empty, 
	                EntityName ?? string.Empty, 
	                action ?? string.Empty, 
	                id?.ToString() ?? string.Empty),
                Query = parameters?.ToString() ?? string.Empty,
            };
            return uriBuilder.Uri;
        }

        private byte[] SerializeBody<TInput>(TInput dto)
        {
            switch (ContentType)
            {
                case HttpContentType type when type == HttpContentType.Json:
                    return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dto));
                default:
                    throw new Exception("Content-Type not supported.");
            }
        }

        private TResponse DeserializeResponse<TResponse>(byte[] bytes)
        {
            if (bytes == null)
                return default;

            switch (ContentType)
            {
                case HttpContentType type when type == HttpContentType.Json:
                    var responseText = Encoding.UTF8.GetString(bytes);
                    return JsonConvert.DeserializeObject<TResponse>(responseText);
                default:
                    throw new Exception("Content-Type not supported.");
            }
        }
    }
}