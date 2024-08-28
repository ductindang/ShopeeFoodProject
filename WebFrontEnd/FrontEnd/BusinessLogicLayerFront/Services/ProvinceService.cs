using BusinessLogicLayerFront.DTOs;
using BusinessLogicLayerFront.ServicesInterface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerFront.Services
{
    public class ProvinceService : IProvinceService
    {
        private readonly HttpClient _httpClient;

        public ProvinceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProvinceDto>> GetAllProvinces()
        {
            var response = await _httpClient.GetAsync("api/Province");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var provinces = JsonConvert.DeserializeObject<IEnumerable<ProvinceDto>>(jsonString);

            return provinces;
        }

        public async Task<ProvinceDto> GetProvinceById(string id)
        {
            var response = await _httpClient.GetAsync($"api/Province/{id}");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var province = JsonConvert.DeserializeObject<ProvinceDto>(jsonString);

            return province;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByProvince(string provinceId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Province/{provinceId}/Products");
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


        public async Task<IEnumerable<StoreDto>> GetStoresByProvince(string provinceId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Province/{provinceId}/Stores");
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
