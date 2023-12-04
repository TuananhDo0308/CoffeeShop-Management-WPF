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
using System.IO;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace CoffeeShop.ViewModel.Admin
{
    public class EmployeeManangementViewModel:ViewModelBase
    {

        public Window DetailWindow { get; set; }
        private Employee _User;
        public Employee User
        {
            get { return _User; }
            set { _User = value; OnPropertyChanged(); }
        }
        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set { selectedEmployee = value; OnPropertyChanged(); }
        }
        private ListBox lisBoxEmployee;
        public ListBox LisBoxEmployee
        {
            get { return lisBoxEmployee; }
            set { lisBoxEmployee = value; OnPropertyChanged(); }
        }
        private string searchBox;
        public string SearchBox
        {
            get { return searchBox; }
            set { searchBox = value; OnPropertyChanged(); }
        }
        private int selectedEmployeeRoleIndexWindow;
        public int SelectedEmployeeRoleIndexWindow
        {
            get { return selectedEmployeeRoleIndexWindow; }
            set { selectedEmployeeRoleIndexWindow = value; OnPropertyChanged(); }
        }
        private int selectedEmployeeGenderIndexWindow;
        public int SelectedEmployeeGenderIndexWindow
        {
            get { return selectedEmployeeGenderIndexWindow; }
            set { selectedEmployeeGenderIndexWindow = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Employee> listEmployees;
        public ObservableCollection<Employee> ListEmployees
        {
            get => listEmployees;
            set
            {
                listEmployees = value;
                OnPropertyChanged();
            }
        }
        public ICommand firstLoad { get; set; }
        public ICommand getDetailWindow { get; set; }
        public ICommand UpdateEmployee { get; set; }
        public ICommand getListBoxEmployee { get; set; }

        public ICommand openDetailEmployeeWindow { get; set; }
        public ICommand closeDetailEmployeeWindow { get; set; }
        public ICommand MouseLeftButtonDownWindow { get; set; }
        public ICommand findEmployee { get; set; }
        public ICommand removeEmployee { get; set; }
        public ICommand addNewEmployee { get; set; }
        public ICommand getImage { get; set; }

        private bool checkAdd { get; set; }

        public EmployeeManangementViewModel() 

        {
            getImage = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (SelectedEmployee != null)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg;*.gif;*.bmp)|*.png;*.jpeg;*.jpg;*.gif;*.bmp|All files (*.*)|*.*";

                    if (openFileDialog.ShowDialog() == true)
                    {
                        BitmapImage bitmapImage = new BitmapImage(new Uri(openFileDialog.FileName));

                        // Convert BitmapImage to byte array
                        SelectedEmployee.ImageData = BitmapImageToByteArray(bitmapImage);

                        // Update UI
                        CollectionViewSource.GetDefaultView(LisBoxEmployee.ItemsSource).Refresh();
                    }
                }
            });
            findEmployee = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                    Console.WriteLine("Find Employee command executed");
                    CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(LisBoxEmployee.ItemsSource);
                    view.Filter = Filter;
                    CollectionViewSource.GetDefaultView(LisBoxEmployee.ItemsSource).Refresh();
             

            });
            addNewEmployee = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {

                SelectedEmployee =new Employee();
                checkAdd=true;
                DetailEmployee employee = new DetailEmployee();
                employee.ShowDialog();
            });
            getListBoxEmployee = new RelayCommand<ListBox>((p) => { return true; }, (p) =>
            {
                LisBoxEmployee = p;
            });
            MouseLeftButtonDownWindow = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null)
                {
                    p.DragMove();
                }
            });
            openDetailEmployeeWindow = new RelayCommand<Button>((p) => { return true; }, async (p) =>
            {
                checkAdd=false;
                DetailEmployee employee = new DetailEmployee();
                employee.ShowDialog();
            });
            closeDetailEmployeeWindow = new RelayCommand<Button>((p) => { return true; }, async (p) =>
            {
                DetailWindow.Close();
            });
            getDetailWindow = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
                if(selectedEmployee.NameRole=="Cashier")
                    SelectedEmployeeRoleIndexWindow =1;
                if (selectedEmployee.Sex=="Nữ")
                    SelectedEmployeeGenderIndexWindow =1;
                DetailWindow =p;
            });
            firstLoad = new RelayCommand<Page>((p) => { return true; }, async (p) =>
            {
                User=App.MainUser;
                await LoadListEmployees();
            });
            removeEmployee = new RelayCommand<Page>((p) => { return true; }, async (p) =>
            {
                if (SelectedEmployee!=null)
                {
                    await StaffService.Ins.DeleteEmployee(SelectedEmployee);
                    await LoadListEmployees();
                }
            });
            UpdateEmployee = new RelayCommand<Page>((p) => { return true; }, async (p) =>
            {

                if (SelectedEmployeeRoleIndexWindow==0)
                {
                    selectedEmployee.NameRole="Staff";
                }
                else if (SelectedEmployeeRoleIndexWindow==1)
                {
                    selectedEmployee.NameRole="Cashier";
                }
                if (SelectedEmployeeGenderIndexWindow==0)
                {
                    selectedEmployee.Sex="Nam";
                }
                else if (SelectedEmployeeRoleIndexWindow==1)
                {
                    selectedEmployee.Sex="Nữ";
                }
                if (checkAdd==true)
                {
                    await StaffService.Ins.AddEmployee(SelectedEmployee);
                }
                else if (checkAdd==false)
                {
                    foreach (var employee in ListEmployees)
                    {
                        if (selectedEmployee.IdEm == employee.IdEm)
                        {
                            selectedEmployee.ImageData = employee.ImageData;
                            selectedEmployee.NameEm = employee.NameEm;
                            selectedEmployee.DayOfBirth = employee.DayOfBirth;
                            selectedEmployee.PhoneNum = employee.PhoneNum;
                            selectedEmployee.AddressEm = employee.AddressEm;
                            selectedEmployee.Sex = employee.Sex;
                            selectedEmployee.NameRole = employee.NameRole;
                            selectedEmployee.Pass = employee.Pass;
                            break;
                        }
                    }
                    await StaffService.Ins.UpdateStaff(ListEmployees);
                }
                DetailWindow.Close();
                await LoadListEmployees();
            });

        }
        public async Task LoadListEmployees()
        {
            try
            {
                ListEmployees = new ObservableCollection<Employee>(await StaffService.Ins.GetAllEmployees());
                return;
            }

            catch (Exception)
            {
                throw;
            }
        }

        //Tìm kiếm
        private bool Filter(object item)
        {
            if (String.IsNullOrEmpty(SearchBox))
                return true;
            else
                return ((item as Employee).NameEm.IndexOf(SearchBox, StringComparison.OrdinalIgnoreCase) >= 0);
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
