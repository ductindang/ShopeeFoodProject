using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.RepositoriesInterface
{
    public interface IDistrictRepository : IGenericRepository<District>
    {
        Task<District> GetDistrictById(string id);
        Task<IEnumerable<District>> GetDistrictsByProvince(string provinceId);
    }
}
