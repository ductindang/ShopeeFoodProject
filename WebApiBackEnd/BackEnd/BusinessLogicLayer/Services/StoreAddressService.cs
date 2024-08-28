using AutoMapper;
using BusinessLogicLayer.BaseRequests;
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
    public class StoreAddressService : IStoreAddressService
    {
        private readonly IStoreAddressRepository _storeAddressRepository;
        private readonly IMapper _mapper;

        public StoreAddressService(IStoreAddressRepository storeAddressRepository, IMapper mapper)
        {
            _storeAddressRepository = storeAddressRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StoreAddressRequest>> GetAllStoreAddresses()
        {
            var storeAddresses = await _storeAddressRepository.GetAll();
            return _mapper.Map<IEnumerable<StoreAddressRequest>>(storeAddresses);
        }

        public async Task<StoreAddressRequest> GetStoreAddressById(int id)
        {
            var storeAddress = await _storeAddressRepository.GetById(id);
            return _mapper.Map<StoreAddressRequest>(storeAddress);
        }

        public async Task<StoreAddressRequest> InsertStoreAddress(BaseStoreAddress storeAddressDto)
        {
            var storeAddress = _mapper.Map<StoreAddress>(storeAddressDto);
            await _storeAddressRepository.Insert(storeAddress);
            return _mapper.Map<StoreAddressRequest>(storeAddress);
        }

        public async Task<StoreAddressRequest> UpdateStoreAddress(StoreAddressRequest storeAddressDto)
        {
            var storeAddress = _mapper.Map<StoreAddress>(storeAddressDto);
            await _storeAddressRepository.Update(storeAddress);
            return storeAddressDto;
        }

        public async Task<StoreAddressRequest> DeleteStoreAddress(StoreAddressRequest storeAddressDto)
        {
            var storeAddress = _mapper.Map<StoreAddress>(storeAddressDto);
            await _storeAddressRepository.Delete(storeAddress);
            return storeAddressDto;
        }

        public async Task<IEnumerable<StoreAddressRequest>> GetAllStoreAddressesByWardId(string wardId)
        {
            var storeAddress = await _storeAddressRepository.GetAllStoreAddressByWardId(wardId);
            return _mapper.Map<IEnumerable<StoreAddressRequest>>(storeAddress);
        }

        

    }
}
