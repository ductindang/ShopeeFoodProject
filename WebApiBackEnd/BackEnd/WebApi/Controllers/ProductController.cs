using BusinessLogicLayer.BaseRequests;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;
using BusinessLogicLayer.ServicesInterface;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductRequest>>> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductRequest>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductRequest>> InsertProduct([FromBody] BaseProduct productDto)
        {

            var product = await _productService.InsertProduct(productDto);

            if (product == null)
            {
                return BadRequest();
            }
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductRequest>> UpdateProduct([FromBody] ProductRequest productDto, int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            productDto.Id = id;

            product = productDto;
            await _productService.UpdateProduct(product);

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductRequest>> DeleteProduct(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productService.DeleteProduct(product);
            return Ok(product);
        }

        [HttpGet("Category/{categoryId}")]
        public async Task<ActionResult<ProductRequest>> GetProductsByCategoryId(int categoryId)
        {
            var cate = await _categoryService.GetCategoryById(categoryId);
            if (cate == null)
            {
                return NotFound("Don not have this category");
            }
            var products = await _productService.GetProductsByCategoryId(categoryId);
            return Ok(products);
        }

        [HttpGet("Name")]
        public async Task<ActionResult<ProductRequest>> GetProductsByName(string name)
        {
            var products = await _productService.GetProductsByName(name);
            if (products == null || !products.Any())
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet("CategoryPerPage")]
        public async Task<IActionResult> GetProdutsByCategory(int categoryId, int page, int pageSize)
        {
            var products = await _productService.GetProductsByCategoryId(categoryId, page, pageSize);
            //if(products == null || !products.Any())
            //{
            //    return NotFound();
            //}
            return Ok(products);
        }

        //[HttpGet("ProductsPerPage")]
        //public async Task<IActionResult> GetProductsPerPage(int categoryId, int page, int productPerPage)
        //{
        //    var products = await _productService.GetProductsPerPage(categoryId, page, productPerPage);
        //    //if(products == null || !products.Any())
        //    //{
        //    //    return NotFound();
        //    //}
        //    return Ok(products);
        //}

        [HttpGet("Store/{storeId}")]
        public async Task<IActionResult> GetProductsByStoreId(int storeId)
        {
            var products = await _productService.GetProductsByStoreId(storeId);
            if (products == null || !products.Any())
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet("{productId}/AddressDetail")]
        public async Task<IActionResult> GetProductWithDetailAddress(int productId)
        {
            var product = await _productService.GetProductWithDetailAdress(productId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("Discount/{discountId}")]
        public async Task<IActionResult> GetProductsByDiscount(int discountId)
        {
            var products = await _productService.GetProductsByDiscount(discountId);
            if(products == null || !products.Any())
            {
                return NotFound();
            }
            return Ok(products);
        }

        //[HttpGet("Discount")]
        //public async Task<IActionResult> GetAllDiscountsFromProduct()
        //{
        //    var discounts = await _productService.GetAllDiscountsFromProduct();
        //    if (discounts == null || !discounts.Any())
        //    {
        //        return NotFound();
        //    }
        //    return Ok(discounts);
        //}

        [HttpGet("UniqueDiscount")]
        public async Task<IActionResult> GetProductsWithUniqueDiscounts()
        {
            var products = await _productService.GetProductsWithUniqueDiscounts();
            if (products == null || !products.Any())
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet("{productId}/Discount")]
        public async Task<IActionResult> GetDiscountByProduct(int productId)
        {
            var discount = await _productService.GetDiscountByProduct(productId);
            if (discount == null)
            {
                return NotFound();
            }
            return Ok(discount);
        }

        [HttpGet("SubCategory")]
        public async Task<IActionResult> GetProductsBySubCategoryPerPage(int subCategoryId, int page, int pageSize)
        {
            var products = await _productService.GetProductsBySubCategoryPerPage(subCategoryId, page, pageSize);
            //if(products == null || !products.Any())
            //{
            //    return NotFound();
            //}
            return Ok(products);
        }

        [HttpGet("SubCategory/{subCategoryId}")]
        public async Task<IActionResult> GetProductsBySubCategory(int subCategoryId)
        {
            var products = await _productService.GetProductsBySubCategory(subCategoryId);
            //if(products == null || !products.Any())
            //{
            //    return NotFound();
            //}
            return Ok(products);
        }

    }
}
