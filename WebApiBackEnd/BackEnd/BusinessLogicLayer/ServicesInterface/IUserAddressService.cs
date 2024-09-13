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
    public interface IUserAddressService
    {
        Task<IEnumerable<UserAddressRequest>> GetAllUserAddresses();
        Task<UserAddressRequest> GetUserAddressById(int id);
        Task<UserAddressRequest> InsertUserAddress(BaseUserAddress userAddress);
        Task<UserAddressRequest> UpdateUserAddress(UserAddressRequest userAddressDto);
        Task<UserAddressRequest> DeleteUserAddress(UserAddressRequest userAddressDto);
        Task<IEnumerable<UserAddressRequest>> GetAllUserAddressesByUser(int userId);
        Task<UserAddressDetailDto> GetUserAddressDetailById(int id);
    }
}
