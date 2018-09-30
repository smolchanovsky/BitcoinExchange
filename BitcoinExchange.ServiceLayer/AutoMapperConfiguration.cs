using AutoMapper;
using BitcoinExchange.Models;
using BitcoinExchange.ServiceLayer.DataTransferObjects;

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
