using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.ServicesInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _districtService;
        private readonly IWardService _wardService;
        private readonly IStoreAddressService _storeAddressService;
        private readonly IProductService _productService;
        private readonly IStoreService _storeService;

        public DistrictController(IDistrictService districtService,
            IWardService wardService,
            IStoreAddressService storeAddressService,
            IProductService productService,
            IStoreService storeService)
        {
            _districtService = districtService;
            _wardService = wardService;
            _storeAddressService = storeAddressService;
            _productService = productService;
            _storeService = storeService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<DistrictRequest>>> GetAllDistricts()
        {
            var districts = await _districtService.GetAllDistricts(); // Assuming this returns IEnumerable<StoreDto>
            return Ok(districts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DistrictRequest>> GetDistrictById(string id)
        {
            var district = await _districtService.GetDistrictById(id); // Assuming this returns StoreDto
            if (district == null)
            {
                return NotFound();
            }
            return Ok(district);
        }

        [HttpGet("Province/{provinceId}")]
        public async Task<ActionResult<IEnumerable<DistrictRequest>>> GetDistrictsByProvince(string provinceId)
        {
            var districts = await _districtService.GetDistrictsByProvince(provinceId); // Assuming this returns StoreDto
            if (districts == null || !districts.Any())
            {
                return NotFound();
            }
            return Ok(districts);
        }


        [HttpGet("{districtId}/Products")]
        public async Task<ActionResult<List<ProductRequest>>> GetProductsByDistrict(string districtId, int categoryId)
        {
            // Get all wards by district
            var wards = await _wardService.GetWardsByDistrict(districtId);
            if (!wards.Any())
            {
                return NotFound("Cannot find any ward in these districts of the province");
            }

            // Get all store addresses by ward
            var storeAddresses = new List<StoreAddressRequest>();
            foreach (var ward in wards)
            {
                var addressesInWard = await _storeAddressService.GetAllStoreAddressesByWardId(ward.Id);
                storeAddresses.AddRange(addressesInWard);
            }

            if (!storeAddresses.Any())
            {
                return NotFound("Cannot find any store addresses in these wards");
            }

            // Get unique products by store ID
            var productIds = new HashSet<int>();
            var products = new List<ProductRequest>();
            foreach (var storeAddress in storeAddresses)
            {
                var productInStore = await _productService.GetProductsByStoreId(storeAddress.StoreId);
                foreach (var product in productInStore)
                {
                    if (productIds.Add(product.Id))
                    {
                        products.Add(product);
                    }
                }
            }

            if (!products.Any())
            {
                return NotFound("Cannot find any products in the stores of this ward");
            }

            // Get products by category ID
            var productsByCategory = await _productService.GetProductsByCategoryId(categoryId);

            // Filter products by category
            var filteredProducts = products
                .Where(p => productsByCategory.Any(c => c.Id == p.Id))
                .ToList();

            if (!filteredProducts.Any())
            {
                return NotFound("Cannot find any products in this district that match the specified category.");
            }

            return Ok(filteredProducts);
        }


        [HttpGet("{districtId}/Stores")]
        public async Task<ActionResult<List<StoreRequest>>> GetStoresByDistrict(string districtId, int categoryId)
        {
            // Get all wards by district
            var wards = await _wardService.GetWardsByDistrict(districtId);
            if (!wards.Any())
            {
                return NotFound("Cannot find any ward in these districts of the province");
            }

            // Get all store addresses by ward
            var storeAddresses = new List<StoreAddressRequest>();
            foreach (var ward in wards)
            {
                var addressesInWard = await _storeAddressService.GetAllStoreAddressesByWardId(ward.Id);
                storeAddresses.AddRange(addressesInWard);
            }

            if (!storeAddresses.Any())
            {
                return NotFound("Cannot find any store addresses in these wards");
            }

            // Get unique products by store ID
            List<StoreRequest> stores = new List<StoreRequest>();
            HashSet<int> addedStoreIds = new HashSet<int>();  // Để lưu các StoreId đã được thêm vào danh sách

            foreach (var storeAddress in storeAddresses)
            {
                if (!addedStoreIds.Contains(storeAddress.StoreId))
                {
                    var storeInStoreAddress = await _storeService.GetStoreById(storeAddress.StoreId);
                    if (storeInStoreAddress != null)
                    {
                        stores.Add(storeInStoreAddress);
                        addedStoreIds.Add(storeAddress.StoreId); // Thêm StoreId vào HashSet
                    }
                }
            }

            if (!stores.Any())
            {
                return NotFound("Cannot find any stores in the stores of this ward");
            }

            // Get products by category ID
            var storesByCategory = await _storeService.GetStoresByCategoryId(categoryId);

            // Filter products by category
            var filteredStores = stores
                .Where(p => storesByCategory.Any(c => c.Id == p.Id))
                .ToList();

            if (!filteredStores.Any())
            {
                return NotFound("Cannot find any products in this district that match the specified category.");
            }

            return Ok(filteredStores);
        }
    }
}
