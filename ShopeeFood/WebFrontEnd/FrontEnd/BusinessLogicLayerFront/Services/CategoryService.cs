using BusinessLogicLayerFront.DTOs;
using BusinessLogicLayerFront.Services.Contrast;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerFront.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            var response = await _httpClient.GetAsync("api/category");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var cates = JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(jsonString);

            return cates;
        }

        public Task<CategoryDto> GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
