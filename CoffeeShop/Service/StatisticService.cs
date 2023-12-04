using CoffeeShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Collections.Generic;
using CoffeeShop.ViewModel;
using System.ComponentModel;

namespace CoffeeShop.Service
{
    public class StatisticService
    {
        private StatisticService() { }
        private static StatisticService _ins;

        public static StatisticService Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new StatisticService();
                }
                return _ins;
            }
            private set => _ins = value;
        }
        public async Task<List<string>> GetDataOfTypes()
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    var types = await context.Types
                        .Select(t => t.Type1)
                        //.OrderBy(type => type)
                        .ToListAsync();

                    return types;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        // piechart: don't have month
        public async Task<List<TotalSales>> GetTotalSalesByYearOfType(int _year)
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    var totalSales = await context.Menus
                        .Join(context.Types, m => m.IdType, t => t.Id, (m, t) => new { Menu = m, Type = t })
                        .Join(context.Billdetails, mt => mt.Menu.Id, bd => bd.Id, (mt, bd) => new { MenuType = mt, BillDetail = bd })
                        .Join(context.Bills, mtb => mtb.BillDetail.IdBill, b => b.IdBill, (mtb, b) => new { MenuTypeBill = mtb, Bill = b })
                        .Where(result => result.Bill.DayBill.Year == _year)
                        .GroupBy(result => new
                        {
                            //FoodType = 
                            result.MenuTypeBill.MenuType.Type.Type1
                            //FoodName = result.MenuTypeBill.MenuType.Menu.NameFood,
                            //Year = result.Bill.DayBill.Year
                        })
                        .Select(grouped => new TotalSales
                        {
                            FoodType = grouped.Key.Type1,
                            Revenue = grouped.Sum(x => x.MenuTypeBill.BillDetail.Soluong * x.MenuTypeBill.MenuType.Menu.Price)
                        })
                        .ToListAsync();

                    return totalSales;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //piechart: both month and year
        public async Task<List<TotalSales>> GetTotalSalesByMonthInYearOfType(int _year, int _month)
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    var totalSales = await context.Menus
                        .Join(context.Types, m => m.IdType, t => t.Id, (m, t) => new { Menu = m, Type = t })
                        .Join(context.Billdetails, mt => mt.Menu.Id, bd => bd.Id, (mt, bd) => new { MenuType = mt, BillDetail = bd })
                        .Join(context.Bills, mtb => mtb.BillDetail.IdBill, b => b.IdBill, (mtb, b) => new { MenuTypeBill = mtb, Bill = b })
                        .Where(result => result.Bill.DayBill.Year == _year && result.Bill.DayBill.Month == _month)
                        .GroupBy(result => new
                        {
                            //FoodType = 
                            result.MenuTypeBill.MenuType.Type.Type1,
                            //FoodName = result.MenuTypeBill.MenuType.Menu.NameFood,
                            //Year = result.Bill.DayBill.Year
                        })
                        .Select(grouped => new TotalSales
                        {
                            FoodType = grouped.Key.Type1,
                            //FoodName = grouped.Key.FoodName,
                            //Year = grouped.Key.Year,
                            Revenue = grouped.Sum(x => x.MenuTypeBill.BillDetail.Soluong * x.MenuTypeBill.MenuType.Menu.Price)
                        })
                        .ToListAsync();

                    return totalSales;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //columnchart: don't have typefood and month
        public async Task<List<TotalSales>> GetTotalSalesDetailInYear(int _year)
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    var totalSales = await context.Menus
                        .Join(context.Types, m => m.IdType, t => t.Id, (m, t) => new { Menu = m, Type = t })
                        .Join(context.Billdetails, mt => mt.Menu.Id, bd => bd.Id, (mt, bd) => new { MenuType = mt, BillDetail = bd })
                        .Join(context.Bills, mtb => mtb.BillDetail.IdBill, b => b.IdBill, (mtb, b) => new { MenuTypeBill = mtb, Bill = b })
                        .Where(result => result.Bill.DayBill.Year == _year)
                        .GroupBy(result => new
                        {
                            result.MenuTypeBill.MenuType.Type.Type1,
                            result.MenuTypeBill.MenuType.Menu.NameFood
                        })
                        .Select(grouped => new TotalSales
                        {
                            FoodType = grouped.Key.Type1,
                            FoodName = grouped.Key.NameFood,
                            Revenue = grouped.Sum(x => x.MenuTypeBill.BillDetail.Soluong * x.MenuTypeBill.MenuType.Menu.Price)
                        })
                        .ToListAsync();

                    return totalSales;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //columnchart: don't have typefood
        public async Task<List<TotalSales>> GetTotalSalesDetailInMonth(int _year, int _month)
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    var totalSales = await context.Menus
                        .Join(context.Types, m => m.IdType, t => t.Id, (m, t) => new { Menu = m, Type = t })
                        .Join(context.Billdetails, mt => mt.Menu.Id, bd => bd.Id, (mt, bd) => new { MenuType = mt, BillDetail = bd })
                        .Join(context.Bills, mtb => mtb.BillDetail.IdBill, b => b.IdBill, (mtb, b) => new { MenuTypeBill = mtb, Bill = b })
                        .Where(result => result.Bill.DayBill.Year == _year && result.Bill.DayBill.Month == _month)
                        .GroupBy(result => new
                        {
                            result.MenuTypeBill.MenuType.Type.Type1,
                            result.MenuTypeBill.MenuType.Menu.NameFood
                        })
                        .Select(grouped => new TotalSales
                        {
                            FoodType = grouped.Key.Type1,
                            FoodName = grouped.Key.NameFood,
                            Revenue = grouped.Sum(x => x.MenuTypeBill.BillDetail.Soluong * x.MenuTypeBill.MenuType.Menu.Price)
                        })
                        .ToListAsync();

                    return totalSales;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //columnchart: don't have month
        public async Task<List<TotalSales>> GetTotalSalesDetailByYearAndType(string _foodType, int _year)
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    var totalSales = await context.Menus
                        .Join(context.Types, m => m.IdType, t => t.Id, (m, t) => new { Menu = m, Type = t })
                        .Join(context.Billdetails, mt => mt.Menu.Id, bd => bd.Id, (mt, bd) => new { MenuType = mt, BillDetail = bd })
                        .Join(context.Bills, mtb => mtb.BillDetail.IdBill, b => b.IdBill, (mtb, b) => new { MenuTypeBill = mtb, Bill = b })
                        .Where(result => result.MenuTypeBill.MenuType.Type.Type1 == _foodType && result.Bill.DayBill.Year == _year)
                        .GroupBy(result => new
                        {
                            //FoodType = 
                            result.MenuTypeBill.MenuType.Type.Type1,
                            result.MenuTypeBill.MenuType.Menu.NameFood
                            //FoodName = result.MenuTypeBill.MenuType.Menu.NameFood,
                            //Year = result.Bill.DayBill.Year
                        })
                        .Select(grouped => new TotalSales
                        {
                            FoodType = grouped.Key.Type1,
                            FoodName = grouped.Key.NameFood,
                            //Year = grouped.Key.Year,
                            Revenue = grouped.Sum(x => x.MenuTypeBill.BillDetail.Soluong * x.MenuTypeBill.MenuType.Menu.Price)
                        })
                        .ToListAsync();

                    return totalSales;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //columnchart: all
        public async Task<List<TotalSales>> GetTotalSalesDetailByYearMonthAndType(string _foodType, int _year, int _month)
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    var totalSales = await context.Menus
                        .Join(context.Types, m => m.IdType, t => t.Id, (m, t) => new { Menu = m, Type = t })
                        .Join(context.Billdetails, mt => mt.Menu.Id, bd => bd.Id, (mt, bd) => new { MenuType = mt, BillDetail = bd })
                        .Join(context.Bills, mtb => mtb.BillDetail.IdBill, b => b.IdBill, (mtb, b) => new { MenuTypeBill = mtb, Bill = b })
                        .Where(result => result.MenuTypeBill.MenuType.Type.Type1 == _foodType && result.Bill.DayBill.Year == _year && result.Bill.DayBill.Month == _month)
                        .GroupBy(result => new
                        {
                            //FoodType = 
                            result.MenuTypeBill.MenuType.Type.Type1,
                            result.MenuTypeBill.MenuType.Menu.NameFood
                            //FoodName = result.MenuTypeBill.MenuType.Menu.NameFood,
                            //Year = result.Bill.DayBill.Year
                        })
                        .Select(grouped => new TotalSales
                        {
                            FoodType = grouped.Key.Type1,
                            FoodName = grouped.Key.NameFood,
                            //Year = grouped.Key.Year,
                            Revenue = grouped.Sum(x => x.MenuTypeBill.BillDetail.Soluong * x.MenuTypeBill.MenuType.Menu.Price)
                        })
                        .ToListAsync();

                    return totalSales;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}