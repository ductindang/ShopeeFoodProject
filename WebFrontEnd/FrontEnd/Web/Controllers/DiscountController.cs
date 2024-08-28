using BusinessLogicLayerFront.DTOs;
using BusinessLogicLayerFront.ServicesInterface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetDiscounts(int categoryId = 1, int page = 1, int pageSize = 9)
        {
            var allDiscounts = await _discountService.GetDiscountByCategoryId(categoryId);
            var commonProductsJson = HttpContext.Session.GetString("commonProducts");
            var productsInProvince = JsonConvert.DeserializeObject<List<ProductDto>>(commonProductsJson);

            //var commonDiscounts = allDiscounts.Where(d => productsInProvince.Any(pip => pip.DiscountId == d.Id)).ToList();
            //var paginatedDiscount = commonDiscounts
            //    .Skip((page - 1) * pageSize)
            //    .Take(pageSize)
            //    .Select(d => new
            //    {
            //        Id = d.Id,
            //        Name = d.Name,
            //        ImageUrl = d.Image
            //    })
            //    .ToList();


            var commonDiscounts = allDiscounts.Select(d => new
            {
                Id = d.Id,
                Name = d.Name,
                ImageUrl = d.Image,
                ProductCount = productsInProvince.Count(pip => pip.DiscountId == d.Id)
            })
                .Where(d => productsInProvince.Any(pip => pip.DiscountId == d.Id)).ToList();

            // Apply pagination
            var paginatedDiscount = commonDiscounts
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Json(paginatedDiscount);
        }
    }
}
