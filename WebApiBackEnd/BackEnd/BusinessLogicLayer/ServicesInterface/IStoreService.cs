using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;

namespace BusinessLogicLayer.ServicesInterface
{
    public interface IStoreService
    {
        public Task<IEnumerable<StoreRequest>> GetAllStores();
        public Task<StoreRequest> GetStoreById(int id);
        public Task<StoreRequest> InsertStore(StoreRequestCreate storeDto);
        public Task<StoreRequest> UpdateStore(StoreRequest storeDto);
        public Task<StoreRequest> DeleteStore(StoreRequest storeDto);

        //public Task<IEnumerable<StoreDto>> GetAllStoresByWardId(string wardId);
        Task<IEnumerable<StoreRequest>> GetStoresByCategoryId(int categoryId);
        Task<IEnumerable<StoreRequest>> GetStoresByName(string name);
        Task<StoreDetailDto> GetStoreWithDetailAddress(int storeId);
        Task<IEnumerable<StoreRequest>> GetStoresBySubCategoryPerPage(int subCategoryId, int page, int pageSize);
        Task<IEnumerable<StoreRequest>> GetStoresBySubCategory(int subCategoryId);

    }
}
