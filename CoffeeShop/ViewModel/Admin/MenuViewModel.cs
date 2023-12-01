using CoffeeShop.Model;
using CoffeeShop.Service;
using CoffeeShop.View.AdminView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace CoffeeShop.ViewModel.Admin
{
    class MenuViewModel : ViewModelBase
    {
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
        private ComboBoxItem _Category;
        public ComboBoxItem Category
        {
            get { return _Category; }
            set
            {
                _Category = value; OnPropertyChanged();
            }
        }
        public Window AddFoodWindow { get; set; }

        private List<Model.Menu> _menuList;
        public List<Model.Menu> MenuList
        {
            get => _menuList;
            set
            {
                _menuList = value;
                OnPropertyChanged();
            }
        }
        private Model.Menu selectedProduct;
        public Model.Menu SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                OnPropertyChanged();
            }
        }
        private string newProductName;
        public string NewProductName
        {
            get => newProductName;
            set
            {
                newProductName = value;
                OnPropertyChanged();
            }
        }
        private int newProductPrice;
        public int NewProductPrice
        {
            get => newProductPrice;
            set
            {
                newProductPrice = value;
                OnPropertyChanged();
            }
        }
        private string newProductDescription;
        public string NewProductDescription
        {
            get => newProductDescription;
            set
            {
                newProductDescription = value;
                OnPropertyChanged();
            }
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
        public Employee _User;
        public Employee User
        {
            get { return _User; }
            set { _User = value; OnPropertyChanged(); }
        }
        public ICommand MouseLeftButtonDownWindow { get; set; }
        public ICommand setAddFoodWindow { get; set; }
        public ICommand exit { get; set; }
        public ICommand addFoodWindow { get; set; }
        public ICommand addFood { get; set; }
        public ICommand firstLoad { get; set; }
        public ICommand updateProducts { get; set; }
        public ICommand deleteProduct { get; set; }
        public ICommand getListBox { get; set; }
        public ICommand getSearchBox { get; set; }
        public ICommand findProducts { get; set; }



        public MenuViewModel()
        {

            // Get element
            getListBox = new RelayCommand<ListBox>((p) => { return true; }, (p) =>
            {
                listBox=p;
            });
            getSearchBox = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                searchBox=p;
            });
            setAddFoodWindow = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                AddFoodWindow = p;
            });

            //Load page
            firstLoad = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
                User=App.MainUser;
                NameStaff=User.NameEm;
                RoleStaff=User.NameRole.ToString();
                await LoadListProduct();
            });

            MouseLeftButtonDownWindow = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null)
                {
                    p.DragMove();
                }
            });
            exit = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                AddFoodWindow.Close();
            });

            //function
            addFoodWindow = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                AddFood addFood = new AddFood();
                addFood.ShowDialog();
            });
            deleteProduct = new RelayCommand<Button>((p) => { return true; }, async (p) =>
            {
                await MenuService.Ins.DeleteProduct(selectedProduct);
                await LoadListProduct();

            });
            updateProducts = new RelayCommand<Button>((p) => { return true; }, async (p) =>
            {
                await MenuService.Ins.UpdateProducts(MenuList);
            });
            addFood = new RelayCommand<Button>((p) => { return true; }, async (p) =>
            {
                try
                {
                    var newProduct = new Model.Menu(0,null,"Coffee", NewProductName, newProductDescription, NewProductPrice, true,null);
                    await MenuService.Ins.AddProduct(newProduct);
                    await LoadListProduct();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            });
            findProducts = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listBox.ItemsSource);
                view.Filter = Filter;
                CollectionViewSource.GetDefaultView(listBox.ItemsSource).Refresh();
            });



        }



        //Tìm kiếm
        private bool Filter(object item)
        {
            if (String.IsNullOrEmpty(SearchBox.Text))
                return true;
            else
                return ((item as  Model.Menu).NameFood.IndexOf(SearchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }


        //Load list đồ ăn 
        public async Task LoadListProduct()
        {
            try
            {
                MenuList = new List<Model.Menu>(await MenuService.Ins.GetAllProduct());
                return;
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
