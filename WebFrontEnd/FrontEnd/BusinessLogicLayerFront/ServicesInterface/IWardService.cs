using BusinessLogicLayerFront.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerFront.ServicesInterface
{
    public interface IWardService
    {
        Task<IEnumerable<WardDto>> GetAllWards();
        Task<WardDto> GetWardById(string id);
        Task<IEnumerable<WardDto>> GetWardsByDistrict(string districtId);
    }
}
