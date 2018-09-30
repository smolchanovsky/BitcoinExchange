using System.Collections.Generic;
using BitcoinExchange.Models.Enums;
using TradeDto = HitbtcApiClient.Dto.TradeDto;

namespace HitbtcApiClient
{
    public interface IHitbtcTradeClient
    {
        TradeDto GetById(MarketType marketType, long id);
        IList<TradeDto> GetLastTrades(MarketType marketType);
    }
}