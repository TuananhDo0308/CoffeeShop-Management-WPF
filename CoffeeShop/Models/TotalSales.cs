using System;
using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public class TotalSales
    {
        public TotalSales() { }
        public string FoodType { get; set; }
        public string FoodName { get; set; }
        public decimal Revenue { get; set; }
    }
}
