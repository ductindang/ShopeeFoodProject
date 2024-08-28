using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServicesInterface
{
    public interface IDistrictService
    {
        Task<IEnumerable<DistrictRequest>> GetAllDistricts();
        Task<DistrictRequest> GetDistrictById(string id);
        Task<IEnumerable<DistrictRequest>> GetDistrictsByProvince(string provinceId);
    }
}
