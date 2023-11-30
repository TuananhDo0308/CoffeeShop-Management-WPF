using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoffeeShop.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace CoffeeShop.Service
{


    public class MenuService
    {
        private MenuService() { }

        private static MenuService _Ins;

        public static MenuService Ins
        {
            get
            {
                if (_Ins == null)
                {
                    _Ins = new MenuService();
                }
                return _Ins;
            }
            private set => _Ins = value;
        }
        public async Task<List<Menu>> GetAllProduct()
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    List<Menu> productDtos = await context.Menus
                        .Select(p => new Menu
                        {
                            Id = p.Id,  
                            NameFood= p.NameFood,
                            ImageData = p.ImageData, 
                            Type = p.Type, 
                            Price = p.Price,
                            Description = p.Description, 
                            Billdetails = p.Billdetails 
                        })
                        .ToListAsync();

                    return productDtos;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public async Task UpdateProducts(List<Menu> newproducts)
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    var existingproducts = await context.Menus.ToListAsync();
                    context.Menus.RemoveRange(existingproducts);
                    await context.SaveChangesAsync();

                    context.Menus.AddRange(newproducts);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task AddProduct(Menu newproduct)
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    int lastmenuid = await context.Menus.MaxAsync(menu => (int?)menu.Id) ?? 0;
                    newproduct.Id = lastmenuid + 1;
                    context.Menus.Add(newproduct);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task DeleteProduct(Menu producttodelete)
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    // find the existing product in the database
                    var existingproduct = await context.Menus.FindAsync(producttodelete.Id);

                    if (existingproduct != null)
                    {
                        // remove the existing product
                        context.Menus.Remove(existingproduct);
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
