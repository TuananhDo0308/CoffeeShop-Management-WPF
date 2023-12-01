using CoffeeShop.Model;
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
                            Type = p.Type, 
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
                            // Update properties of existing product excluding Id
                            existingProduct.NameFood = product.NameFood;
                            existingProduct.ImageData = product.ImageData;
                            existingProduct.Type = product.Type;
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
                    // find the existing product in the database
                    var existingProduct = await context.Menus.FindAsync(productToDelete.Id);

                    if (existingProduct != null && productToDelete.Available == true)
                    {
                        // update the existing product's Available property
                        existingProduct.Available = false;

                        // Save changes to the database
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
