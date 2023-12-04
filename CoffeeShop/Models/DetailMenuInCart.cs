 using System;
using System.Collections.Generic;
using CoffeeShop.ViewModel;


namespace CoffeeShop.Models
{
    public partial class DetailMenuInCart:ViewModelBase
    {
        public DetailMenuInCart(int id, byte[] imageData, int? idType, string nameFood, decimal price)
        {
            Id = id;
            ImageData = imageData;
            IdType = idType;
            NameFood = nameFood;
            Price = price;
        }
        public DetailMenuInCart()
        {
        }

        public int Id { get; set; }
        public byte[]? ImageData { get; set; }
        public int? IdType { get; set; }
        private int number { get; set; }
        public int Number
        {
            get { return number; }
            set { number = value; OnPropertyChanged(); }
        }
        public string? NameFood { get; set; }
        public decimal Price { get; set; }
    }
}
