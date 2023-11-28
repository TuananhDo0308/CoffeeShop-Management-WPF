using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CoffeeShop.ViewModel.Admin
{

    public class PosPageViewModel:ViewModelBase
    {
        private string _nameStaff;
        public string NameStaff
        {
            get { return _nameStaff; }
            set { _nameStaff = value; OnPropertyChanged(); }
        }
        private string _roleStaff;
        public string RoleStaff
        {
            get { return _roleStaff; }
            set { _roleStaff = value; OnPropertyChanged(); }
        }
        private string _searchBox;
        public string SearchBox
        {
            get { return _searchBox; }
            set { _searchBox = value; OnPropertyChanged(); }
        }
        public ICommand placeOrder { get; set; }
        public PosPageViewModel()
        {
            placeOrder = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                MessageBox.Show("ok");
                Login login = new Login();
                login.Show();
            });
        }
    }
}
