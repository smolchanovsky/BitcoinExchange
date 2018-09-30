using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using BitcoinExchange.Models;
using BitcoinExchange.Models.Enums;
using Infrastructure.Common.WebService;

namespace BitcoinExchange.DataLayer.RemoteRepositories
{
    public class HitbtcTradeRepository : IHitbtcTradeRepository
    {
        private readonly ApiClient _apiClient;

        public HitbtcTradeRepository(ApiClient apiClient)
        {
            _apiClient = apiClient;
			//TODO: Implement config class for ApiClient
			_apiClient.ApiUrl = "https://api.hitbtc.com";
            _apiClient.ApiVersion = "api/2/public/";
            _apiClient.EntityName = typeof(Trade)
                .GetCustomAttributes(true)
                .OfType<ApiEntityAttribute>()
                .FirstOrDefault()?
                .ApiEntityName;
        }

        public IList<Trade> GetLastTrades(MarketType marketType)
        {
            return _apiClient.MakeRequest<IList<Trade>>(
		        HttpMethod.Get,
		        marketType.ToString(),
		        new UrlParams { (Name: "sort", Value: "DESC") }); ;
        }

        public Trade GetById(MarketType marketType, long id)
        {
            return _apiClient.MakeRequest<Trade>(
		        HttpMethod.Get,
		        marketType.ToString(),
		        new UrlParams { (Name: "by", Value: id) }); ;
        }
    }
}