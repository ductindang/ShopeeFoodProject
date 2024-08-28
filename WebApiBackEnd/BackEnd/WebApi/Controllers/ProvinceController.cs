using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.ServicesInterface;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceService _provinceService;
        private readonly IDistrictService _districtService;
        private readonly IWardService _wardService;
        private readonly IStoreAddressService _storeAddressService;
        private readonly IProductService _productService;
        private readonly IStoreService _storeService;

        public ProvinceController(IProvinceService provinceService,
            IDistrictService districtService,
            IWardService wardService,
            IStoreAddressService storeAddressService,
            IProductService productService,
            IStoreService storeService)
        {
            _provinceService = provinceService;
            _districtService = districtService;
            _wardService = wardService;
            _storeAddressService = storeAddressService;
            _productService = productService;
            _storeService = storeService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProvinceRequest>>> GetAllProvinces()
        {
            var provinces = await _provinceService.GetAllProvinces(); // Assuming this returns IEnumerable<StoreDto>
            return Ok(provinces);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProvinceRequest>> GetProvinceById(string id)
        {
            var province = await _provinceService.GetProvinceById(id); // Assuming this returns StoreDto
            if (province == null)
            {
                return NotFound();
            }
            return Ok(province);
        }

        [HttpGet("{provinceId}/Wards")]
        public async Task<ActionResult<List<WardRequest>>> GetWardsByProvince(string provinceId)
        {
            var districts = await _districtService.GetDistrictsByProvince(provinceId);
            if (districts == null || !districts.Any())
            {
                return NotFound("Cannot find any district in this province");
            }

            List<WardRequest> wards = new List<WardRequest>();
            foreach (var district in districts)
            {
                var wardInDistrict = await _wardService.GetWardsByDistrict(district.Id);
                wards.AddRange(wardInDistrict);
            }

            if (!wards.Any())
            {
                return NotFound("Cannot find any ward in these districts of the province");
            }

            return Ok(wards);
        }


        [HttpGet("{provinceId}/StoreAddresses")]
        public async Task<ActionResult<List<StoreAddressRequest>>> GetStoreAddressesByProvince(string provinceId)
        {
            var districts = await _districtService.GetDistrictsByProvince(provinceId);
            if (districts == null || !districts.Any())
            {
                return NotFound("Cannot find any district in this province");
            }

            List<WardRequest> wards = new List<WardRequest>();
            foreach (var district in districts)
            {
                var wardInDistrict = await _wardService.GetWardsByDistrict(district.Id);
                wards.AddRange(wardInDistrict);
            }

            if (!wards.Any())
            {
                return NotFound("Cannot find any ward in these districts of the province");
            }

            List<StoreAddressRequest> storeAddresses = new List<StoreAddressRequest>();

            foreach (var ward in wards)
            {
                var addressesInWard = await _storeAddressService.GetAllStoreAddressesByWardId(ward.Id);
                storeAddresses.AddRange(addressesInWard);
            }

            if (!storeAddresses.Any())
            {
                return NotFound("Cannot find any store addresses in these wards");
            }

            return Ok(storeAddresses);
        }


        [HttpGet("{provinceId}/Products")]
        public async Task<ActionResult<List<ProductRequest>>> GetProductsByProvince(string provinceId)
        {
            var districts = await _districtService.GetDistrictsByProvince(provinceId);
            if (districts == null || !districts.Any())
            {
                return NotFound("Cannot find any district in this province");
            }

            List<WardRequest> wards = new List<WardRequest>();
            foreach (var district in districts)
            {
                var wardInDistrict = await _wardService.GetWardsByDistrict(district.Id);
                wards.AddRange(wardInDistrict);
            }

            if (!wards.Any())
            {
                return NotFound("Cannot find any ward in these districts of the province");
            }

            List<StoreAddressRequest> storeAddresses = new List<StoreAddressRequest>();

            foreach (var ward in wards)
            {
                var addressesInWard = await _storeAddressService.GetAllStoreAddressesByWardId(ward.Id);
                storeAddresses.AddRange(addressesInWard);
            }

            if (!storeAddresses.Any())
            {
                return NotFound("Cannot find any store addresses in these wards");
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


        [HttpGet("Discounts")]
        public async Task<ActionResult<List<ProductRequest>>> GetDiscountByProvince(string provinceId)
        {
            var districts = await _districtService.GetDistrictsByProvince(provinceId);
            if (districts == null || !districts.Any())
            {
                return NotFound("Cannot find any district in this province");
            }

            List<WardRequest> wards = new List<WardRequest>();
            foreach (var district in districts)
            {
                var wardInDistrict = await _wardService.GetWardsByDistrict(district.Id);
                wards.AddRange(wardInDistrict);
            }

            if (!wards.Any())
            {
                return NotFound("Cannot find any ward in these districts of the province");
            }

            List<StoreAddressRequest> storeAddresses = new List<StoreAddressRequest>();

            foreach (var ward in wards)
            {
                var addressesInWard = await _storeAddressService.GetAllStoreAddressesByWardId(ward.Id);
                storeAddresses.AddRange(addressesInWard);
            }

            if (!storeAddresses.Any())
            {
                return NotFound("Cannot find any store addresses in these wards");
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

            //IEnumerable<DiscountRequest> discounts = await _discountService.GetAllDiscountsFromProduct(products);

            //if (!discounts.Any())
            //{
            //    return NotFound("Cannot find any discount in the product of this store");
            //}

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



        [HttpGet("{provinceId}/Stores")]
        public async Task<ActionResult<List<StoreRequest>>> GetStoresByProvince(string provinceId)
        {
            var districts = await _districtService.GetDistrictsByProvince(provinceId);
            if (districts == null || !districts.Any())
            {
                return NotFound("Cannot find any district in this province");
            }

            List<WardRequest> wards = new List<WardRequest>();
            foreach (var district in districts)
            {
                var wardInDistrict = await _wardService.GetWardsByDistrict(district.Id);
                wards.AddRange(wardInDistrict);
            }

            if (!wards.Any())
            {
                return NotFound("Cannot find any ward in these districts of the province");
            }

            List<StoreAddressRequest> storeAddresses = new List<StoreAddressRequest>();

            foreach (var ward in wards)
            {
                var addressesInWard = await _storeAddressService.GetAllStoreAddressesByWardId(ward.Id);
                storeAddresses.AddRange(addressesInWard);
            }

            if (!storeAddresses.Any())
            {
                return NotFound("Cannot find any store addresses in these wards");
            }

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

            return Ok(stores);
        }

    }
}
