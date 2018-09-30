using System;
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
            var result = _apiClient.MakeRequest<IList<Trade>>(
                HttpMethod.Get,
                marketType.ToString(),
                new UrlParams { ( Name: "sort", Value: "DESC" ) },
                out var error);

            if (error != null)
                throw new InvalidOperationException(error.message);

            return result;
        }

        public Trade GetById(MarketType marketType, long id)
        {
            var result = _apiClient.MakeRequest<Trade>(
                HttpMethod.Get,
                marketType.ToString(),
                new UrlParams { ( Name: "by", Value: id ) },
                out var error);

            if (error != null)
                throw new InvalidOperationException(error.message);

            return result;
        }
    }
}