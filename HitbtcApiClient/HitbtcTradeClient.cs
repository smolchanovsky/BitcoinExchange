using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using BitcoinExchange.Models.Enums;
using HitbtcApiClient.Dto;
using Infrastructure.WebApi.ApiClient;

namespace HitbtcApiClient
{
    public class HitbtcTradeClient : IHitbtcTradeClient
    {
        private readonly ApiClient _apiClient;

        public HitbtcTradeClient(ApiClient apiClient)
        {
            _apiClient = apiClient;
			//TODO: Implement config class for ApiClient
			_apiClient.ApiUrl = "https://api.hitbtc.com";
            _apiClient.ApiVersion = "api/2/public/";
            _apiClient.EntityName = typeof(TradeDto)
                .GetCustomAttributes(true)
                .OfType<ApiEntityAttribute>()
                .FirstOrDefault()?
                .ApiEntityName;
        }

        public IList<TradeDto> GetLastTrades(MarketType marketType)
        {
            return _apiClient.MakeRequest<IList<TradeDto>>(
		        HttpMethod.Get,
		        marketType.ToString(),
		        new UrlParams { (Name: "sort", Value: "DESC") }); ;
        }

        public TradeDto GetById(MarketType marketType, long id)
        {
            return _apiClient.MakeRequest<TradeDto>(
		        HttpMethod.Get,
		        marketType.ToString(),
		        new UrlParams { (Name: "by", Value: id) }); ;
        }
    }
}