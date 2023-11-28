using System;
using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Hoadons = new HashSet<Hoadon>();
        }

        public int Manv { get; set; }
        public string? Hoten { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string? Sdt { get; set; }
        public string? Diachi { get; set; }
        public string? Gioitinh { get; set; }
        public string? Tenvt { get; set; }
        public string? Tendn { get; set; }
        public string? Matkhau { get; set; }

        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
