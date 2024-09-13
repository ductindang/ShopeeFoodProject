using AutoMapper;
using BusinessLogicLayer.BaseRequests;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;
using BusinessLogicLayer.ServicesInterface;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.RepositoriesInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;

        public MenuService(IMenuRepository menuRepository, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MenuRequest>> GetAllMenus()
        {
            var menus = await _menuRepository.GetAll();
            return _mapper.Map<IEnumerable<MenuRequest>>(menus);
        }

        public async Task<MenuRequest> GetMenuById(int id)
        {
            var menu = await _menuRepository.GetById(id);
            return _mapper.Map<MenuRequest>(menu);
        }

        public Task<MenuRequest> InsertMenu(BaseMenu baseMenu)
        {
            throw new NotImplementedException();
        }

        public Task<MenuRequest> UpdateMenu(MenuRequest baseMenuy)
        {
            throw new NotImplementedException();
        }

        public Task<MenuRequest> DeleteMenuById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MenuProductDto>> GetProductMenusByMenu(int menuId)
        {
            var menuProducts = await _menuRepository.GetProductMenusByMenu(menuId);
            return _mapper.Map<IEnumerable<MenuProductDto>>(menuProducts);
        }

        public async Task<IEnumerable<MenuRequest>> GetMenusByStore(int storeId)
        {
            var menus = await _menuRepository.GetMenusByStore(storeId);
            return _mapper.Map<IEnumerable<MenuRequest>>(menus);
        }

    }
}
