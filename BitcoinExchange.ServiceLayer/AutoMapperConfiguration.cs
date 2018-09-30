using AutoMapper;
using BitcoinExchange.ServiceLayer.DataTransferObjects;
using DomainObjects;

namespace BitcoinExchange.ServiceLayer
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Trade, TradeDto>());
        }
    }
}
