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

namespace CoffeeShop.ViewModel
{
    public class LoginViewModel:ViewModelBase
    {
        public bool IsLogin { get; set; }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public LoginViewModel()
        {
            IsLogin = false;
            Password = "";
            UserName = "";
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
        }
        void Login(Window p)
        {
            if (p == null)
                return;

            /*
             admin
             admin

            staff
            staff
             */
            IsLogin = true;

            //string passEncode = MD5Hash(Base64Encode(Password));
            //var accCount = DataProvider.Ins.DB.Users.Where(x => x.UserName == UserName && x.Password == passEncode).Count();

            //if (accCount > 0)
            //{
            //    IsLogin = true;

            //    p.Close();
            //}
            //else
            //{
            //    IsLogin = false;
            //    MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            //}
        }

    }
}

