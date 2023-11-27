using CoffeeShop.Model;
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

namespace CoffeeShop.ViewModel
{
    public class LoginViewModel:ViewModelBase
    {
        
        public Window loginWindow { get; set; }
        public Button loginButton { get; set; }


        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged(); }
        }
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        public ICommand MouseLeftButtonDownWindow { get; set; }
        public ICommand loginCommand { get; set; }
        public ICommand getPassword { get; set; }
        public ICommand setLoginWindow { get; set; }
        public ICommand exitLogin {  get; set; }
        public ICommand minimizeLogin { get; set; }

        public LoginViewModel()
        {
            loginCommand = new RelayCommand<Button>((p) => { return true; } , async (p) =>
            {
                string username = UserName;
                string password = Password;
                if (username==null || password==null)
                {
                    Status="Nhap day du thong tin";
                }
                else
                {
                    Status="";
                    CheckLogin(username,password);
                }
            });
            getPassword = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                Password = p.Password;
            });
            MouseLeftButtonDownWindow = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null)
                {
                    p.DragMove();
                }
            });
            setLoginWindow = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                loginWindow = p;
            });
            exitLogin = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                loginWindow.Close();

            });
            minimizeLogin = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                loginWindow.WindowState = WindowState.Minimized;
            });
        }
        private void CheckLogin(string user,string password)
        {
            if(true)
            {
                Adminstrator adminstrator = new Adminstrator();
                adminstrator.Show();
                loginWindow.Hide();
            }
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

    }
}

