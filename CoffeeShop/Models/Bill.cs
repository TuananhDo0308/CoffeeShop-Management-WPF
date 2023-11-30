using System;
using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public partial class Bill
    {
        public Bill()
        {
            Billdetails = new HashSet<Billdetail>();
        }

        public int IdBill { get; set; }
        public int? IdEm { get; set; }
        public int? IdCustomer { get; set; }
        public DateTime? DayBill { get; set; }
        public decimal? Price { get; set; }
        public string? StatusBill { get; set; }

        public virtual Customer? IdCustomerNavigation { get; set; }
        public virtual Employee? IdEmNavigation { get; set; }
        public virtual ICollection<Billdetail> Billdetails { get; set; }
    }
}
