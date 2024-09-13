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
    public class OrderDetailService : IOrderDetailService
    {
        private readonly HttpClient _httpClient;

        public OrderDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<OrderDetailDto>> GetAllOrderDetail()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetailDto> GetOrderDetailById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderDetailDto> InsertOrderDetail(BaseOrderDetailDto baseOrderDetail)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(baseOrderDetail), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/OrderDetail", content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var orderDetail = JsonConvert.DeserializeObject<OrderDetailDto>(jsonString);
                    return orderDetail;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new ApplicationException("An error occurred while fetching the user by email and password.", ex);
            }
        }

        public Task<OrderDetailDto> UpdateOrderDetail(OrderDetailDto orderDetailDto)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetailDto> DeleteOrderDetail(OrderDetailDto orderDetailDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderDetailDto>> GetOrderDetailsByOrder(int orderId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/OrderDetail/Order/{orderId}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var orderDetails = JsonConvert.DeserializeObject<IEnumerable<OrderDetailDto>>(jsonString);
                    return orderDetails;
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
