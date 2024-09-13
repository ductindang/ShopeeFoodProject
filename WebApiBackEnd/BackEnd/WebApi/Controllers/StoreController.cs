using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.ServicesInterface;
using DataAccessLayer.Models;
using BusinessLogicLayer.Requests;
using BusinessLogicLayer.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        //private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public StoreController(IStoreService storeService, ICategoryService categoryService)
        {
            _storeService = storeService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreRequest>>> GetAllStores()
        {
            var stores = await _storeService.GetAllStores(); 
            return Ok(stores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StoreRequest>> GetStoreById(int id)
        {
            var store = await _storeService.GetStoreById(id);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }

        [HttpPost]
        public async Task<ActionResult<StoreRequest>> InsertStore([FromBody] StoreRequestCreate storeRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var store = await _storeService.InsertStore(storeRequest);

            if (store == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetStoreById), new { id = store.Id }, store);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStore([FromBody] StoreRequest storeRequest, int id)
        {
            var existingStore = await _storeService.GetStoreById(id);
            if (existingStore == null)
            {
                return NotFound();
            }

            storeRequest.Id = id;
            // Assuming this takes StoreDto
            await _storeService.UpdateStore(storeRequest); 

            return Ok(storeRequest);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStore(int id)
        {
            var store = await _storeService.GetStoreById(id);
            if (store == null)
            {
                return NotFound();
            }

            await _storeService.DeleteStore(store); 

            return Ok(store);
        }


        [HttpGet("Category/{categoryId}")]
        public async Task<ActionResult<StoreRequest>> GetProductsByCategoryId(int categoryId)
        {
            var cate = await _categoryService.GetCategoryById(categoryId);
            if (cate == null)
            {
                return NotFound("Don not have this category");
            }
            var stores = await _storeService.GetStoresByCategoryId(categoryId);
            return Ok(stores);
        }

        [HttpGet("Name")]
        public async Task<ActionResult<StoreRequest>> GetStoresByName(string name)
        {
            var stores = await _storeService.GetStoresByName(name);
            if (stores == null || !stores.Any())
            {
                return NotFound();
            }
            return Ok(stores);
        }


        [HttpGet("{storeId}/StoreAddress/{storeAddressId}/Ward/{wardId}/AddressDetail")]
        public async Task<IActionResult> GetStoreWithDetailAddress(int storeId, int storeAddressId, string wardId)
        {
            var store = await _storeService.GetStoreWithDetailAddress(storeId, storeAddressId, wardId);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }

        [HttpGet("SubCategory")]
        public async Task<IActionResult> GetStoresBySubCategoryPerPage(int subCategoryId, int page, int pageSize)
        {
            var stores = await _storeService.GetStoresBySubCategoryPerPage(subCategoryId, page, pageSize);
            return Ok(stores);
        }

        [HttpGet("SubCategory/{subCategoryId}")]
        public async Task<IActionResult> GetStoresBySubCategory(int subCategoryId)
        {
            var stores = await _storeService.GetStoresBySubCategory(subCategoryId);
            return Ok(stores);
        }

        [HttpGet("{storeId}/ProductDetail")]
        public async Task<IActionResult> GetStoreMenuProductDetails(int storeId)
        {
            var storeMenuProduct = await _storeService.GetStoreMenuProductDetails(storeId);
            return Ok(storeMenuProduct);
        }

    }
}
