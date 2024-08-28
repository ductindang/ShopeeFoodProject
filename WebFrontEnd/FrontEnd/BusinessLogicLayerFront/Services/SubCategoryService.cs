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
    public class SubCategoryService : ISubCategoryService
    {
        private readonly HttpClient _httpClient;

        public SubCategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<SubCategoryDto>> GetAllSubCategory()
        {
            throw new NotImplementedException();
        }

        public async Task<SubCategoryDto> GetSubCategoryById(int id)
        {
            var response = await _httpClient.GetAsync($"api/SubCategory/{id}");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var subCate = JsonConvert.DeserializeObject<SubCategoryDto>(jsonString);

            return subCate;
        }

        public async Task<IEnumerable<SubCategoryDto>> GetSubCategoriesByCategoryId(int categoryId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/SubCategory/Category/{categoryId}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var subCates = JsonConvert.DeserializeObject<IEnumerable<SubCategoryDto>>(jsonString);
                    return subCates;
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
    }
}
