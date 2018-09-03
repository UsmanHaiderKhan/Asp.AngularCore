﻿using System;
using System.Collections.Generic;

namespace Asp.AngularCore.git.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public ICollection<Order> Items { get; set; }
    }
}