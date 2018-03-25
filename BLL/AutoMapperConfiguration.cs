using AutoMapper;
using BLL.DataTransferObjects;
using DomainObjects;

namespace BLL
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Trade, TradeDto>());
        }
    }
}
