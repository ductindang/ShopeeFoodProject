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
    public class UserAddressService : IUserAddressService
    {
        private readonly HttpClient _httpClient;

        public UserAddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserAddressDto> InsertUserAddress(UserAddressDto userAddressDto)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(userAddressDto), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/UserAddress", content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var userAddress = JsonConvert.DeserializeObject<UserAddressDto>(jsonString);
                    return userAddress;
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

        public async Task<IEnumerable<UserAddressDto>> GetAllUserAddressesByUser(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/UserAddress/User/{userId}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var userAddresses = JsonConvert.DeserializeObject<IEnumerable<UserAddressDto>>(jsonString);
                    return userAddresses;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new ApplicationException("An error occurred while fetching the products by category id.", ex);
            }
        }

        public async Task<UserAddressDetailDto> GetUserAddressDetail(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/UserAddress/{id}/UserAddressDetail");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var userDetail = JsonConvert.DeserializeObject<UserAddressDetailDto>(jsonString);
                    return userDetail;
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
