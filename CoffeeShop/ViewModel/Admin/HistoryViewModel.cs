using CoffeeShop.Models;
using CoffeeShop.Service;
using CoffeeShop.View.AdminView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace CoffeeShop.ViewModel.Admin
{
    public class HistoryViewModel:ViewModelBase
    {
        public Employee _User;
        public Employee User
        {
            get { return _User; }
            set { _User = value; OnPropertyChanged(); }
        }
        public Window detailWindow { get; set; }
        private ListView listBox;
        public ListView ListBox
        {
            get => listBox;
            set
            {
                listBox = value;
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
        private DateTime? filterDate;
        public DateTime? FilterDate
        {
            get => filterDate;
            set
            {
                filterDate = value;
                OnPropertyChanged();
            }
        }
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
        public ICommand findNameCus { get; set; }
        public ICommand filterByDate { get; set; }
        public ICommand detailView { get; set; }
        public ICommand getDetailWindow { get; set; }
        public ICommand exitDetailWindow { get; set; }

        public ICommand MouseLeftButtonDownWindow { get; set; }


        public HistoryViewModel() 
        {
            MouseLeftButtonDownWindow = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null)
                {
                    p.DragMove();
                }
            });
            firstLoad = new RelayCommand<ListView>((p) => { return true; }, async (p) =>
            {
                
                 await LoadListProduct();
                User=App.MainUser;
                ListBox=p;
            });
            getDetailWindow = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
                detailWindow=p;
            });
            exitDetailWindow = new RelayCommand<Button>((p) => { return true; }, async (p) =>
            {
                detailWindow.Close();
            });
            detailView = new RelayCommand<ListView>((p) => { return true; }, async (p) =>
            {
                if (SelectedBill!=null)
                {
                    DetailHistory detailHistory = new DetailHistory();
                    detailHistory.ShowDialog();
                }
            });
            findNameCus = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListBox.ItemsSource);
                view.Filter = Filter;
                CollectionViewSource.GetDefaultView(ListBox.ItemsSource).Refresh();
            });
            filterByDate = new RelayCommand<DatePicker>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListBox.ItemsSource);
                view.Filter = FilterByDate;
                CollectionViewSource.GetDefaultView(ListBox.ItemsSource).Refresh();
            });
        }

        public async Task LoadListProduct()
        {
            try
            {
                Bills = new ObservableCollection<FullBill>(await BillService.Ins.GetAllBill());
                return;
            }

            catch (Exception)
            {
                throw;
            }
        }
        private bool Filter(object item)
        {
            if (String.IsNullOrEmpty(SearchBox))
                return true;
            else
                return (((item as FullBill)?.NameCustomer ?? string.Empty).IndexOf(SearchBox, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private bool FilterByDate(object item)
        {
            if (!FilterDate.HasValue)
                return true;

            if (item is FullBill fullBill)
            {
                // Convert chuỗi ngày từ FullBill thành DateTime
                DateTime itemDate = DateTime.ParseExact(fullBill.DayBill, "dd/MM/yyyy", null);

                // So sánh ngày từ FullBill với ngày đã chọn
                return itemDate.Date == FilterDate.Value.Date;
            }

            return false;
        }
    }
}
