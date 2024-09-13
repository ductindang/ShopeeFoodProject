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
    public class MenuService : IMenuService
    {
        private readonly HttpClient _httpClient;

        public MenuService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<MenuDto>> GetAllMenu()
        {
            var response = await _httpClient.GetAsync("api/Menu");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var menus = JsonConvert.DeserializeObject<IEnumerable<MenuDto>>(jsonString);

            return menus;
        }

        public async Task<MenuDto> GetMenuById(int id)
        {
            var response = await _httpClient.GetAsync($"api/Menu/{id}");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var menu = JsonConvert.DeserializeObject<MenuDto>(jsonString);

            return menu;
        }

        public async Task<IEnumerable<MenuDto>> GetMenusByStore(int storeId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Menu/Store/{storeId}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var menus = JsonConvert.DeserializeObject<IEnumerable<MenuDto>>(jsonString);
                    return menus;
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

        public async Task<IEnumerable<ProductDto>> GetProductsByMenu(int menuId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Menu/{menuId}/Products");
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
    }
}
