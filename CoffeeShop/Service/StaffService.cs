using CoffeeShop.Models;
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

        public async Task<(bool, string, Nhanvien)> Login(string username, string password)
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    var staff = await context.Nhanviens
                    .Where(s => s.Tendn == username && s.Matkhau == password)
                    .Select(s => new Nhanvien
                    {
                        Manv = s.Manv,
                        Hoten = s.Hoten,
                        Ngaysinh = s.Ngaysinh,
                        Diachi = s.Diachi,
                        Gioitinh = s.Gioitinh,
                        Sdt = s.Sdt,
                        Tendn = s.Tendn,
                        Matkhau = s.Matkhau,
                        Tenvt = s.Tenvt
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
