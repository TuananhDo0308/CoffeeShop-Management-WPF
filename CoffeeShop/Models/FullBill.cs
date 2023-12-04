using CoffeeShop.Service;
using CoffeeShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CoffeeShop.Models
{
    public class Item
    {
        public Item(string? name, int? number)
        {
            Name = name;
            Number = number;
        }
        public string? Name { get; set; }
        public int? Number { get; set; }
    }
    public class FullBill : ViewModelBase
    {
        public int IdBill { get; set; }
        public string NameCustomer { get; set; }
        public string? DayBill { get; set; }
        public decimal? Price { get; set; }
        public string? StatusBill { get; set; }
        public string? StaffName { get; set; }

        private ObservableCollection<Item> listItem { get; set; }
        public ObservableCollection<Item> ListItem
        {
            get { return listItem; }
            set { listItem = value; OnPropertyChanged(); }
        }
        public FullBill(Bill temp1, ObservableCollection<Employee> temp2)
        {
            IdBill = temp1.IdBill;
            NameCustomer = temp1.NameCustomer;
            if (temp1.IdEm == 1)
            {
                StaffName = "Admin";
            }
            foreach (var item in temp2)
            {
                if (temp1.IdEm == item.IdEm)
                {
                    StaffName = item.NameEm;
                    break;
                }
            }
            DayBill = temp1.DayBill.ToString("dd/MM/yyyy");
            Price = temp1.Price;
            StatusBill = temp1.StatusBill;
            LoadItemsAsync();
        }

        private async void LoadItemsAsync()
        {
            ListItem = new ObservableCollection<Item>(await BillService.Ins.GetItemsForBill(IdBill));
        }
        public FullBill()
        {

        }
    }
}
