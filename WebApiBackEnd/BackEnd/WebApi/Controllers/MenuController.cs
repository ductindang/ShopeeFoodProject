using BusinessLogicLayer.Requests;
using BusinessLogicLayer.ServicesInterface;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        private readonly IProductService _productService;

        public MenuController(IMenuService menuService, IProductService productService)
        {
            _menuService = menuService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuRequest>>> GetAllMenus()
        {
            var menus = await _menuService.GetAllMenus();
            return Ok(menus);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<MenuRequest>> GetMenuById(int id)
        {
            var menu = await _menuService.GetMenuById(id);
            if (menu == null)
            {
                return NotFound();
            }
            return Ok(menu);
        }

        [HttpGet]
        [Route("{menuId}/Products")]
        public async Task<ActionResult<ProductRequest>> GetProductsByMenu(int menuId)
        {
            var menuProducts = await _menuService.GetProductMenusByMenu(menuId);
            if (menuProducts == null)
            {
                return NotFound();
            }
            List<ProductRequest> products = new List<ProductRequest>();
            foreach (var mp in menuProducts)
            {
                var product = await _productService.GetProductById(mp.ProductId);
                if(product != null)
                {
                    products.Add(product);
                }
            }
            return Ok(products);
        }

        [HttpGet]
        [Route("Store/{storeId}")]
        public async Task<ActionResult<List<MenuRequest>>> GetMenusByStore(int storeId)
        {
            var menus = await _menuService.GetMenusByStore(storeId);
            List<MenuRequest> menuHaveProducts = new List<MenuRequest>();

            foreach (var menu in menus)
            {
                var menuProducts = await _menuService.GetProductMenusByMenu(menu.Id);

                if (menuProducts != null && menuProducts.Any())
                {
                    menuHaveProducts.Add(menu);
                }
            }

            if (!menuHaveProducts.Any())
            {
                return NotFound();
            }

            return Ok(menuHaveProducts);
        }
    }
}
