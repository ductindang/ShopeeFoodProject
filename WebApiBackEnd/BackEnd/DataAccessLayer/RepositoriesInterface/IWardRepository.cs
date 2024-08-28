using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.RepositoriesInterface
{
    public interface IWardRepository : IGenericRepository<Ward>
    {
        Task<Ward> GetWardById(string id);
        Task<IEnumerable<Ward>> GetWardsByDistrict(string districtId);
    }
}
