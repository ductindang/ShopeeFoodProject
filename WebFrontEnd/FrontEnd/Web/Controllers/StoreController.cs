using BusinessLogicLayerFront.DTOs;
using BusinessLogicLayerFront.Services;
using BusinessLogicLayerFront.ServicesInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;

namespace Web.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;
        private readonly IProvinceService _provinceService;
        private readonly IDistrictService _districtService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IMenuService _menuService;
        private readonly IUserAddressService _userAddressService;

        public StoreController(IStoreService storeService,
            IProvinceService provinceService,
            IDistrictService districtService,
            ISubCategoryService subCategoryService,
            IMenuService menuService,
            IUserAddressService userAddressService)
        {
            _storeService = storeService;
            _provinceService = provinceService;
            _districtService = districtService;
            _subCategoryService = subCategoryService;
            _menuService = menuService;
            _userAddressService = userAddressService;
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
                var commonStoresJson = HttpContext.Session.GetString("commonStores");
                var storesInProvince = JsonConvert.DeserializeObject<List<StoreDto>>(commonStoresJson);

                var stores = storesInProvince
                    .Where(store => store.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                    .Take(5) // Return only the first 5 stores
                    .ToList();

                return Json(stores);
            }
            catch (Exception ex)
            {
                // Handle any errors
                Console.WriteLine($"Error searching for stores: {ex.Message}");
                return StatusCode(500, "An error occurred while searching for stores."); // Return 500 error if there's an issue
            }
        }


        public async Task<IActionResult> Details(int id)
        {
            var userCheckJson = HttpContext.Session.GetString("userCheck");
            if (!string.IsNullOrEmpty(userCheckJson))
            {
                var user = JsonConvert.DeserializeObject<UserDto>(userCheckJson);
                var userAddresses = await _userAddressService.GetAllUserAddressesByUser(user.Id);
                var userAddressDetails = new List<UserAddressDetailDto>();

                foreach (var address in userAddresses)
                {
                    var userAddressDetail = await _userAddressService.GetUserAddressDetail(address.Id);
                    if (userAddressDetail != null)
                    {
                        userAddressDetail.UserAddressId = address.Id;
                        userAddressDetails.Add(userAddressDetail);
                    }
                }
                HttpContext.Session.SetString("userAddressDetail", userAddressDetails != null ? JsonConvert.SerializeObject(userAddressDetails) : string.Empty);
            }


            var provinceJson = HttpContext.Session.GetString("province");
            var province = JsonConvert.DeserializeObject<ProvinceDto>(provinceJson);
            var provinceId = province != null ? province.Id : "01";

            var storesInProvince = await _provinceService.GetStoreAddressesByProvince(provinceId);

            var menusInStore = await _menuService.GetMenusByStore(id);
            HttpContext.Session.SetString("menusInStore", menusInStore != null ? JsonConvert.SerializeObject(menusInStore) : string.Empty);

            var store = new StoreDetailDto();
            foreach (var stInPro in storesInProvince)
            {
                store = await _storeService.GetStoreWithDetailAddress(stInPro.Id, id, stInPro.WardId);
                if (store != null)
                {
                    store.StoreId = id;
                    break;
                }
            }

            var productsInStore = new List<ProductDto>();
            if(menusInStore != null && menusInStore.Any())
            {
                foreach (var menu in menusInStore)
                {
                    var products = await _menuService.GetProductsByMenu(menu.Id);
                    if (products != null && products.Any())
                    {
                        productsInStore.AddRange(products);
                    }
                }
            }

            if (productsInStore.Any())
            {
                // Get the product with the highest price
                var mostExpensiveProduct = productsInStore.OrderByDescending(p => p.Price).FirstOrDefault();

                // Get the product with the lowest price
                var cheapestProduct = productsInStore.OrderBy(p => p.Price).FirstOrDefault();

                // Store the products in the session
                HttpContext.Session.SetString("mostExpensiveProduct", mostExpensiveProduct != null ? JsonConvert.SerializeObject(mostExpensiveProduct) : string.Empty);
                HttpContext.Session.SetString("cheapestProduct", cheapestProduct != null ? JsonConvert.SerializeObject(cheapestProduct) : string.Empty);
            }

            return View(store);
        }

        public async Task<IActionResult> LoadStore(int page = 1, int storePerPage = 5, List<string> selectedDistricts = null)
        {
            var categoryJson = HttpContext.Session.GetString("category");
            var category = JsonConvert.DeserializeObject<CategoryDto>(categoryJson);
            var newCategoryId = category?.Id ?? 1;

            var provinceJson = HttpContext.Session.GetString("province");
            var province = JsonConvert.DeserializeObject<ProvinceDto>(provinceJson);
            var provinceId = province?.Id ?? "01";

            var storeAddressesInProvinceJson = HttpContext.Session.GetString("storeAddressesInProvince");
            var storeAddressesInProvince = JsonConvert.DeserializeObject<IEnumerable<StoreAddressDto>>(storeAddressesInProvinceJson) ?? Enumerable.Empty<StoreAddressDto>();

            var allStoresByCategoryJson = HttpContext.Session.GetString("storesByCategoryId");
            var allStores = JsonConvert.DeserializeObject<IEnumerable<StoreDto>>(allStoresByCategoryJson) ?? Enumerable.Empty<StoreDto>();

            var storeAddressesInProvinceLookup = storeAddressesInProvince.ToDictionary(p => p.Id);
            var commonStores = allStores.Where(p => storeAddressesInProvinceLookup.ContainsKey(p.Id)).ToList();

            // Calculate pagination details
            var totalStores = commonStores.Count;
            ViewBag.TotalPages = (int)Math.Ceiling(totalStores / (double)storePerPage);
            ViewBag.CurrentPage = page;

            IEnumerable<StoreDto> filteredStores;

            if (selectedDistricts == null || !selectedDistricts.Any())
            {
                filteredStores = commonStores.Skip((page - 1) * storePerPage).Take(storePerPage).ToList();
                ViewData["selectedDistricts"] = new List<string>();
                ViewBag.StoreCount = commonStores.Count();
            }
            else
            {
                var uniqueStoreIds = new HashSet<int>();
                foreach (var districtId in selectedDistricts)
                {
                    var storesInDistrict = await _districtService.GetStoresByDistrict(districtId, newCategoryId);
                    if (storesInDistrict != null)
                    {
                        foreach (var store in storesInDistrict)
                        {
                            uniqueStoreIds.Add(store.Id);
                        }
                    }
                }
                var commonStores2 = commonStores.Where(p => uniqueStoreIds.Contains(p.Id)).ToList();
                ViewData["selectedDistricts"] = selectedDistricts;

                ViewBag.TotalPages = (int)Math.Ceiling(commonStores2.Count / (double)storePerPage);
                ViewBag.CurrentPage = page;

                ViewBag.StoreCount = commonStores2.Count();

                filteredStores = commonStores2.Skip((page - 1) * storePerPage).Take(storePerPage).ToList();
            }

            // Fetch store details concurrently
            var storeDetailTasks = filteredStores.Select(async store =>
            {
                var address = storeAddressesInProvinceLookup.Values.FirstOrDefault(sa => sa.StoreId == store.Id);
                var storeDetail = address != null
                    ? await _storeService.GetStoreWithDetailAddress(address.Id, store.Id, address.WardId)
                    : null;

                // Ensure the Id is correctly set
                if (storeDetail != null)
                {
                    storeDetail.StoreId = store.Id;
                }

                return storeDetail;
            }).ToList();

            var storeDetailResults = await Task.WhenAll(storeDetailTasks);

            var storeDetails = storeDetailResults.Where(sto => sto != null).ToList();

            return PartialView("LoadStore", storeDetails);
        }




        public async Task<IActionResult> GetStoreWithDetailAddress(int id)
        {
            try
            {
                var storeAddressesInProvinceJson = HttpContext.Session.GetString("storeAddressesInProvince");
                var storeAddressesInProvince = JsonConvert.DeserializeObject<IEnumerable<StoreAddressDto>>(storeAddressesInProvinceJson);

                var storeDetail = new StoreDetailDto();

                foreach (var stInPro in storeAddressesInProvince)
                {
                    var store = await _storeService.GetStoreWithDetailAddress(stInPro.Id, id, stInPro.WardId);
                    if(store != null)
                    {
                        store.StoreId = id;
                        storeDetail = store;
                        return Json(storeDetail);
                    }
                }

                return Json(storeDetail);
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
            var categoryId = category?.Id ?? 1;

            var stores = await _districtService.GetStoresByDistrict(districtId, categoryId);
            if (stores == null || !stores.Any())
            {
                return Json(new List<StoreDetailDto>()); // Early exit if no stores
            }

            var storeAddressesInProvinceJson = HttpContext.Session.GetString("storeAddressesInProvince");
            var storeAddressesInProvince = JsonConvert.DeserializeObject<IEnumerable<StoreAddressDto>>(storeAddressesInProvinceJson);

            var storeDetailTasks = stores
                .SelectMany(store => storeAddressesInProvince
                    .Select(async stInPro =>
                    {
                        var sto = await _storeService.GetStoreWithDetailAddress(stInPro.Id, store.Id, stInPro.WardId);
                        if (sto != null)
                        {
                            sto.StoreId = store.Id;
                            return sto;
                        }
                        return null;
                    })
                ).ToList();

            var storeDetails = (await Task.WhenAll(storeDetailTasks))
                .Where(sto => sto != null)
                .ToList();

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

        public async Task<IActionResult> GetStoresBySubCategory(int page,
            int pageSize,
            int subCategoryId = 1,
            List<string> selectedDistricts = null,
            List<int> selectedSubCates = null)
        {
            // Retrieve and deserialize session data
            var categoryJson = HttpContext.Session.GetString("category");
            var category = JsonConvert.DeserializeObject<CategoryDto>(categoryJson);
            var newCategoryId = category?.Id ?? 1;

            var storeAddressesInProvinceJson = HttpContext.Session.GetString("storeAddressesInProvince");
            var storeAddressesInProvince = JsonConvert.DeserializeObject<IEnumerable<StoreAddressDto>>(storeAddressesInProvinceJson) ?? Enumerable.Empty<StoreAddressDto>();

            var allStoresByCategoryJson = HttpContext.Session.GetString("storesByCategoryId");
            var allStores = JsonConvert.DeserializeObject<IEnumerable<StoreDto>>(allStoresByCategoryJson) ?? Enumerable.Empty<StoreDto>();

            // Retrieve stores in the selected subcategory
            var storesInSubCategory = await _storeService.GetStoresBySubCategory(subCategoryId);

            // Filter common stores
            var commonStores = allStores.Where(p => storeAddressesInProvince.Any(sa => sa.StoreId == p.Id)).ToList();

            // Filter common stores based on subcategory
            var filteredStores = (subCategoryId == 1 || subCategoryId == 15)
                ? commonStores
                : commonStores.Where(store => storesInSubCategory.Any(s => s.Id == store.Id)).ToList();

            // Retrieve store details
            var storeDetails = await GetStoreDetails(page, pageSize, newCategoryId, selectedDistricts, selectedSubCates, filteredStores);

            return PartialView("LoadStore", storeDetails);
        }

        private async Task<List<StoreDetailDto>> GetStoreDetails(
            int page,
            int pageSize,
            int newCategoryId,
            List<string> selectedDistricts,
            List<int> selectedSubCates,
            List<StoreDto> filteredStores)
        {
            var storeDetails = new List<StoreDetailDto>();
            var storeAddressesInProvinceJson = HttpContext.Session.GetString("storeAddressesInProvince");
            var storeAddressesInProvince = JsonConvert.DeserializeObject<IEnumerable<StoreAddressDto>>(storeAddressesInProvinceJson) ?? Enumerable.Empty<StoreAddressDto>();

            var storeAddressesInProvinceLookup = storeAddressesInProvince.ToDictionary(p => p.Id);

            // Filter based on districts
            if (selectedDistricts != null && selectedDistricts.Any())
            {
                var uniqueStoreIds = new HashSet<int>();
                foreach (var districtId in selectedDistricts)
                {
                    var storesInDistrict = await _districtService.GetStoresByDistrict(districtId, newCategoryId);
                    if (storesInDistrict != null)
                    {
                        foreach (var store in storesInDistrict)
                        {
                            uniqueStoreIds.Add(store.Id);
                        }
                    }
                }

                filteredStores = filteredStores.Where(s => uniqueStoreIds.Contains(s.Id)).ToList();
            }

            // Filter based on subcategories
            if (selectedSubCates != null && selectedSubCates.Any())
            {
                var storesInSubCategory = new HashSet<int>();
                foreach (var subCateId in selectedSubCates)
                {
                    var stores = await _storeService.GetStoresBySubCategory(subCateId);
                    if (stores != null)
                    {
                        foreach (var store in stores)
                        {
                            storesInSubCategory.Add(store.Id);
                        }
                    }
                }

                filteredStores = filteredStores.Where(s => storesInSubCategory.Contains(s.Id)).ToList();
            }

            // Pagination
            var storesToFetch = filteredStores.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.TotalPages = (int)Math.Ceiling(filteredStores.Count / (double)pageSize);
            ViewBag.CurrentPage = page;
            ViewBag.StoreCount = filteredStores.Count;

            // Fetch store details concurrently
            var storeDetailTasks = storesToFetch.Select(async store =>
            {
                var address = storeAddressesInProvinceLookup.Values.FirstOrDefault(sa => sa.StoreId == store.Id);
                var storeDetail = address != null
                    ? await _storeService.GetStoreWithDetailAddress(address.Id, store.Id, address.WardId)
                    : null;

                // Ensure the Id is correctly set
                if (storeDetail != null)
                {
                    storeDetail.StoreId = store.Id;
                }

                return storeDetail;
            }).ToList();

            ViewData["selectedDistricts"] = selectedDistricts;
            ViewData["selectedSubCates"] = selectedSubCates;

            var storeDetailResults = await Task.WhenAll(storeDetailTasks);

            return storeDetailResults.Where(sto => sto != null).ToList();
        }



        //public async Task<List<StoreDetailDto>> GetStoreDetail(List<StoreDto> stores)
        //{
        //    List<StoreDetailDto> storeDetails = new List<StoreDetailDto>();
        //    HashSet<int> addedStoreIds = new HashSet<int>();
        //    HashSet<int> addedStoreAddIds = new HashSet<int>();

        //    var provinceJson = HttpContext.Session.GetString("province");
        //    var province = JsonConvert.DeserializeObject<ProvinceDto>(provinceJson);
        //    var provinceId = province != null ? province.Id : "01";

        //    var storeAddressesInProvince = await _provinceService.GetStoreAddressesByProvince(provinceId);

        //    foreach (var stInPro in storeAddressesInProvince)
        //    {
        //        foreach (var store in stores)
        //        {
        //            var sto = await _storeService.GetStoreWithDetailAddress(stInPro.Id, store.Id, stInPro.WardId);
        //            if (sto != null && (!addedStoreIds.Contains(store.Id) || !addedStoreAddIds.Contains(stInPro.Id)))
        //            {
        //                sto.StoreId = store.Id;
        //                addedStoreIds.Add(store.Id);
        //                storeDetails.Add(sto);
        //                addedStoreAddIds.Add(stInPro.Id);
        //            }
        //        }
        //    }

        //    return storeDetails;
        //}

    }
}
