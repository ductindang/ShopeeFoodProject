using BusinessLogicLayer.BaseRequests;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServicesInterface
{
    public interface IStoreAddressService
    {
        public Task<IEnumerable<StoreAddressRequest>> GetAllStoreAddresses();
        public Task<StoreAddressRequest> GetStoreAddressById(int id);
        public Task<StoreAddressRequest> InsertStoreAddress(BaseStoreAddress storeAddressDto);
        public Task<StoreAddressRequest> UpdateStoreAddress(StoreAddressRequest storeAddressDto);
        public Task<StoreAddressRequest> DeleteStoreAddress(StoreAddressRequest storeAddressDto);
        public Task<IEnumerable<StoreAddressRequest>> GetAllStoreAddressesByWardId(string wardId);
    }
}
