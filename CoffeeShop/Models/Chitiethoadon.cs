using System;
using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public partial class Chitiethoadon
    {
        public int Mahd { get; set; }
        public int Mama { get; set; }
        public int? Soluong { get; set; }

        public virtual Hoadon MahdNavigation { get; set; } = null!;
        public virtual Menu MamaNavigation { get; set; } = null!;
    }
}
