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
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<DiscountDto>> GetAllDiscounts()
        {
            var response = await _httpClient.GetAsync("api/discount");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var discounts = JsonConvert.DeserializeObject<IEnumerable<DiscountDto>>(jsonString);

            return discounts;
        }

        public async Task<DiscountDto> GetDiscountById(int id)
        {
            var response = await _httpClient.GetAsync($"api/discount/{id}");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var discount = JsonConvert.DeserializeObject<DiscountDto>(jsonString);

            return discount;
        }

        public async Task<IEnumerable<DiscountDto>> GetDiscountByCategoryId(int categoryId)
        {
            var response = await _httpClient.GetAsync($"api/discount/Category/{categoryId}");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var discounts = JsonConvert.DeserializeObject<IEnumerable<DiscountDto>>(jsonString);

            return discounts;
        }
    }
}
