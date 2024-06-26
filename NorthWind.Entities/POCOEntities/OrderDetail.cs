﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.POCOEntities
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public string ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public Order Order { get; set; }
    }
}
