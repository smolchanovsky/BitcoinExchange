using BLL.Services;
using DAL;
using DAL.RemoteRepositories;
using Infrastructure.BLL.UnitOfWork;
using Infrastructure.Common.WebService;
using Infrastructure.DAL;
using Infrastructure.DAL.Connection;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class IoCConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<ApiClient>();
            services.AddScoped<IHitbtcTradeRepository, HitbtcTradeRepository>();
            services.AddScoped<IConnectionFactory, SqlServerConnectionFactory>();
            services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<TradeService>();
        }
    }
}
