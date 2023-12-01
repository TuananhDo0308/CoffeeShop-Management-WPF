using CoffeeShop.Model;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<(bool, string, Employee)> Login(string username, string password)
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    var staff = await context.Employees
                    .Where(s => s.Username == username && s.Pass == password)
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
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                Console.WriteLine($"Database update exception: {ex.Message}");
                return (false, "Mất kết nối cơ sở dữ liệu", null);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return (false, "Lỗi hệ thống", null);
            }
        }

    }
}
