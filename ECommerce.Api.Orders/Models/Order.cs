﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustumerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Total { get; set; }
        public IEnumerable<OrderItem> Items{ get; set; }
    }
}
