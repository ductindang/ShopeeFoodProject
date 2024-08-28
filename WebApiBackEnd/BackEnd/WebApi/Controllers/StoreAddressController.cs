using BusinessLogicLayer.BaseRequests;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;
using BusinessLogicLayer.ServicesInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreAddressController : ControllerBase
    {
        private readonly IStoreAddressService _storeAddressService;
        private readonly IProductService _productService;

        public StoreAddressController(IStoreAddressService storeAddressService, IProductService productService)
        {
            _storeAddressService = storeAddressService;
            _productService = productService;
        }

        //private readonly IProductService _productService;


        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreAddressRequest>>> GetAllStoreAddresses()
        {
            var storeAddresses = await _storeAddressService.GetAllStoreAddresses(); // Assuming this returns IEnumerable<StoreDto>
            return Ok(storeAddresses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StoreAddressRequest>> GetStoreAddressById(int id)
        {
            var storeAddress = await _storeAddressService.GetStoreAddressById(id); // Assuming this returns StoreDto
            if (storeAddress == null)
            {
                return NotFound();
            }
            return Ok(storeAddress);
        }

        [HttpPost]
        public async Task<ActionResult<StoreAddressRequest>> InsertStoreAddress([FromBody] BaseStoreAddress storeAddressDto)
        {
            var storeAddress = await _storeAddressService.InsertStoreAddress(storeAddressDto); // Assuming this returns StoreDto

            if (storeAddress == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetStoreAddressById), new { id = storeAddress.Id }, storeAddress);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStoreAddress([FromBody] StoreAddressRequest storeAddressDto, int id)
        {
            var existingStoreAddress = await _storeAddressService.GetStoreAddressById(id);
            if (existingStoreAddress == null)
            {
                return NotFound();
            }

            storeAddressDto.Id = id;
            await _storeAddressService.UpdateStoreAddress(storeAddressDto); // Assuming this takes StoreDto

            return Ok(storeAddressDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStore(int id)
        {
            var storeAddress = await _storeAddressService.GetStoreAddressById(id);
            if (storeAddress == null)
            {
                return NotFound();
            }

            await _storeAddressService.DeleteStoreAddress(storeAddress); // Assuming this takes the store Id

            return Ok(storeAddress);
        }

        [HttpGet("Ward/{wardId}")]
        public async Task<ActionResult> GetAllStoreAddressesByWardId(string wardId)
        {
            var storeAddresses = await _storeAddressService.GetAllStoreAddressesByWardId(wardId);
            if (storeAddresses == null || !storeAddresses.Any())
            {
                return NotFound();
            }
            return Ok(storeAddresses);
        }

        [HttpGet("Products/Ward/{wardId}")]
        public async Task<ActionResult> GetAllStoreAddressesFollowWard(string wardId)
        {
            var storeAddresses = await _storeAddressService.GetAllStoreAddressesByWardId(wardId);

            if (!storeAddresses.Any() || storeAddresses == null)
            {
                return NotFound("Cannot find any store in this ward");
            }

            List<ProductRequest> products = new List<ProductRequest>();
            foreach (var storeAddress in storeAddresses)
            {
                var productInStore = await _productService.GetProductsByStoreId(storeAddress.StoreId);
                products.AddRange(productInStore);
            }

            if (!products.Any())
            {
                return NotFound("Cannot find any products in the stores of this ward");
            }

            return Ok(products);
        }
    }
}
