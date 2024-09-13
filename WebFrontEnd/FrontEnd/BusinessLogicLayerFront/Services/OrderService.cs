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
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrders()
        {
            var response = await _httpClient.GetAsync("api/order");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var orders = JsonConvert.DeserializeObject<IEnumerable<OrderDto>>(jsonString);

            return orders;
        }

        public async Task<OrderDto> GetOrderById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/order/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var order = JsonConvert.DeserializeObject<OrderDto>(jsonString);
                    if (order == null)
                    {
                        return null;
                    }
                    return order;
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
                throw new ApplicationException("An error occurred while fetching the user by email and password.", ex);
            }
        }

        public async Task<OrderDto> InsertOrder(OrderDto baseOrder)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(baseOrder), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/order", content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var order = JsonConvert.DeserializeObject<OrderDto>(jsonString);
                    return order;
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
                throw new ApplicationException("An error occurred while fetching the user by email and password.", ex);
            }
        }

        public Task<OrderDto> UpdateOrder(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> DeleteOrder(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByUserId(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Order/User/{userId}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var orders = JsonConvert.DeserializeObject<IEnumerable<OrderDto>>(jsonString);
                    return orders;
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
