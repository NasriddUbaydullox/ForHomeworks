﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._12._2024_HomeWork
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public int TotalAmount { get; set; }
        public List<OrderItem> orderItems { get; set; }
    }
}