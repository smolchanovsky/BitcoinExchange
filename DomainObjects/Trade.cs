﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using DomainObjects.Enums;
using Infrastructure.Common;
using Infrastructure.Common.WebService;

namespace DomainObjects
{
    /// <summary>
    /// Trade details. <a href="https://api.hitbtc.com/#trades">See here.</a>
    /// </summary>
    [ApiEntity("trades")]
    [Table("t_Trade")]
    public class Trade : Entity
    {
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public SideType Side { get; set; }
        public DateTime Timestamp { get; set; }
    }
}