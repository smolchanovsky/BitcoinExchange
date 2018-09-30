﻿using BitcoinExchange.DataLayer;
using BitcoinExchange.DataLayer.RemoteRepositories;
using BitcoinExchange.ServiceLayer.Services;
using Infrastructure.Common.WebService;
using Infrastructure.DataLayer;
using Infrastructure.DataLayer.Connection;
using Infrastructure.ServiceLayer.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace BitcoinExchange.ServiceLayer
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
