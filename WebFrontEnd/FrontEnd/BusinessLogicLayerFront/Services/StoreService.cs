using BusinessLogicLayerFront.DTOs;
using BusinessLogicLayerFront.ServicesInterface;
using Newtonsoft.Json;

namespace BusinessLogicLayerFront.Services
{
    public class StoreService : IStoreService
    {
        private readonly HttpClient _httpClient;

        public StoreService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<IEnumerable<StoreDto>> GetAllStores()
        {
            var response = await _httpClient.GetAsync("api/store");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var stores = JsonConvert.DeserializeObject<IEnumerable<StoreDto>>(jsonString);

            return stores;
        }

        public async Task<StoreDto> GetStoreById(int id)
        {
            var response = await _httpClient.GetAsync($"api/Store/{id}");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var store = JsonConvert.DeserializeObject<StoreDto>(jsonString);

            return store;
        }

        public async Task<IEnumerable<StoreDto>> GetStoresByCategoryId(int categoryId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Store/Category/{categoryId}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var stores = JsonConvert.DeserializeObject<IEnumerable<StoreDto>>(jsonString);
                    return stores;
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

        //public async Task<IEnumerable<StoreDto>> GetStoresByName(string name)
        //{
        //    try
        //    {
        //        var response = await _httpClient.GetAsync($"api/Store/Name?name={Uri.EscapeDataString(name)}");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var jsonString = await response.Content.ReadAsStringAsync();
        //            var stores = JsonConvert.DeserializeObject<IEnumerable<StoreDto>>(jsonString);
        //            return stores;
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

        public async Task<StoreDetailDto> GetStoreWithDetailAddress(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Store/{id}/AddressDetail");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var storeDetail = JsonConvert.DeserializeObject<StoreDetailDto>(jsonString);
                    return storeDetail;
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

        public async Task<IEnumerable<StoreDto>> GetStoresBySubCategory(int subCategoryId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Store/SubCategory/{subCategoryId}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var storeDetail = JsonConvert.DeserializeObject<IEnumerable<StoreDto>>(jsonString);
                    return storeDetail;
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
