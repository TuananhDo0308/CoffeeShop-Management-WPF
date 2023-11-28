using System;
using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public partial class Menu
    {
        public Menu()
        {
            Chitiethoadons = new HashSet<Chitiethoadon>();
        }

        public int Mama { get; set; }
        public int? Maloai { get; set; }
        public string? Tenmonan { get; set; }
        public decimal? Gia { get; set; }

        public virtual Loaimon? MaloaiNavigation { get; set; }
        public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; }
    }
}
