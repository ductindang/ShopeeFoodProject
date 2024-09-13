using BusinessLogicLayer.BaseRequests;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.ServicesInterface
{
    public interface IMenuService
    {
        public Task<IEnumerable<MenuRequest>> GetAllMenus();
        public Task<MenuRequest> GetMenuById(int id);
        public Task<MenuRequest> InsertMenu(BaseMenu baseMenu);
        public Task<MenuRequest> UpdateMenu(MenuRequest baseMenuy);
        public Task<MenuRequest> DeleteMenuById(int id);
        Task<IEnumerable<MenuProductDto>> GetProductMenusByMenu(int menuId);
        Task<IEnumerable<MenuRequest>> GetMenusByStore(int storeId);
    }
}
