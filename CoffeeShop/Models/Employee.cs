using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using CoffeeShop.ViewModel;
using Microsoft.VisualBasic;

namespace CoffeeShop.Models
{
    public partial class Employee:ViewModelBase
    {
        public Employee( byte[] imageData, string nameEm, DateTime? dayOfBirth, string phoneNum, string addressEm, string sex, string nameRole, string username, string pass)
        {
            ImageData = imageData;
            NameEm = nameEm;
            DayOfBirth = dayOfBirth;
            PhoneNum = phoneNum;
            AddressEm = addressEm;
            Sex = sex;
            NameRole = nameRole;
            Username = username;
            Pass = pass;
        }
        public Employee()
        {
        }

        public int? IdEm { get; set; }

        private byte[]? imageData;
        public byte[]? ImageData
        {
            get { return imageData; }
            set { imageData = value; OnPropertyChanged(); }
        }
        private string? nameEm;
        public string? NameEm
        {
            get { return nameEm; }
            set { nameEm = value; OnPropertyChanged(); }
        }

        private DateTime? dayOfBirth;
        public DateTime? DayOfBirth
        {
            get { return dayOfBirth; }
            set { dayOfBirth = value; OnPropertyChanged(); }
        }

        private string? phoneNum;
        public string? PhoneNum
        {
            get { return phoneNum; }
            set { phoneNum = value; OnPropertyChanged(); }
        }

        private string? addressEm;
        public string? AddressEm
        {
            get { return addressEm; }
            set { addressEm = value; OnPropertyChanged(); }
        }

        private string? sex;
        public string? Sex
        {
            get { return sex; }
            set { sex = value; OnPropertyChanged(); }
        }

        private string? nameRole;
        public string? NameRole
        {
            get { return nameRole; }
            set { nameRole = value; OnPropertyChanged(); }
        }

        private string? username;
        public string? Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged(); }
        }

        private string? pass;
        public string? Pass
        {
            get { return pass; }
            set { pass = value; OnPropertyChanged(); }
        }


        public virtual ICollection<Bill> Bills { get; set; }
    }
}
