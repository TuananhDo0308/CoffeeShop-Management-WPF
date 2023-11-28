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
using System.Windows.Input;

namespace CoffeeShop.ViewModel.Admin
{
    class MenuViewModel:ViewModelBase
    {

        private ObservableCollection<Menu> _menuList;
        public ObservableCollection<Menu> MenuList
        {
            get => _menuList;
            set
            {
                _menuList = value;
                OnPropertyChanged();
            }
        }


        public ICommand addFood { get; set; }
        public ICommand firstLoad { get; set; }


        public MenuViewModel() 
        {
            addFood = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                MessageBox.Show("ok add do an");
            });
            firstLoad = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
                await LoadListProduct();
            });

            
        }
        public async Task LoadListProduct()
        {
            try
            {


                //MenuList = new ObservableCollection<Menu>(await MenuService.Ins.GetAllProduct());
                
                return;
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
