using System;
using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public partial class Menu
    {
        public Menu(int id, byte[] imageData, string type, string nameFood, string description, decimal price, ICollection<Billdetail> billdetails)
        {
            this.Id = id;
            this.ImageData = imageData;
            this.NameFood = nameFood;
            this.Type = type;
            this.Price = price;
            this.Description = description;
            this.Price = price;
            this.Billdetails=billdetails;
        }
        public Menu()
        {
           // Billdetails = new HashSet<Billdetail>();
        }

        public int Id { get; set; }
        public byte[]? ImageData { get; set; }
        public string? Type { get; set; }
        public string? NameFood { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<Billdetail> Billdetails { get; set; }
    }
}
