using System;
using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public partial class Loaimon
    {
        public Loaimon()
        {
            Menus = new HashSet<Menu>();
        }

        public int Maloai { get; set; }
        public string? Tenloai { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
    }
}
