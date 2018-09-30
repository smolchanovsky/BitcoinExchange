using System;
using DomainObjects.Enums;
using Infrastructure.Common;

namespace BitcoinExchange.ServiceLayer.DataTransferObjects
{
    /// <summary>
    /// Holds all data about trade that is required for the remote call.
    /// </summary>
    public class TradeDto : Entity
    {
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public SideType Side { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
