using BusinessLogicLayerFront.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerFront.ServicesInterface
{
    public interface IStoreService
    {
        Task<IEnumerable<StoreDto>> GetAllStores();
        Task<StoreDto> GetStoreById(int id);
        Task<IEnumerable<StoreDto>> GetStoresByCategoryId(int categoryId);
        //Task<IEnumerable<StoreDto>> GetStoresByName(string name);
        Task<StoreDetailDto> GetStoreWithDetailAddress(int storeId);
        Task<IEnumerable<StoreDto>> GetStoresBySubCategory(int subCategoryId);
    }
}
