using System;
using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public partial class Hoadon
    {
        public Hoadon()
        {
            Chitiethoadons = new HashSet<Chitiethoadon>();
        }

        public int Mahd { get; set; }
        public int? Manv { get; set; }
        public int? Makh { get; set; }
        public DateTime? Ngaylap { get; set; }
        public decimal? Gia { get; set; }
        public string? Tinhtrang { get; set; }

        public virtual Khachhang? MakhNavigation { get; set; }
        public virtual Nhanvien? ManvNavigation { get; set; }
        public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; }
    }
}
