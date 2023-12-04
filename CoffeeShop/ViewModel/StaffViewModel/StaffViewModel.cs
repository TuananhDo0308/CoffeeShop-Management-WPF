using CoffeeShop.Models;
using CoffeeShop.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CoffeeShop.ViewModel.StaffViewModel
{
    public class StaffViewModel:ViewModelBase
    {
        public Employee _User;
        public Employee User
        {
            get { return _User; }
            set { _User = value; OnPropertyChanged(); }
        }
        public Window StaffWindow { get; set; }
        private ObservableCollection<FullBill> bills;
        public ObservableCollection<FullBill> Bills
        {
            get => bills;
            set
            {
                bills = value;
                OnPropertyChanged();
            }
        }
        private FullBill selectedBill;
        public FullBill SelectedBill
        {
            get => selectedBill;
            set
            {
                selectedBill = value;
                OnPropertyChanged();
            }
        }
        public ICommand firstLoad { get; set; }
        public ICommand getStaffWindow { get; set; }

        public ICommand minimizeWindow { get; set; }
        public ICommand closeWindow { get; set; }

        public ICommand logOut { get; set; }
        public ICommand doneButton { get; set; }

        public StaffViewModel()
        {
            firstLoad = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
                await LoadListProduct();
                User=App.MainUser;
                StaffWindow=p;

            });
            doneButton = new RelayCommand<Button>((p) => { return true; }, async (p) =>
            {
                if (SelectedBill!=null)
                {
                    await BillService.Ins.UpdateStatus(SelectedBill);
                    await LoadListProduct();
                }
            });
            logOut = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                Login login = new Login();
                login.Show();
                StaffWindow.Close();
            });
            minimizeWindow = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                StaffWindow.WindowState=WindowState.Minimized;
            });
            closeWindow = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                StaffWindow.Close();
            });
        }
        public async Task LoadListProduct()
        {
            try
            {
                Bills = new ObservableCollection<FullBill>(await BillService.Ins.GetAllBillForStaff());
                return;
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
