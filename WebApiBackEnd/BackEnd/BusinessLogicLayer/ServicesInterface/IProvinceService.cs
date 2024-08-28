using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServicesInterface
{
    public interface IProvinceService
    {
        Task<IEnumerable<ProvinceRequest>> GetAllProvinces();
        Task<ProvinceRequest> GetProvinceById(string id);
        
    }
}
