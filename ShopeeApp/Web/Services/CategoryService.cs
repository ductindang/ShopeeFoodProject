using Web.Data;
using Web.Models;
using Web.Repositories.Contrast;
using Web.Services.Contracts;

namespace Web.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly ApplicationDbContext _context;

        public CategoryService(IGenericRepository<Category> categoryRepository, ApplicationDbContext context)
        {
            _categoryRepository = categoryRepository;
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public Task<Category> GetById(int id)
        {
            throw new NotImplementedException();
        }



        public Task<Category> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

       

        public Task<Category> Insert(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<int> Save()
        {
            throw new NotImplementedException();
        }

        public Task<Category> Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
