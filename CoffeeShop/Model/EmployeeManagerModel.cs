using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
    public class EmployeeManagerModel
    {
        public static ObservableCollection<EmployeeModel> _DataBaseEmployee = new ObservableCollection<EmployeeModel>() ;
        public static ObservableCollection<EmployeeModel> GetEmployee()
        {
            return _DataBaseEmployee;
        }
        public static void AddEmployee(EmployeeModel employee)
        {
            _DataBaseEmployee.Add(employee);
        }
    }
}
