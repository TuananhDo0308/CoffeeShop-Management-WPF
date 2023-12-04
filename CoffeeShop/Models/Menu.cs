using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using CoffeeShop.ViewModel;

namespace CoffeeShop.Models
{
    public partial class Menu:ViewModelBase
    {
        public Menu(int id, byte[] imageData, int idType, string nameFood, string description, decimal price, bool available )
        {
            Id = id;
            ImageData = imageData;
            IdType = idType;
            NameFood = nameFood;
            Description = description;
            Price = price;
            Available = available;
        }
        public Menu()
        {
        }

        public int Id { get; set; }
        public byte[]? ImageData { get; set; }


        public int? IdType { get; set; }
        public string? NameFood { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool? Available { get; set; }

        public virtual Type? IdTypeNavigation { get; set; }
        public virtual ICollection<Billdetail> Billdetails { get; set; }
    }
}
