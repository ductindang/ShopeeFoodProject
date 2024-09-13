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
    public class WardService : IWardService
    {
        private readonly HttpClient _httpClient;

        public WardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<WardDto>> GetAllWards()
        {
            throw new NotImplementedException();
        }

        public Task<WardDto> GetWardById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WardDto>> GetWardsByDistrict(string districtId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Ward/District/{districtId}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var wards = JsonConvert.DeserializeObject<IEnumerable<WardDto>>(jsonString);
                    return wards;
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
