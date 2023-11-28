using System;
using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Hoadons = new HashSet<Hoadon>();
        }

        public int Makh { get; set; }
        public string? Hoten { get; set; }

        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
