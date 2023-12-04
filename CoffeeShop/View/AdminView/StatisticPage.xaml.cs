using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoffeeShop.View.AdminView
{
    /// <summary>
    /// Interaction logic for StatisticPage.xaml
    /// </summary>
    public partial class StatisticPage : Page
    {
        public StatisticPage()
        {
            InitializeComponent();
        }
        public void GetYearSource(ComboBox cbb)
        {
            if (cbb is null) return;

            List<int> l = new List<int>();

            int now = -1;
            for (int i = 2021; i <= System.DateTime.Now.Year; i++)
            {
                now++;
                l.Add(i);
            }
            cbb.ItemsSource = l;
            cbb.SelectedIndex = now;
        }
        public void GetMonthSource(ComboBox cbb)
        {
            if (cbb is null) return;

            List<string> l = new List<string>();

            l.Add("All");

            for (int i = 1; i <= 12; i++)
            {
                l.Add(i.ToString());
            }
            cbb.ItemsSource = l;
            cbb.SelectedIndex = 0;
        }

        private void cbMonths_Loaded(object sender, RoutedEventArgs e)
        {
            GetMonthSource(cbMonths);
            return;
        }

        private void cbYears_Loaded(object sender, RoutedEventArgs e)
        {
            GetYearSource(cbYears);
            return;
        }
    }
}
