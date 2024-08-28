using BusinessLogicLayerFront.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerFront.ServicesInterface
{
    public interface IDistrictService
    {
        Task<IEnumerable<DistrictDto>> GetAllDistricts();
        Task<DistrictDto> GetDistrictById(string id);
        Task<IEnumerable<ProductDto>> GetProductsByDistrict(string districId, int categoryId);
        Task<IEnumerable<DistrictDto>> GetDistrictsByProvince(string provinceId);
        Task<IEnumerable<StoreDto>> GetStoresByDistrict(string districId, int categoryId);

    }
}
