using System.Collections.Generic;
using BitcoinExchange.Models;
using BitcoinExchange.Models.Enums;

namespace BitcoinExchange.DataLayer.RemoteRepositories
{
    public interface IHitbtcTradeRepository
    {
        Trade GetById(MarketType marketType, long id);
        IList<Trade> GetLastTrades(MarketType marketType);
    }
}