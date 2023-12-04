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
using CoffeeShop.View.AdminView;
using System.Globalization;


namespace CoffeeShop.ViewModel.Admin
{

    public class PosPageViewModel : ViewModelBase
    {
        public Window WindowCustomerName { get; set; }
        private List<string> listTypeString;
        public List<string> ListTypeString
        {
            get => listTypeString;
            set
            {
                listTypeString = value;
                OnPropertyChanged();
            }
        }
        private ComboBox filterBox;
        public ComboBox FilterBox
        {
            get => filterBox;
            set
            {
                filterBox = value;
                OnPropertyChanged();
            }
        }
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
        private DetailMenuInCart selectedProductCart;
        public DetailMenuInCart SelectedProductCart
        {
            get => selectedProductCart;
            set
            {
                selectedProductCart = value;
                OnPropertyChanged();
            }
        }
        private List<Models.Type> listType;
        public List<Models.Type> ListType
        {
            get => listType;
            set
            {
                listType = value;
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
        private ListBox listBoxCart;
        public ListBox ListBoxCart
        {
            get => listBoxCart;
            set
            {
                listBoxCart = value;
                OnPropertyChanged();
            }
        }
        private string searchBox;
        public string SearchBox
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
        private ObservableCollection<DetailMenuInCart> listCart;
        public ObservableCollection<DetailMenuInCart> ListCart
        {
            get => listCart;
            set
            {
                listCart = value;
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
        private string customer;
        public string Customer
        {
            get { return customer; }
            set { customer = value; OnPropertyChanged(); }
        }
        private string _roleStaff;
        public string RoleStaff
        {
            get { return _roleStaff; }
            set { _roleStaff = value; OnPropertyChanged(); }
        }
        private decimal total;
        public decimal Total
        {
            get { return total; }
            set { total = value; OnPropertyChanged(); }
        }
        public ICommand placeOrder { get; set; }
        public ICommand addToCart { get; set; }

        public ICommand firstLoad { get; set; }
        public ICommand getListBox { get; set; }
        public ICommand findProducts { get; set; }
        public ICommand getFilterBox { get; set; }
        public ICommand getListBoxCart { get; set; }
        public ICommand filterProducts { get; set; }
        public ICommand changeNumber { get; set; }
        public ICommand removeCart { get; set; }
        public ICommand getWindowCustomerName { get; set; }
        public ICommand openCustomerNameWindow { get; set; }
        public ICommand exitCustomerNameWindow { get; set; }
        public ICommand MouseLeftButtonDownWindow { get; set; }




        public PosPageViewModel()
        {
            MouseLeftButtonDownWindow = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null)
                {
                    p.DragMove();
                }
            });
            getWindowCustomerName = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                WindowCustomerName=p;
            });

            getFilterBox = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                filterBox=p;
            });
            openCustomerNameWindow = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                CustomerName customerName= new CustomerName();
                customerName.ShowDialog();
            });

            exitCustomerNameWindow = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                WindowCustomerName.Close();
            });
            changeNumber = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                ReCaculate();
            });
            //get element
            getListBox = new RelayCommand<ListBox>((p) => { return true; }, (p) =>
            {
                listBox=p;
            });

            getListBoxCart = new RelayCommand<ListBox>((p) => { return true; }, (p) =>
            {
                listBoxCart=p;
            });

            //Load page
            firstLoad = new RelayCommand<Page>((p) => { return true; }, async (p) =>
            {
                User=App.MainUser;
                NameStaff=User.NameEm;
                RoleStaff=User.NameRole.ToString();

                await LoadListType();
                await LoadListProduct();
                await LoadListTypeString();

                ListCart = new ObservableCollection<DetailMenuInCart>();

                var comboBoxItems = new List<string> { "ALL" };
                comboBoxItems.AddRange(ListTypeString);

                filterBox.ItemsSource = comboBoxItems;
                filterBox.SelectedIndex=0;
            });

            //Function
            removeCart = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                if (SelectedProductCart != null)
                {
                    var itemToRemove = listCart.FirstOrDefault(item => item.Id == SelectedProductCart.Id);

                    if (itemToRemove != null)
                    {
                        listCart.Remove(itemToRemove);
                        OnPropertyChanged(nameof(ListCart)); 
                    }
                }
                ReCaculate();
            });
            placeOrder = new RelayCommand<Button>((p) => { return true; }, async (p) =>
            {
                try
                {
                    await BillService.Ins.AddBill(ListCart,Total,Customer);
                    await LoadListProduct();
                    ListCart=new ObservableCollection<DetailMenuInCart>();
                    Total= 0;
                    Customer="";
                    WindowCustomerName.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            });
            addToCart = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                if (selectedProduct != null)
                {
                    var existingItem = listCart.FirstOrDefault(item => item.Id == selectedProduct.Id);

                    if (existingItem != null)
                    {
                        existingItem.Number++;
                    }
                    else
                    {
                        listCart.Add(new DetailMenuInCart()
                        {
                            Id = selectedProduct.Id,
                            NameFood = selectedProduct.NameFood,
                            Price = selectedProduct.Price,
                            Number = 1,
                            ImageData = selectedProduct.ImageData,
                            IdType = selectedProduct.IdType
                        });
                    }
                    ReCaculate();
                }
            });

            findProducts = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                filterBox.SelectedIndex=0;
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listBox.ItemsSource);
                view.Filter = Filter;
                CollectionViewSource.GetDefaultView(listBox.ItemsSource).Refresh();
            });

            filterProducts = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {

                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listBox.ItemsSource);
                if (filterBox.SelectedIndex == 0)
                {
                    view.Filter = null;
                }
                else
                {
                    int selectedTypeId = filterBox.SelectedIndex - 1;
                    view.Filter = (item) =>
                    {
                        return (item as Models.Menu)?.IdType == selectedTypeId;
                    };
                }

                view.Refresh();
            });
        }

        private bool Filter(object item)
        {
            if (String.IsNullOrEmpty(SearchBox))
                return true;
            else
                return ((item as Models.Menu)?.NameFood?.IndexOf(SearchBox, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public void ReCaculate()
        {
            Total=0;
            foreach(DetailMenuInCart temp in listCart)
            {
                    Total += temp.Price*temp.Number;
            }
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
        public async Task LoadListType()
        {
            try
            {
                listType = new List<Models.Type>(await MenuService.Ins.GetAllType());
                return;
            }

            catch (Exception)
            {
                throw;
            }
        }
        public async Task LoadListTypeString()
        {
            try
            {
                ListTypeString = new List<string>();
                foreach (var item in listType)
                {
                    ListTypeString.Add(item.Type1.ToString());
                }
                return;
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
    
