using CoffeeShop.Models;
using CoffeeShop.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace CoffeeShop.ViewModel.Admin
{

    public class PosPageViewModel : ViewModelBase
    {
        private Models.Menu selectedProduct;
        public Models.Menu SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                OnPropertyChanged();
            }
        }

        private ListBox listBox;
        public ListBox ListBox
        {
            get => listBox;
            set
            {
                listBox = value;
                OnPropertyChanged();
            }
        }
        private TextBox searchBox;
        public TextBox SearchBox
        {
            get => searchBox;
            set
            {
                searchBox = value;
                OnPropertyChanged();
            }
        }
        private List<Models.Menu> _menuList;
        public List<Models.Menu> MenuList
        {
            get => _menuList;
            set
            {
                _menuList = value;
                OnPropertyChanged();
            }
        }
        public Employee _User;
        public Employee User
        {
            get { return _User; }
            set { _User = value; OnPropertyChanged(); }
        }
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
        public ICommand placeOrder { get; set; }
        public ICommand firstLoad { get; set; }
        public ICommand getListBox { get; set; }
        public ICommand getSearchBox { get; set; }
        public ICommand findProducts { get; set; }

        public PosPageViewModel()
        {
            //get element
            getListBox = new RelayCommand<ListBox>((p) => { return true; }, (p) =>
            {
                listBox=p;
            });
            getSearchBox = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                searchBox=p;
            });

            //Load page
            firstLoad = new RelayCommand<Page>((p) => { return true; }, async (p) =>
            {
                User=App.MainUser;
                NameStaff=User.NameEm;
                RoleStaff=User.NameRole.ToString();

                await LoadListProduct();
            });

            //Function
            placeOrder = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                MessageBox.Show("ok");
                Login login = new Login();
                login.Show();
            });
            findProducts = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listBox.ItemsSource);
            });
            findProducts = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listBox.ItemsSource);
                view.Filter = Filter;
                CollectionViewSource.GetDefaultView(listBox.ItemsSource).Refresh();
            });

        }

        private bool Filter(object item)
        {
            if (String.IsNullOrEmpty(SearchBox.Text))
                return true;
            else
                return ((item as  Models.Menu).NameFood.IndexOf(SearchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public async Task LoadListProduct()
        {
            try
            {
                MenuList = new List<Models.Menu>(await MenuService.Ins.GetAllProduct());

                return;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
