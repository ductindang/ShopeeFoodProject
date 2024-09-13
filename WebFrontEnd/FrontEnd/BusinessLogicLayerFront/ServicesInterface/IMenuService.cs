using BusinessLogicLayerFront.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerFront.ServicesInterface
{
    public interface IMenuService
    {
        Task<IEnumerable<MenuDto>> GetAllMenu();
        Task<MenuDto> GetMenuById(int id);
        Task<IEnumerable<MenuDto>> GetMenusByStore(int storeId);
        Task<IEnumerable<ProductDto>> GetProductsByMenu(int menuId);
    }
}
