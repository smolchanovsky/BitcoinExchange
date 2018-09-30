using System;

namespace Infrastructure.WebApi.ApiClient
{
    public class HttpContentType : IEquatable<HttpContentType>
    {
        private readonly string _contentTypeStr;

        private HttpContentType(string contentTypeStr)
        {
            _contentTypeStr = contentTypeStr;
        }

        public static HttpContentType Json => new HttpContentType("application/json");
        public static HttpContentType MsgPack => new HttpContentType("application/x-msgpack");
        public static HttpContentType Xml => new HttpContentType("application/xml");

        #region IEquatable
        public bool Equals(HttpContentType other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return this.GetHashCode() == other.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as HttpContentType);
        }

        public override int GetHashCode()
        {
            return _contentTypeStr != null ? _contentTypeStr.GetHashCode() : 0;
        }
        #endregion

        public static bool operator ==(HttpContentType left, HttpContentType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(HttpContentType left, HttpContentType right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return _contentTypeStr;
        }
    }
}