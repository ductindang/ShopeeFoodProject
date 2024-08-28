using BusinessLogicLayerFront.DTOs;
using BusinessLogicLayerFront.ServicesInterface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerFront.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly HttpClient _httpClient;

        public DistrictService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<DistrictDto>> GetAllDistricts()
        {
            throw new NotImplementedException();
        }

        public Task<DistrictDto> GetDistrictById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByDistrict(string districId, int categoryId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/District/{districId}/Products?categoryId={categoryId}");
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


        public async Task<IEnumerable<DistrictDto>> GetDistrictsByProvince(string provinceId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/District/Province/{provinceId}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var districts = JsonConvert.DeserializeObject<IEnumerable<DistrictDto>>(jsonString);
                    return districts;
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

        public async Task<IEnumerable<StoreDto>> GetStoresByDistrict(string districId, int categoryId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/District/{districId}/Stores?categoryId={categoryId}");
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
    }
}
