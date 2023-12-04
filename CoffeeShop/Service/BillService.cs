using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using CoffeeShop.Models;
using CoffeeShop.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Service
{
    public class BillService : ViewModelBase
    {
        private BillService() { }

        private static BillService _Ins;

        public static BillService Ins
        {
            get
            {
                if (_Ins == null)
                {
                    _Ins = new BillService();
                }
                return _Ins;
            }
            private set => _Ins = value;
        }
        public async Task AddBill(ObservableCollection<DetailMenuInCart> Cart, decimal totalPrice,string cusName)
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    Bill newBill = new Bill();
                    Employee User = App.MainUser;

                    newBill.IdBill = await context.Bills.MaxAsync(bill => (int?)bill.IdBill) ?? 0;
                    newBill.IdBill += 1;
                    newBill.NameCustomer=cusName;
                    newBill.IdEm = User.IdEm;
                    newBill.DayBill = DateTime.Now.Date;
                    newBill.Price = totalPrice;
                    newBill.StatusBill = "Pending";

                    context.Bills.Add(newBill);
                    await context.SaveChangesAsync();

                    foreach (var item in Cart)
                    {
                        Billdetail billdetail = new Billdetail();
                        billdetail.IdBill = newBill.IdBill;
                        billdetail.Id = item.Id;
                        billdetail.Soluong = item.Number;

                        context.Billdetails.Add(billdetail);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task UpdateStatus(FullBill selectedBill)
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    var bill = await context.Bills
                        .Where(s => s.IdBill == selectedBill.IdBill)
                        .FirstOrDefaultAsync();

                    if (bill != null)
                    {
                        bill.StatusBill = "Done";
                        await context.SaveChangesAsync(); // Save changes to the database
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public async Task<List<Item>> GetItemsForBill(int billId)
        {
            List<Item> items = new List<Item>();

            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    List<Billdetail> listBills = await context.Billdetails
                       .Where(p => p.IdBill == billId)
                       .ToListAsync();

                    List<Models.Menu> listMenu = await context.Menus
                       .Where(p => p.Available == true)
                       .ToListAsync();

                    foreach (var billDetail in listBills)
                    {
                        Models.Menu correspondingMenu = listMenu.FirstOrDefault(menu => menu.Id == billDetail.Id);

                        if (correspondingMenu != null)
                        {
                            items.Add(new Item(correspondingMenu.NameFood, billDetail.Soluong));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            return items;
        }
        public async Task<ObservableCollection<FullBill>> GetAllBillForStaff()
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    ObservableCollection<Employee> employees = new ObservableCollection<Employee>(await StaffService.Ins.GetAllEmployees());

                    List<Bill> listBills = await context.Bills
                        .Where(p => p.StatusBill == "Pending")
                        .Select(p => new Bill
                        {
                            NameCustomer = p.NameCustomer,
                            IdBill = p.IdBill,
                            IdEm = p.IdEm,
                            DayBill = p.DayBill,
                            Price = p.Price,
                            StatusBill = p.StatusBill,
                        })
                        .ToListAsync();

                    ObservableCollection<FullBill> observableBills = new ObservableCollection<FullBill>();

                    foreach (var item in listBills)
                    {
                        FullBill fullBill = new FullBill(item, employees);
                        observableBills.Add(fullBill);
                    }

                    return observableBills;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public async Task<ObservableCollection<FullBill>> GetAllBill()
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    ObservableCollection<Employee> employees = new ObservableCollection<Employee>(await StaffService.Ins.GetAllEmployees());
                    List<Bill> listBills = await context.Bills
                        .Select(p => new Bill
                        {
                            NameCustomer=p.NameCustomer,
                            IdBill= p.IdBill,
                            IdEm= p.IdEm,
                            DayBill = p.DayBill,
                            Price = p.Price,
                            StatusBill = p.StatusBill,
                        })
                        .ToListAsync();
                    listBills.Reverse();
                    ObservableCollection<FullBill> observableBills = new ObservableCollection<FullBill>();
                    foreach (var item in listBills)
                    {
                        FullBill fullBill=new FullBill(item,employees);
                        observableBills.Add(fullBill);
                    }

                    return observableBills;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
