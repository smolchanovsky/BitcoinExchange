using System;
using System.ComponentModel.DataAnnotations.Schema;
using BitcoinExchange.Models.Enums;
using Infrastructure.Common;

namespace BitcoinExchange.Models
{
    /// <summary>
    /// Trade details.
    /// </summary>
    [Table("t_Trade")]
    public class Trade : Entity
    {
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public SideType Side { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
