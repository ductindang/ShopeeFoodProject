using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.RepositoriesInterface
{
    public interface IUserAddressRepository : IGenericRepository<UserAddress>
    {
        Task<IEnumerable<UserAddress>> GetAllUserAddressesByUser(int id);
        Task<UserAddressDetail> GetUserAddressDetailById(int id);
    }
}
