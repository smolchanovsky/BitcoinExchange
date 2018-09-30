using BitcoinExchange.DataLayer;
using BitcoinExchange.ServiceLayer.Services;
using HitbtcApiClient;
using Infrastructure.DataLayer;
using Infrastructure.DataLayer.Connection;
using Infrastructure.ServiceLayer.UnitOfWork;
using Infrastructure.WebApi.ApiClient;
using Microsoft.Extensions.DependencyInjection;

namespace BitcoinExchange.WebService
{
	public static class IoCConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<ApiClient>();
            services.AddScoped<IHitbtcTradeClient, HitbtcTradeClient>();
            services.AddScoped<IConnectionFactory, SqlServerConnectionFactory>();
            services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<TradeService>();
        }
    }
}
