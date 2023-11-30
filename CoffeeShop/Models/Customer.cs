using System;
using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Bills = new HashSet<Bill>();
        }

        public int IdCustomer { get; set; }
        public string? NameCustomer { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
