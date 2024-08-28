using BusinessLogicLayerFront.DTOs;
using BusinessLogicLayerFront.ServicesInterface;
using Newtonsoft.Json;

namespace BusinessLogicLayerFront.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly IProvinceService _provinceService;

        public ProductService(HttpClient httpClient, IProvinceService provinceService)
        {
            _httpClient = httpClient;
            _provinceService = provinceService;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var response = await _httpClient.GetAsync("api/product");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(jsonString);

            return products;
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var response = await _httpClient.GetAsync($"api/Product/{id}");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductDto>(jsonString);

            return product;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryId(int categoryId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Product/Category/{categoryId}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var products = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(jsonString);
                    return products;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Request failed with status code {response.StatusCode} and reason: {response.ReasonPhrase}. Response content: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new ApplicationException("An error occurred while fetching the products by category id.", ex);
            }
        }

        //public async Task<IEnumerable<ProductDto>> GetProductsByName(string name)
        //{
        //    try
        //    {
        //        var response = await _httpClient.GetAsync($"api/Product/Name?name={Uri.EscapeDataString(name)}");
                
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var jsonString = await response.Content.ReadAsStringAsync();
        //            var products = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(jsonString);
        //            return products;
        //        }
        //        else
        //        {
        //            return null;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //        throw new ApplicationException("An error occurred while fetching the products by product name.", ex);
        //    }
        //}

        //public async Task<IEnumerable<ProductDto>> GetProductsByCategoryId(int categoryId, int page, int pageSize)
        //{
        //    try
        //    {
        //        var response = await _httpClient.GetAsync($"api/Product/CategoryPerPage?categoryId={categoryId}&page={page}&pageSize={pageSize}");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var jsonString = await response.Content.ReadAsStringAsync();
        //            var products = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(jsonString);
        //            return products;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //        throw new ApplicationException("An error occurred while fetching the products by product name.", ex);
        //    }
        //}

        public async Task<ProductDetailDto> GetProductWithDetailAddress(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Product/{id}/AddressDetail");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var productDetail = JsonConvert.DeserializeObject<ProductDetailDto>(jsonString);
                    return productDetail;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new ApplicationException("An error occurred while fetching the products by product name.", ex);
            }
        }

        public async Task<IEnumerable<ProductDto>> GetProductsBySubCategory(int subCategoryId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Product/SubCategory/{subCategoryId}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var productDetail = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(jsonString);
                    return productDetail;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new ApplicationException("An error occurred while fetching the products by product name.", ex);
            }
        }
    }
}
