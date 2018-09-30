using System;
using System.ComponentModel.DataAnnotations.Schema;
using BitcoinExchange.Models.Enums;
using Infrastructure.Common;
using Infrastructure.WebApi.ApiClient;

namespace HitbtcApiClient.Dto
{
    /// <summary>
    /// Data transfer object for trade details. <a href="https://api.hitbtc.com/#trades">See here.</a>
    /// </summary>
    [ApiEntity("trades")]
    [Table("t_Trade")]
    public class TradeDto : Entity
    {
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public SideType Side { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
