using BusinessLogicLayer.Requests;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.ServicesInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public DiscountController(IDiscountService discountService, IProductService productService, ICategoryService categoryService)
        {
            _discountService = discountService;
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiscountRequest>>> GetAllDiscount()
        {
            var discounts = await _discountService.GetAllDiscounts();
            return Ok(discounts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiscountRequest>> GetDiscountById(int id)
        {
            var discount = await _discountService.GetDiscountById(id);
            if(discount == null)
            {
                return NotFound();
            }
            return Ok(discount);
        }

        [HttpGet("Category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<DiscountRequest>>> GetDiscountByCategoryId(int categoryId)
        {
            var cate = await _categoryService.GetCategoryById(categoryId);
            if (cate == null)
            {
                return NotFound("Don not have this category");
            }
            var products = await _productService.GetProductsByCategoryId(categoryId);
            List<DiscountRequest> discounts = new List<DiscountRequest>();
            foreach (var product in products)
            {
                var discountInProduct = await _productService.GetDiscountByProduct(product.Id);
                discounts.Add(discountInProduct);
            }

            if (!discounts.Any())
            {
                return NotFound("Cannot find any products in the stores of this ward");
            }

            var uniqueDiscounts = discounts
                .GroupBy(d => d.Id)
                .Select(g => g.First())
                .ToList();

            return Ok(uniqueDiscounts);
        }
    }
}
