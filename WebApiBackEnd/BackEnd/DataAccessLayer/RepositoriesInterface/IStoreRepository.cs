using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.RepositoriesInterface
{
    public interface IStoreRepository : IGenericRepository<Store>
    {
        Task<IEnumerable<Store>> GetStoresByCategoryId(int categoryId);
        Task<IEnumerable<Store>> GetStoresByName(string name);
        Task<StoreDetail> GetStoreWithDetailAddress(int storeId);
        Task<IEnumerable<Store>> GetStoresBySubCategoryPerPage(int subCategoryId, int page, int pageSize);
        Task<IEnumerable<Store>> GetStoresBySubCategory(int subCategoryId);
    }
}
