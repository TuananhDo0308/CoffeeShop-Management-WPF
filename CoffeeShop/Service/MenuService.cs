using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace CoffeeShop.Service { 


    public class MenuService
    {
        private MenuService() { }

    private static MenuService _ins;

    public static MenuService Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = new MenuService();
            }
            return _ins;
        }
        private set => _ins = value;
    }

    public async Task<List<Menu>> GetAllProduct()
        {
            try
            {
                using (var context = new COFFEESHOPContext())
                {
                    List<Menu> menu = await context.Menus.ToListAsync();
                    return menu;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
}
}
