using BusinessLogicLayerFront.DTOs;
using BusinessLogicLayerFront.Services;
using BusinessLogicLayerFront.ServicesInterface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;
        private readonly IProvinceService _provinceService;
        private readonly IDistrictService _districtService;
        private readonly ISubCategoryService _subCategoryService;

        public StoreController(IStoreService storeService,
            IProvinceService provinceService,
            IDistrictService districtService,
            ISubCategoryService subCategoryService)
        {
            _storeService = storeService;
            _provinceService = provinceService;
            _districtService = districtService;
            _subCategoryService = subCategoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetStore(int storeId)
        {
            var store = await _storeService.GetStoreById(storeId);

            if (store == null)
            {
                return NotFound(); // Return a 404 if the store is not found
            }

            return Json(store); // Return the store object as JSON
        }


        public async Task<IActionResult> SearchStoresByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Json(new List<StoreDto>()); // Return an empty list if the name is invalid
            }

            try
            {
                //var productsInProvince = ViewData["products"] as List<ProductDto>;
                //var products = await _productService.GetProductsByName(name);

                var commonStoresJson = HttpContext.Session.GetString("commonStores");
                var storesInProvince = JsonConvert.DeserializeObject<List<StoreDto>>(commonStoresJson);

                var stores = storesInProvince.Where(pro => pro.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
                if (stores != null)
                {
                    return Json(stores.Take(5)); // Return only the first 5 products
                }
                return Json(stores);
            }
            catch (Exception ex)
            {
                // Handle any errors
                Console.WriteLine($"Error searching for products: {ex.Message}");
                return StatusCode(500, "An error occurred while searching for products."); // Return 500 error if there's an issue
            }
        }


        public async Task<IActionResult> Details(int id)
        {
            var store = await _storeService.GetStoreWithDetailAddress(id);
            if (store == null)
            {
                return null;
            }
            return View(store);
        }


        public async Task<IActionResult> LoadStore(int page = 1, int storePerPage = 5, List<string> selectedDistricts = null)
        {
            var categoryJson = HttpContext.Session.GetString("category");
            var category = JsonConvert.DeserializeObject<CategoryDto>(categoryJson);
            var newCategoryId = category != null ? category.Id : 1;

            var provinceJson = HttpContext.Session.GetString("province");
            var province = JsonConvert.DeserializeObject<ProvinceDto>(provinceJson);
            var provinceId = province != null ? province.Id : "01";

            var storesInProvince = await _provinceService.GetStoresByProvince(provinceId);
            var allStores = await _storeService.GetStoresByCategoryId(newCategoryId);

            // Take all the same store between allStores and storesInProvince
            var commonStores = allStores.Where(p => storesInProvince.Any(pip => pip.Id == p.Id)).ToList();

            // Take stores for current page

            List<StoreDetailDto> storeDetails = new List<StoreDetailDto>();
            if (selectedDistricts == null)
            {
                var stores = commonStores.Skip((page - 1) * storePerPage).Take(storePerPage).ToList();
                ViewBag.TotalPages = (int)Math.Ceiling(commonStores.Count() / (double)storePerPage);
                ViewBag.CurrentPage = page;
                foreach (var store in stores)
                {
                    var sto = await _storeService.GetStoreWithDetailAddress(store.Id);
                    if (sto != null)
                    {
                        sto.StoreId = store.Id;
                        storeDetails.Add(sto);
                    }
                }
                ViewData["selectedDistricts"] = new List<string>();
                ViewBag.StoreCount = commonStores.Count();
            }
            else
            {
                var storesInDistrict = new List<StoreDto>();
                // Change data type depends on product id type
                var uniqueStoreIds = new HashSet<int>();

                foreach (string districtId in selectedDistricts)
                {
                    var stos = await _districtService.GetStoresByDistrict(districtId, newCategoryId);
                    if (stos != null)
                    {
                        foreach (var store in stos)
                        {
                            // If product id hasn't had in HashSet, add into list and HashSet
                            if (uniqueStoreIds.Add(store.Id))
                            {
                                storesInDistrict.Add(store);
                            }
                        }
                    }

                }
                var commonStores2 = commonStores.Where(p => storesInDistrict.Any(pid => pid.Id == p.Id)).ToList();
                var stores = commonStores2.Skip((page - 1) * storePerPage).Take(storePerPage).ToList();
                ViewBag.TotalPages = (int)Math.Ceiling(commonStores2.Count() / (double)storePerPage);
                ViewBag.CurrentPage = page;

                foreach (var store in stores)
                {
                    var sto = await _storeService.GetStoreWithDetailAddress(store.Id);
                    if (sto != null)
                    {
                        sto.StoreId = store.Id;
                        storeDetails.Add(sto);
                    }
                }
                ViewData["selectedDistricts"] = selectedDistricts;
                ViewBag.StoreCount = commonStores2.Count();
            }
            return PartialView("LoadStore", storeDetails);
        }


        public async Task<IActionResult> GetStoreWithDetailAddress(int id)
        {
            try
            {
                var store = await _storeService.GetStoreWithDetailAddress(id);
                store.StoreId = id;
                return Json(store);
            }
            catch (Exception ex)
            {
                // Handle any errors
                Console.WriteLine($"Error searching for products: {ex.Message}");
                return StatusCode(500, "An error occurred while searching for products."); // Return 500 error if there's an issue
            }
        }


        public async Task<IActionResult> GetStoresByDistrict(string districtId, int page, int pageSize)
        {
            var categoryJson = HttpContext.Session.GetString("category");
            var category = JsonConvert.DeserializeObject<CategoryDto>(categoryJson);

            var categoryId = category != null ? category.Id : 1;

            var stores = await _districtService.GetStoresByDistrict(districtId, categoryId);
            List<StoreDetailDto> storeDetails = new List<StoreDetailDto>();

            if (stores.Any() || stores != null)
            {
                foreach (var store in stores)
                {
                    var sto = await _storeService.GetStoreWithDetailAddress(store.Id);
                    if (sto != null)
                    {
                        sto.StoreId = store.Id;
                        storeDetails.Add(sto);
                    }
                }
            }

            var paginatedStore = storeDetails
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Json(paginatedStore);
        }


        public async Task<IActionResult> StoresBySubCategory(int subCategoryId)
        {
            Console.WriteLine("Sub Id: " + subCategoryId);
            var subCategory = await _subCategoryService.GetSubCategoryById(subCategoryId);
            return View(subCategory);
        }

        public async Task<IActionResult> GetStoresBySubCategory(int page, int pageSize, int subCategoryId = 1)
        {
            var categoryJson = HttpContext.Session.GetString("category");
            var category = JsonConvert.DeserializeObject<CategoryDto>(categoryJson);
            var newCategoryId = category != null ? category.Id : 1;

            var provinceJson = HttpContext.Session.GetString("province");
            var province = JsonConvert.DeserializeObject<ProvinceDto>(provinceJson);
            var provinceId = province != null ? province.Id : "01";

            var storesInProvince = await _provinceService.GetStoresByProvince(provinceId);
            var allStores = await _storeService.GetStoresByCategoryId(newCategoryId);
            var storesInSubCategory = await _storeService.GetStoresBySubCategory(subCategoryId);

            // Take all the same product between allProducts and productsInProvince
            var commonStores = allStores.Where(p => storesInProvince.Any(pip => pip.Id == p.Id)).ToList();
            var commonStores2 = new List<StoreDto>();

            if (subCategoryId == 1)
            {
                commonStores2 = commonStores;
            }
            else
            {
                commonStores2 = storesInSubCategory.Where(p => commonStores.Any(cp => cp.Id == p.Id)).ToList();
            }

            // Take products for current page
            var stores = commonStores2.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.TotalPages = (int)Math.Ceiling(commonStores2.Count() / (double)pageSize);
            ViewBag.CurrentPage = page;

            List<StoreDetailDto> storeDetails = new List<StoreDetailDto>();

            foreach (var store in stores)
            {
                var sto = await _storeService.GetStoreWithDetailAddress(store.Id);
                if (sto != null)
                {
                    sto.StoreId = store.Id;
                    storeDetails.Add(sto);
                }
            }

            ViewBag.StoreCount = storeDetails.Count();

            return PartialView("LoadStore", storeDetails);
        }
    }
}
