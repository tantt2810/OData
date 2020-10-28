using System;
using System.Collections.Generic;

namespace OData_NetFramework.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal TotalAmount { get; set; }
        public List<Product> Products { get; set; }
    }
}