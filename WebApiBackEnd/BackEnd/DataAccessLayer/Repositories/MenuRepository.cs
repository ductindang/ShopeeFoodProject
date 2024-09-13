using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.RepositoriesInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository
    {
        private readonly ApplicationDbContext _context;
        public MenuRepository(ApplicationDbContext context) : base(context) {
            _context = context;
        }

        public async Task<IEnumerable<MenuProduct>> GetProductMenusByMenu(int menuId)
        {
            var menuProducts =  await _context.MenuProducts.Where(m => m.MenuId == menuId).ToListAsync();
            return menuProducts;
        }

        public async Task<IEnumerable<Menu>> GetMenusByStore(int storeId)
        {
            var menus = await _context.Menus.Where(m => m.StoreId == storeId).ToListAsync();
            return menus;
        }
    }
}
