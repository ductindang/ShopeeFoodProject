using BusinessLogicLayerFront.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerFront.ServicesInterface
{
    public interface IUserAddressService
    {
        Task<IEnumerable<UserAddressDto>> GetAllUserAddressesByUser(int userId);
        Task<UserAddressDetailDto> GetUserAddressDetail(int id);
        Task<UserAddressDto> InsertUserAddress(UserAddressDto userAddressDto);
    }
}
