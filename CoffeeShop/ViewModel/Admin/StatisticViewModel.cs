using CoffeeShop.Models;
using CoffeeShop.Service;
using CoffeeShop.View.AdminView;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace CoffeeShop.ViewModel.Admin
{
    public class StatisticViewModel : ViewModelBase
    {
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
        public ICommand ChangeSelectedYear { get; set; }
        public ICommand ChangeSelectedMonth { get; set; }
        public ICommand ChangeSelectedCategory { get; set; }
        public ICommand firstLoad { get; set; }
        private SectionsCollection _TotalSalesOfTypesData;
        public SectionsCollection TotalSalesOfTypesData
        {
            get { return _TotalSalesOfTypesData; }
            set { _TotalSalesOfTypesData = value; OnPropertyChanged(); }
        }
        private List<TotalSales> _TotalDetailData;
        public List<TotalSales> TotalDetailData
        {
            get { return _TotalDetailData; }
            set { _TotalDetailData = value; OnPropertyChanged(); }
        }
        private SeriesCollection _TotalDetailColumnChart;
        public SeriesCollection TotalDetailColumnChart
        {
            get { return _TotalDetailColumnChart; }
            set { _TotalDetailColumnChart = value; OnPropertyChanged(); }
        }
        private SeriesCollection _TotalSalesPieChart;
        public SeriesCollection TotalSalesPieChart
        {
            get { return _TotalSalesPieChart; }
            set { _TotalSalesPieChart = value; OnPropertyChanged(); }
        }
        private List<TotalSales> _TotalSalesOfTypeData;
        public List<TotalSales> TotalSalesOfTypeData
        {
            get { return _TotalSalesOfTypeData; }
            set { _TotalSalesOfTypeData = value; OnPropertyChanged(); }
        }
        private string _SelectedCategory;
        public string SelectedCategory
        {
            get { return _SelectedCategory; }
            set { _SelectedCategory = value; OnPropertyChanged(); }
        }
        private List<string> _categories;
        public List<string> Categories
        {
            get { return _categories; }
            set { _categories = value; OnPropertyChanged(); }
        }
        private int _SelectedYear;
        public int SelectedYear
        {
            get { return _SelectedYear; }
            set { _SelectedYear = value; OnPropertyChanged(); }
        }
        private string _SelectedMonth;
        public string SelectedMonth
        {
            get { return _SelectedMonth; }
            set { _SelectedMonth = value; OnPropertyChanged(); }
        }
        private ObservableCollection<string> _NameOfFood;
        public ObservableCollection<string> NameOfFood
        {
            get { return _NameOfFood; }
            set { _NameOfFood = value; OnPropertyChanged(); }
        }
        public StatisticViewModel()
        {
            firstLoad = new RelayCommand<Page>((p) => { return true; }, async (p) =>
            {
                User = App.MainUser;
                NameStaff = User.NameEm;
                RoleStaff = User.NameRole;
                await LoadDataCategories();
            });
            ChangeSelectedYear = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                await LoadTotalSalesDetailColumnChart();
                await LoadTotalSalesOfTypePieChart();
            });
            ChangeSelectedMonth = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                await LoadTotalSalesDetailColumnChart();
                await LoadTotalSalesOfTypePieChart();
            });
            ChangeSelectedCategory = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                await LoadTotalSalesDetailColumnChart();
            });
        }
        public int indexOfCategories;
        public async Task LoadDataCategories()
        {
            try
            {
                Categories = new List<string>(await StatisticService.Ins.GetDataOfTypes());
                Categories.Add("All");
                indexOfCategories = Categories.Count() - 1;
                Categories.Sort();
                return;
            }

            catch (Exception)
            {
                throw;
            }
        }
        public async Task LoadTotalSalesDetailColumnChart()
        {
            try
            {
                if (SelectedCategory != null && SelectedCategory != "All")
                {
                    if (SelectedMonth != "All" && SelectedMonth != null)
                        TotalDetailData = await Task.Run(() => StatisticService.Ins.GetTotalSalesDetailByYearMonthAndType(SelectedCategory, SelectedYear, int.Parse(SelectedMonth)));
                    else
                        TotalDetailData = await Task.Run(() => StatisticService.Ins.GetTotalSalesDetailByYearAndType(SelectedCategory, SelectedYear));
                }
                else
                {
                    if (SelectedMonth != "All" && SelectedMonth != null)
                        TotalDetailData = await Task.Run(() => StatisticService.Ins.GetTotalSalesDetailInMonth(SelectedYear, int.Parse(SelectedMonth)));
                    else
                        TotalDetailData = await Task.Run(() => StatisticService.Ins.GetTotalSalesDetailInYear(SelectedYear));
                }
            }
            //catch (DbUpdateException ex) when (ex.InnerException is System.Data.SqlClient sqlException && (sqlException.Number == 2 || sqlException.Number == 53))
            //{
            //    Console.WriteLine(ex);
            //    MessageBoxCustom mb = new MessageBoxCustom("Lỗi", "Mất kết nối cơ sở dữ liệu", MessageType.Error, MessageButtons.OK);
            //    mb.ShowDialog();
            //}
            catch (Exception e)
            {
                throw (e);
                //Console.WriteLine(e);
                //MessageBoxCustom mb = new MessageBoxCustom("Lỗi", "Lỗi hệ thống", MessageType.Error, MessageButtons.OK);
                //mb.ShowDialog();
            }

            List<decimal> chartdata = new List<decimal>();
            NameOfFood = new ObservableCollection<string>();

            chartdata.Add(0);
            NameOfFood.Add("a");

            for (int i = 0; i < TotalDetailData.Count; i++)
            {
                chartdata.Add(TotalDetailData[i].Revenue / 1000000);
                NameOfFood.Add(TotalDetailData[i].FoodName);
            }

            TotalDetailColumnChart = new SeriesCollection
            {
                new ColumnSeries
                {
                    Values = new ChartValues<decimal>(chartdata),
                    Title = "Revenue"
                },
            };
        }
        public async Task LoadTotalSalesOfTypePieChart()
        {
            try
            {
                if (SelectedMonth != "All" && SelectedMonth != null)
                    TotalSalesOfTypeData = await StatisticService.Ins.GetTotalSalesByMonthInYearOfType(SelectedYear, int.Parse(SelectedMonth));
                else
                    TotalSalesOfTypeData = await Task.Run(() => StatisticService.Ins.GetTotalSalesByYearOfType(SelectedYear));
                TotalSalesPieChart = new SeriesCollection();
                for (int i = 0; i < TotalSalesOfTypeData.Count; i++)
                {
                    PieSeries p = new PieSeries
                    {
                        Values = new ChartValues<decimal> { TotalSalesOfTypeData[i].Revenue },
                        Title = TotalSalesOfTypeData[i].FoodType,
                    };
                    TotalSalesPieChart.Add(p);
                }
            }
            //catch (DbUpdateException ex) when (ex.InnerException is System.Data.SqlClient sqlException && (sqlException.Number == 2 || sqlException.Number == 53))
            //{
            //    Console.WriteLine(ex);
            //    MessageBoxCustom mb = new MessageBoxCustom("Lỗi", "Mất kết nối cơ sở dữ liệu", MessageType.Error, MessageButtons.OK);
            //    mb.ShowDialog();
            //}
            catch (Exception e)
            {
                throw (e);
                //Console.WriteLine(e);
                //MessageBoxCustom mb = new MessageBoxCustom("Lỗi", "Lỗi hệ thống", MessageType.Error, MessageButtons.OK);
                //mb.ShowDialog();
            }
        }
    }
}