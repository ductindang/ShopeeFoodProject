using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;
using BusinessLogicLayer.ServicesInterface;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.RepositoriesInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public StoreService(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StoreRequest>> GetAllStores()
        {
            var stores = await _storeRepository.GetAll();
            return _mapper.Map<IEnumerable<StoreRequest>>(stores);
        }

        public async Task<StoreRequest> GetStoreById(int id)
        {
            var store = await _storeRepository.GetById(id);
            return _mapper.Map<StoreRequest>(store);
        }

        public async Task<StoreRequest> InsertStore(StoreRequestCreate storeRequest)
        {
            var store = new Store
            {
                Name = storeRequest.Name,
                Image = storeRequest.Image,
                OpenTime = TimeSpan.Parse(storeRequest.OpenTime),  
                CloseTime = TimeSpan.Parse(storeRequest.CloseTime),
                Description = storeRequest.Description
            };

            var newStore = await _storeRepository.Insert(store);
            return _mapper.Map<StoreRequest>(newStore);
        }

        public async Task<StoreRequest> UpdateStore(StoreRequest storeRequest)
        {
            var store = new Store
            {
                Id = storeRequest.Id,
                Name = storeRequest.Name,
                Image = storeRequest.Image,
                OpenTime = TimeSpan.Parse(storeRequest.OpenTime),  
                CloseTime = TimeSpan.Parse(storeRequest.CloseTime), 
                Description = storeRequest.Description
            };
            await _storeRepository.Update(store);
            return storeRequest;
        }

        public async Task<StoreRequest> DeleteStore(StoreRequest storeRequest)
        {
            var store = _mapper.Map<Store>(storeRequest);
            await _storeRepository.Delete(store);
            return storeRequest;
        }

        //public async Task<IEnumerable<StoreDto>> GetAllStoresByWardId(string wardId)
        //{
        //    var stores = await _storeRepository.GetAllStoresByWardId(wardId);
        //    if(stores == null)
        //    {
        //        return null;
        //    }
        //    return _mapper.Map<IEnumerable<StoreDto>>(stores);
        //}


        public async Task<IEnumerable<StoreRequest>> GetStoresByCategoryId(int categoryId)
        {
            var stores = await _storeRepository.GetStoresByCategoryId(categoryId);
            return _mapper.Map<IEnumerable<StoreRequest>>(stores);
        }

        public async Task<IEnumerable<StoreRequest>> GetStoresByName(string name)
        {
            var stores = await _storeRepository.GetStoresByName(name);
            return _mapper.Map<IEnumerable<StoreRequest>>(stores);
        }

        public async Task<StoreDetailDto> GetStoreWithDetailAddress(int storeId, int storeAddressId, string wardId)
        {
            var store = await _storeRepository.GetStoreWithDetailAddress(storeId, storeAddressId, wardId);
            return _mapper.Map<StoreDetailDto>(store);
        }

        public async Task<IEnumerable<StoreRequest>> GetStoresBySubCategoryPerPage(int subCategoryId, int page, int pageSize)
        {
            var stores = await _storeRepository.GetStoresBySubCategoryPerPage(subCategoryId, page, pageSize);
            return _mapper.Map<IEnumerable<StoreRequest>>(stores);
        }

        public async Task<IEnumerable<StoreRequest>> GetStoresBySubCategory(int subCategoryId)
        {
            var stores = await _storeRepository.GetStoresBySubCategory(subCategoryId);
            return _mapper.Map<IEnumerable<StoreRequest>>(stores);
        }

        public async Task<IEnumerable<StoreMenuProductDetailDto>> GetStoreMenuProductDetails(int storeId)
        {
            var storeMenuProduct = await _storeRepository.GetStoreMenuProductDetails(storeId);
            return _mapper.Map<IEnumerable<StoreMenuProductDetailDto>>(storeMenuProduct);
        }
    }
}
