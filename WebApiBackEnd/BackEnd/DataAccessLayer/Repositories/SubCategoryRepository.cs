using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.RepositoriesInterface;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class SubCategoryRepository : GenericRepository<SubCategory>, ISubCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public SubCategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubCategory>> GetSubCategoriesByCategoryId(int categoryId)
        {
            var subCates = await _context.SubCategories
                .Where(sub => sub.CategoryId == categoryId)
                .ToListAsync();
            return subCates;
        }
    }
}
