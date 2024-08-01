using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDto>> GetAllCategories();
        public Task<CategoryDto> GetCategoryById(int id);
        public Task<CategoryDto> InsertCategory(CategoryDto category);
        public Task<CategoryDto> UpdateCategory(CategoryDto category);
        public Task<CategoryDto> DeleteCategoryById(int id);
        public Task<int> Save();
    }
}
