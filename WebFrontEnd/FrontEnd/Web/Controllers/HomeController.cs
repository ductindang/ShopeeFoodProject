using BusinessLogicLayerFront.DTOs;
using BusinessLogicLayerFront.ServicesInterface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IProvinceService _provinceService;
        private readonly IDistrictService _districtService;
        private readonly IDiscountService _discountService;
        private readonly IStoreService _storeService;

        public HomeController(ILogger<HomeController> logger, 
            ICategoryService categoryService, 
            IProductService productService, 
            ISubCategoryService subCategoryService,
            IProvinceService provinceService,
            IDistrictService districtService,
            IDiscountService discountService,
            IStoreService storeService)
        {
            _logger = logger;
            _categoryService = categoryService;
            _productService = productService;
            _subCategoryService = subCategoryService;
            _provinceService = provinceService;
            _districtService = districtService;
            _discountService = discountService;
            _storeService = storeService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategories();
            var cateSessionJson = JsonConvert.SerializeObject(categories);
            HttpContext.Session.SetString("cateSession", cateSessionJson);


            var provinces = await _provinceService.GetAllProvinces();
            var provincesJson = JsonConvert.SerializeObject(provinces);
            HttpContext.Session.SetString("provSession", provincesJson);
            //if (id.HasValue)
            //{
            //    return RedirectToAction("Privacy", new { id = id.Value });
            //}
            return Redirect("/Home/Privacy?categoryId=1&provinceId=01");

            //return View();
        }

        public async Task<IActionResult> Privacy(int categoryId, string provinceId)
        {
            var category = await _categoryService.GetCategoryById(categoryId);
            HttpContext.Session.SetString("category", JsonConvert.SerializeObject(category));

            var province = await _provinceService.GetProvinceById(provinceId);
            HttpContext.Session.SetString("province", JsonConvert.SerializeObject(province));

            var storeAddressesInProvince = await _provinceService.GetStoreAddressesByProvince(provinceId);
            HttpContext.Session.SetString("storeAddressesInProvince", JsonConvert.SerializeObject(storeAddressesInProvince));

            var stores = await _storeService.GetStoresByCategoryId(category.Id);
            HttpContext.Session.SetString("storesByCategoryId", JsonConvert.SerializeObject(stores));


            var districts = await _districtService.GetDistrictsByProvince(provinceId);
            ViewData["districts"] = districts;
            HttpContext.Session.SetString("districts", JsonConvert.SerializeObject(districts));


            if (storeAddressesInProvince != null && stores != null)
            {
                var storeIdsInProvince = new HashSet<int>(storeAddressesInProvince.Select(p => p.StoreId));
                var commonStores = stores.Where(p => storeIdsInProvince.Contains(p.Id)).ToList();

                ViewData["stores"] = commonStores;
                HttpContext.Session.SetString("commonStores", JsonConvert.SerializeObject(commonStores));
            }
            else
            {
                ViewData["stores"] = new List<StoreDto>(); // Trả về danh sách rỗng nếu không có sản phẩm
                HttpContext.Session.SetString("commonStores", JsonConvert.SerializeObject(new List<StoreDto>()));
            }

            var subCates = await _subCategoryService.GetSubCategoriesByCategoryId(category.Id);
            ViewData["subCates"] = subCates;
            HttpContext.Session.SetString("subCates", JsonConvert.SerializeObject(subCates));

            return View(category);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
