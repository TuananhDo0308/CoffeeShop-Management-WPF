using CoffeeShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Service
{
    public class StaffService
    {
        private StaffService() { }

        private static StaffService _ins;

        public static StaffService Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new StaffService();
                }
                return _ins;
            }
            private set => _ins = value;
        }
        public async Task AddEmployee(Employee newEmployee)
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    int lastId = await context.Employees.MaxAsync(Employee => (int?)Employee.IdEm) ?? 0;
                    newEmployee.IdEm = lastId + 1;
                    context.Employees.Add(newEmployee);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<(bool, string, Employee)> Login(string username, string password)
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    var staff = await context.Employees
                    .Where(s => s.Username == username && s.Pass == password && s.NameRole !="None")
                    .Select(s => new Employee
                    {
                        IdEm = s.IdEm,
                        ImageData = s.ImageData,
                        NameEm = s.NameEm,
                        DayOfBirth = s.DayOfBirth,
                        PhoneNum = s.PhoneNum,
                        AddressEm = s.AddressEm,
                        Sex = s.Sex,
                        NameRole = s.NameRole,
                        Username = s.Username,
                        Pass = s.Pass
                    })
                    .FirstOrDefaultAsync();

                    if (staff == null)
                    {
                        Console.WriteLine($"No staff found for username: {username} and password: {password}");
                        return (false, "Sai tài khoản hoặc mật khẩu", null);
                    }

                    return (true, "", staff);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return (false, "Lỗi hệ thống", null);
            }
        }
        public async Task<ObservableCollection<Employee>> GetAllEmployees()
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    List<Employee> employeeList = await context.Employees
                        .Where(p => p.NameRole != "Admin" && p.NameRole!="None")
                        .Select(p => new Employee
                        {
                            IdEm = p.IdEm,
                            Bills = p.Bills,
                            ImageData = p.ImageData,
                            NameEm = p.NameEm,
                            DayOfBirth = p.DayOfBirth,
                            PhoneNum = p.PhoneNum,
                            AddressEm = p.AddressEm,
                            Sex = p.Sex,
                            NameRole = p.NameRole,
                            Username = p.Username,
                            Pass = p.Pass
                        })
                        .ToListAsync();

                    ObservableCollection<Employee> employeeCollection = new ObservableCollection<Employee>(employeeList);

                    return employeeCollection;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public async Task UpdateStaff(ObservableCollection<Employee> listEmployees)
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    var existingEmployee = await context.Employees.ToListAsync();

                    foreach (var employee in listEmployees)
                    {
                        var existingProduct = existingEmployee.FirstOrDefault(p => p.IdEm == employee.IdEm);
                        if (existingProduct != null)
                        {
                            existingProduct.ImageData = employee.ImageData;
                            existingProduct.NameEm = employee.NameEm;
                            existingProduct.DayOfBirth = employee.DayOfBirth;
                            existingProduct.PhoneNum = employee.PhoneNum;
                            existingProduct.AddressEm = employee.AddressEm;
                            existingProduct.Sex = employee.Sex;
                            existingProduct.NameRole = employee.NameRole;
                            existingProduct.Pass = employee.Pass;
                        }
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task DeleteEmployee(Employee employeeToDelete)
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    var existingEmployee = await context.Employees.FindAsync(employeeToDelete.IdEm);

                    if (existingEmployee != null && employeeToDelete.NameRole != "None")
                    {
                        existingEmployee.NameRole = "None";

                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
