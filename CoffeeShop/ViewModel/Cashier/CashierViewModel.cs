using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Collections;
using System.Windows.Navigation;
using CoffeeShop.View.CashierView;
using CoffeeShop.View.AdminView;

namespace CoffeeShop.ViewModel.Cashier
{
    public class CashierViewModel : ViewModelBase
    {
        public Window cashierWindow { get; set; }
        public ICommand setCashierWindow { get; set; }
        public ICommand exitCashier { get; set; }
        public ICommand minimizeCashier { get; set; }
        public ICommand logOut { get; set; }
        public CashierViewModel()
        {
            setCashierWindow = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                //contentFrame.Content = new PosPage();
                cashierWindow = p;
            });
            minimizeCashier = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                cashierWindow.WindowState = WindowState.Minimized;
            });
            exitCashier = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                cashierWindow.Close();
            });
            logOut = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                Login login = new Login();
                login.Show();
                cashierWindow.Close();
            });
        }

    }
}