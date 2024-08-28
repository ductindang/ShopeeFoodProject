using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServicesInterface
{
    public interface IWardService
    {
        Task<IEnumerable<WardRequest>> GetAllWards();
        Task<WardRequest> GetWardById(string id);
        Task<IEnumerable<WardRequest>> GetWardsByDistrict(string districtId);
    }
}
