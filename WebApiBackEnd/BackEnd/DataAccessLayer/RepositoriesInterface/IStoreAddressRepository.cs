using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.RepositoriesInterface
{
    public interface IStoreAddressRepository : IGenericRepository<StoreAddress>
    {
        Task<IEnumerable<StoreAddress>> GetAllStoreAddressByWardId(string wardId);
    }
}
