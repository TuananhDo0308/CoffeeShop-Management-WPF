using System;
using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public partial class Type
    {
        public Type()
        {
            Menus = new HashSet<Menu>();
        }

        public int Id { get; set; }
        public string Type1 { get; set; }
        public bool? Available { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
    }
}
