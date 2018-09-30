using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BitcoinExchange.ServiceLayer.DataTransferObjects;
using DAL.RemoteRepositories;
using DomainObjects;
using DomainObjects.Enums;
using Infrastructure.DAL;
using Infrastructure.ServiceLayer;
using Infrastructure.ServiceLayer.UnitOfWork;

namespace BitcoinExchange.ServiceLayer.Services
{
    /// <summary>
    /// Implements all the business logic related to trades.
    /// </summary>
    public class TradeService : BaseService<TradeDto, Trade>
    {
        private readonly IBaseRepository<Trade> _tradeRepository;
        private readonly IHitbtcTradeRepository _hitbtcTradeRepository;

        public TradeService(IUnitOfWorkFactory unitOfWorkFactory, IBaseRepository<Trade> tradeRepository, IHitbtcTradeRepository hitbtcTradeRepository)
            : base(unitOfWorkFactory, tradeRepository)
        {
            _tradeRepository = tradeRepository;
            _hitbtcTradeRepository = hitbtcTradeRepository;
        }

        public IList<TradeDto> LoadLastTrades()
        {
            using (var unitOfWork = UnitOfWorkFactory.Create())
            {
                var hhitbtcTrades = _hitbtcTradeRepository.GetLastTrades(MarketType.ETHBTC);
                _tradeRepository.BulkInsert(hhitbtcTrades);
                return hhitbtcTrades
                    .Select(Mapper.Map<TradeDto>)
                    .ToList();
            }
        }
    }
}
