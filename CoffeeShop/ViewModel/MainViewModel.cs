using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CoffeeShop.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        public ICommand LoadedWindowCommand { get; set; }
        public bool IsLoaded=false;
        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                IsLoaded = true;
                if (p == null)
                    return;
                p.Hide();
                Login loginWindow = new Login();
                loginWindow.ShowDialog();
            }
              );
        }
    }
}
