using System.Collections.Generic;
using DomainObjects;
using DomainObjects.Enums;

namespace BitcoinExchange.DataLayer.RemoteRepositories
{
    public interface IHitbtcTradeRepository
    {
        Trade GetById(MarketType marketType, long id);
        IList<Trade> GetLastTrades(MarketType marketType);
    }
}