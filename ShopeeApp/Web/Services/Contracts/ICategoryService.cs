using Web.Models;

namespace Web.Services.Contracts
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAll();
        public Task<Category> GetById(int id);
        public Task<Category> Insert(Category category);
        public Task<Category> Update(Category category);
        public Task<Category> DeleteById(int id);
        public Task<int> Save();
    }
}
