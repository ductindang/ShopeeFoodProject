using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.RepositoriesInterface
{
    public interface ISubCategoryRepository : IGenericRepository<SubCategory>
    {
        Task<IEnumerable<SubCategory>> GetSubCategoriesByCategoryId(int categoryId);
    }
}
