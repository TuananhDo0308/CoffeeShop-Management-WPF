using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CoffeeShop.ViewModel;


namespace CoffeeShop.Service
{


    public class MenuService:ViewModelBase
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
                        .Where(p => p.Available == true)
                        .Select(p => new Menu
                        {
                            Id = p.Id,  
                            NameFood= p.NameFood,
                            ImageData = p.ImageData, 
                            IdType = p.IdType, 
                            Price = p.Price,
                            Description = p.Description, 
                            Billdetails = p.Billdetails ,
                            Available= p.Available
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

        public async Task<List<Models.Type>> GetAllType()
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    List<Models.Type> productDtos = await context.Types
                        .Where(p => p.Available == true)
                        .Select(p => new Models.Type
                        {
                            Id = p.Id,
                            Available = p.Available,
                            Type1 = p.Type1,
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


        public async Task UpdateProducts(List<Menu> newProducts)
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    var existingProducts = await context.Menus.ToListAsync();

                    foreach (var product in newProducts)
                    {
                        var existingProduct = existingProducts.FirstOrDefault(p => p.Id == product.Id);
                        if (existingProduct != null)
                        {
                            existingProduct.NameFood = product.NameFood;
                            existingProduct.ImageData = product.ImageData;
                            existingProduct.IdType = product.IdType;
                            existingProduct.Price = product.Price;
                            existingProduct.Description = product.Description;
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
        public async Task DeleteProduct(Menu productToDelete)
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    var existingProduct = await context.Menus.FindAsync(productToDelete.Id);

                    if (existingProduct != null && productToDelete.Available == true)
                    {
                        existingProduct.Available = false;

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
