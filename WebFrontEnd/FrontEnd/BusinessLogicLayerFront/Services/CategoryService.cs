using BusinessLogicLayerFront.DTOs;
using BusinessLogicLayerFront.ServicesInterface;
using Newtonsoft.Json;

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

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            var response = await _httpClient.GetAsync($"api/category/{id}");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var cate = JsonConvert.DeserializeObject<CategoryDto>(jsonString);

            return cate;
        }
    }
}
