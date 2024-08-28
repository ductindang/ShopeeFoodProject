using BusinessLogicLayerFront.DTOs;
using BusinessLogicLayerFront.ServicesInterface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IDistrictService _districtService;
        private readonly IProvinceService _provinceService;
        private readonly ISubCategoryService _subCategoryService;

        public ProductController(IProductService productService,
            IDistrictService districtService,
            IProvinceService provinceService,
            ISubCategoryService subCategoryService)
        {
            _productService = productService;
            _districtService = districtService;
            _provinceService = provinceService;
            _subCategoryService = subCategoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SearchProductsByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Json(new List<ProductDto>()); // Return an empty list if the name is invalid
            }

            try
            {
                //var productsInProvince = ViewData["products"] as List<ProductDto>;
                //var products = await _productService.GetProductsByName(name);

                var commonProductsJson = HttpContext.Session.GetString("commonProducts");
                var productsInProvince = JsonConvert.DeserializeObject<List<ProductDto>>(commonProductsJson);

                var products = productsInProvince.Where(pro => pro.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
                if (products != null)
                {
                    return Json(products.Take(5)); // Return only the first 5 products
                }
                return Json(products);
            }
            catch (Exception ex)
            {
                // Handle any errors
                Console.WriteLine($"Error searching for products: {ex.Message}");
                return StatusCode(500, "An error occurred while searching for products."); // Return 500 error if there's an issue
            }
        }

        //public async Task<IActionResult> GetProductsByCategory(int categoryId, int page, int pageSize)
        //{
        //    try
        //    {
        //        var products = await _productService.GetProductsByCategoryId(categoryId);
        //        var prosInPage = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        //        return Json(products);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle any errors
        //        Console.WriteLine($"Error searching for products: {ex.Message}");
        //        return StatusCode(500, "An error occurred while searching for products."); // Return 500 error if there's an issue
        //    }
        //}

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductWithDetailAddress(id);
            if (product == null)
            {
                return null;
            }
            return View(product);
        }

        //public async Task<IActionResult> LoadProduct(int page = 1, int productPerPage = 5, List<string> selectedDistricts = null)
        //{
        //    var categoryJson = HttpContext.Session.GetString("category");
        //    var category = JsonConvert.DeserializeObject<CategoryDto>(categoryJson);
        //    var newCategoryId = category != null ? category.Id : 1;

        //    var provinceJson = HttpContext.Session.GetString("province");
        //    var province = JsonConvert.DeserializeObject<ProvinceDto>(provinceJson);
        //    var provinceId = province != null ? province.Id : "01";

        //    var productsInProvince = await _provinceService.GetProductsByProvince(provinceId);
        //    var allProducts = await _productService.GetProductsByCategoryId(newCategoryId);

        //    // Take all the samw product between allProducts and productsInProvince
        //    var commonProducts = allProducts.Where(p => productsInProvince.Any(pip => pip.Id == p.Id)).ToList();

        //    // Take products for current page

        //    List<ProductDetailDto> productDetails = new List<ProductDetailDto>();
        //    if (selectedDistricts == null)
        //    {
        //        var products = commonProducts.Skip((page - 1) * productPerPage).Take(productPerPage).ToList();
        //        ViewBag.TotalPages = (int)Math.Ceiling(commonProducts.Count() / (double)productPerPage);
        //        ViewBag.CurrentPage = page;
        //        foreach (var product in products)
        //        {
        //            var pro = await _productService.GetProductWithDetailAddress(product.Id);
        //            if (pro != null)
        //            {
        //                pro.Id = product.Id;
        //                productDetails.Add(pro);
        //            }
        //        }
        //        ViewBag.ProductCount = commonProducts.Count();
        //    }
        //    else
        //    {
        //        var productsInDistrict = new List<ProductDto>();
        //        // Change data type depends on product id type
        //        var uniqueProductIds = new HashSet<int>(); 

        //        foreach (string districtId in selectedDistricts)
        //        {
        //            var pros = await _districtService.GetProductsByDistrict(districtId, newCategoryId);
        //            if(pros != null)
        //            {
        //                foreach (var product in pros)
        //                {
        //                    // If product id hasn't had in HashSet, add into list and HashSet
        //                    if (uniqueProductIds.Add(product.Id))
        //                    {
        //                        productsInDistrict.Add(product);
        //                    }
        //                }
        //            }
                    
        //        }
        //        var commonProducts2 = commonProducts.Where(p => productsInDistrict.Any(pid => pid.Id == p.Id)).ToList();
        //        var products = commonProducts2.Skip((page - 1) * productPerPage).Take(productPerPage).ToList();
        //        ViewBag.TotalPages = (int)Math.Ceiling(commonProducts2.Count() / (double)productPerPage);
        //        ViewBag.CurrentPage = page;

        //        foreach (var product in products)
        //        {
        //            var pro = await _productService.GetProductWithDetailAddress(product.Id);
        //            if (pro != null)
        //            {
        //                pro.Id = product.Id;
        //                productDetails.Add(pro);
        //            }
        //        }

        //        ViewBag.ProductCount = commonProducts2.Count();
        //    }
        //    return PartialView("LoadProduct", productDetails);
        //}



        //public async Task<IActionResult> GetProductWithDetailAddress(int id)
        //{
        //    try
        //    {
        //        var product = await _productService.GetProductWithDetailAddress(id);
        //        product.Id = id;
        //        return Json(product);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle any errors
        //        Console.WriteLine($"Error searching for products: {ex.Message}");
        //        return StatusCode(500, "An error occurred while searching for products."); // Return 500 error if there's an issue
        //    }
        //}

        //public async Task<IActionResult> GetProductsByDistrict(string districtId, int page, int pageSize)
        //{
        //    var categoryJson = HttpContext.Session.GetString("category");
        //    var category = JsonConvert.DeserializeObject<CategoryDto>(categoryJson);

        //    var categoryId = category != null ? category.Id : 1;

        //    var products = await _districtService.GetProductsByDistrict(districtId, categoryId);
        //    List<ProductDetailDto> productDetails = new List<ProductDetailDto>();

        //    if (products.Any() || products != null)
        //    {
        //        foreach (var product in products)
        //        {
        //            var pro = await _productService.GetProductWithDetailAddress(product.Id);
        //            if (pro != null)
        //            {
        //                pro.Id = product.Id;
        //                productDetails.Add(pro);
        //            }
        //        }
        //    }
            
        //    var paginatedProduct = productDetails
        //        .Skip((page - 1) * pageSize)
        //        .Take(pageSize)
        //        .ToList();

        //    return Json(paginatedProduct);
        //}



        //public async Task<IActionResult> ProductsBySubCategory(int subCategoryId)
        //{
        //    Console.WriteLine("Sub Id: " + subCategoryId);
        //    var subCategory = await _subCategoryService.GetSubCategoryById(subCategoryId);
        //    return View(subCategory);
        //    //Console.WriteLine("Sub Id: " + subCategoryId);

        //    //return View();
        //}

        //public async Task<IActionResult> GetProductsBySubCategory( int page, int pageSize, int subCategoryId = 1)
        //{
        //    var categoryJson = HttpContext.Session.GetString("category");
        //    var category = JsonConvert.DeserializeObject<CategoryDto>(categoryJson);
        //    var newCategoryId = category != null ? category.Id : 1;

        //    var provinceJson = HttpContext.Session.GetString("province");
        //    var province = JsonConvert.DeserializeObject<ProvinceDto>(provinceJson);
        //    var provinceId = province != null ? province.Id : "01";

        //    var productsInProvince = await _provinceService.GetProductsByProvince(provinceId);
        //    var allProducts = await _productService.GetProductsByCategoryId(newCategoryId);
        //    var productsInSubCategory = await _productService.GetProductsBySubCategory(subCategoryId);

        //    // Take all the same product between allProducts and productsInProvince
        //    var commonProducts = allProducts.Where(p => productsInProvince.Any(pip => pip.Id == p.Id)).ToList();
        //    var commonProducts2 = new List<ProductDto>();

        //    if (subCategoryId == 1)
        //    {
        //        commonProducts2 = commonProducts;
        //    }
        //    else
        //    {
        //        commonProducts2 = productsInSubCategory.Where(p => commonProducts.Any(cp => cp.Id == p.Id)).ToList();
        //    }

        //    // Take products for current page
        //    var products = commonProducts2.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        //    ViewBag.TotalPages = (int)Math.Ceiling(commonProducts2.Count() / (double)pageSize);
        //    ViewBag.CurrentPage = page;

        //    List<ProductDetailDto> productDetails = new List<ProductDetailDto>();

        //    foreach (var product in products)
        //    {
        //        var pro = await _productService.GetProductWithDetailAddress(product.Id);
        //        if (pro != null)
        //        {
        //            pro.Id = product.Id;
        //            productDetails.Add(pro);
        //        }
        //    }

        //    ViewBag.ProductCount = productDetails.Count();

        //    return PartialView("LoadProduct", productDetails);
        //}

        //public async Task<IActionResult> GetProductsByDistricts(int page, int pageSize, List<string> selectedDistricts = null)
        //{
        //    var categoryJson = HttpContext.Session.GetString("category");
        //    var category = JsonConvert.DeserializeObject<CategoryDto>(categoryJson);
        //    var newCategoryId = category != null ? category.Id : 1;

        //    var provinceJson = HttpContext.Session.GetString("province");
        //    var province = JsonConvert.DeserializeObject<ProvinceDto>(provinceJson);
        //    var provinceId = province != null ? province.Id : "01";

        //    var productsInProvince = await _provinceService.GetProductsByProvince(provinceId);
        //    var allProducts = await _productService.GetProductsByCategoryId(newCategoryId);

        //    // Take all the samw product between allProducts and productsInProvince
        //    //var commonProducts = allProducts.Where(p => productsInProvince.Any(pip => pip.Id == p.Id)).ToList();

        //    // Take products for current page
        //    var products = productsInProvince.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        //    ViewBag.TotalPages = (int)Math.Ceiling(productsInProvince.Count() / (double)pageSize);
        //    ViewBag.CurrentPage = page;

        //    List<ProductDetailDto> productDetails = new List<ProductDetailDto>();

        //    foreach (var product in products)
        //    {
        //        var pro = await _productService.GetProductWithDetailAddress(product.Id);
        //        if (pro != null)
        //        {
        //            pro.Id = product.Id;
        //            productDetails.Add(pro);
        //        }
        //    }

        //    return PartialView("LoadProduct", productDetails);
        //}
    }
}
