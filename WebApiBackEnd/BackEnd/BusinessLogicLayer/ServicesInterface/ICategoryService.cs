using BusinessLogicLayer.BaseRequests;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;

namespace BusinessLogicLayer.ServicesInterface
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryRequest>> GetAllCategories();
        public Task<CategoryRequest> GetCategoryById(int id);
        public Task<CategoryRequest> InsertCategory(BaseCategory baseCategory);
        public Task<CategoryRequest> UpdateCategory(CategoryRequest baseCategory);
        public Task<CategoryRequest> DeleteCategoryById(int id);
        public Task<int> Save();
    }
}
