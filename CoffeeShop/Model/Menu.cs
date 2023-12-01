using System;
using System.Collections.Generic;

namespace CoffeeShop.Model
{
    public partial class Menu
    {
        public Menu(int id, byte[] imageData, string type, string nameFood, string description, decimal price, bool available, ICollection<Billdetail> billdetails)
        {
            Id = id;
            ImageData = imageData;
            Type = type;
            NameFood = nameFood;
            Description = description;
            Price = price;
            Available = available;
            Billdetails = billdetails;
        }
        public Menu()
        {
            Billdetails = new HashSet<Billdetail>();
        }

        public int Id { get; set; }
        public byte[]? ImageData { get; set; }
        public string? Type { get; set; }
        public string? NameFood { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public bool? Available { get; set; }

        public virtual ICollection<Billdetail> Billdetails { get; set; }
    }
}
