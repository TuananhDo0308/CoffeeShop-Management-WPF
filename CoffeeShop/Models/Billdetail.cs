using System;
using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public partial class Billdetail
    {
        public int IdBill { get; set; }
        public int Id { get; set; }
        public int? Soluong { get; set; }

        public virtual Bill IdBillNavigation { get; set; } = null!;
        public virtual Menu IdNavigation { get; set; } = null!;
    }
}
