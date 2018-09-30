using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BitcoinExchange.Models;
using BitcoinExchange.Models.Enums;
using BitcoinExchange.ServiceLayer.DataTransferObjects;
using HitbtcApiClient;
using Infrastructure.DataLayer;
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
        private readonly IHitbtcTradeClient _hitbtcTradeClient;

        public TradeService(IUnitOfWorkFactory unitOfWorkFactory, IBaseRepository<Trade> tradeRepository, IHitbtcTradeClient hitbtcTradeClient, IMapper modelMapper)
            : base(unitOfWorkFactory, tradeRepository, modelMapper)
        {
            _tradeRepository = tradeRepository;
            _hitbtcTradeClient = hitbtcTradeClient;
        }

        public IList<TradeDto> LoadLastTrades()
        {
            using (var unitOfWork = UnitOfWorkFactory.Create())
            {
                var hhitbtcTrades = _hitbtcTradeClient.GetLastTrades(MarketType.ETHBTC).Select(ModelMapper.Map<Trade>);
                _tradeRepository.BulkInsert(hhitbtcTrades);
                return hhitbtcTrades
                    .Select(ModelMapper.Map<TradeDto>)
                    .ToList();
            }
        }
    }
}
