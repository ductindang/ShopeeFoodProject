using BusinessLogicLayerFront.ServicesInterface;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetProductsByMenu(int menuId)
        {
            var products = await _menuService.GetProductsByMenu(menuId);
            if(products == null)
            {
                return NotFound();
            }
            return Json(products);
        }
    }
}
