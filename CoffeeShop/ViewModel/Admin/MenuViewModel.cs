using CoffeeShop.Models;
using CoffeeShop.Service;
using CoffeeShop.View.AdminView;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;

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

        public Window AddFoodWindow { get; set; }

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
        private int newProductType;
        public int NewProductType
        {
            get => newProductType;
            set
            {
                newProductType = value;
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
        public ICommand getFilterBox { get; set; }
        public ICommand filterProducts { get; set; }

        public ICommand getImage { get; set; }




        public MenuViewModel()
        {

            // Get element

            getImage = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (SelectedProduct != null)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg;*.gif;*.bmp)|*.png;*.jpeg;*.jpg;*.gif;*.bmp|All files (*.*)|*.*";

                    if (openFileDialog.ShowDialog() == true)
                    {
                        BitmapImage bitmapImage = new BitmapImage(new Uri(openFileDialog.FileName));

                        // Convert BitmapImage to byte array
                        SelectedProduct.ImageData = BitmapImageToByteArray(bitmapImage);

                        // Update UI
                        CollectionViewSource.GetDefaultView(listBox.ItemsSource).Refresh();
                    }
                }
            });
            getListBox = new RelayCommand<ListBox>((p) => { return true; }, (p) =>
            {
                listBox=p;
            });
            getFilterBox = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                filterBox=p;
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

                await LoadListType();
                await LoadListTypeString();
                await LoadListProduct();

                var comboBoxItems = new List<string> { "ALL" };
                comboBoxItems.AddRange(ListTypeString);

                filterBox.ItemsSource = comboBoxItems;
                filterBox.SelectedIndex=0;
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
                if (selectedProduct!=null)
                {
                    await MenuService.Ins.DeleteProduct(selectedProduct);
                    await LoadListProduct();
                }
                

            });
            updateProducts = new RelayCommand<Button>((p) => { return true; }, async (p) =>
            {
                await MenuService.Ins.UpdateProducts(MenuList);
            });
            addFood = new RelayCommand<Button>((p) => { return true; }, async (p) =>
            {
                try
                {
                    var newProduct = new Models.Menu(0, null, newProductType, newProductName, newProductDescription, newProductPrice, true);
                    await MenuService.Ins.AddProduct(newProduct);
                    await LoadListProduct();
                    AddFoodWindow.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
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
                    searchBox.Text = "";

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



        



        //Tìm kiếm
        private bool Filter(object item)
        {
            if (String.IsNullOrEmpty(SearchBox.Text))
                return true;
            else
                return ((item as  Models.Menu).NameFood.IndexOf(SearchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }


        //Load list đồ ăn 
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
                foreach(var item in listType)
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
        private byte[] BitmapImageToByteArray(BitmapImage bitmapImage)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                encoder.Save(stream);

                return stream.ToArray();
            }
        }
    }
}
