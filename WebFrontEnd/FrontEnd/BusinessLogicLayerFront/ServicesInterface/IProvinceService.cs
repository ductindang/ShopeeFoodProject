using BusinessLogicLayerFront.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerFront.ServicesInterface
{
    public interface IProvinceService
    {
        Task<IEnumerable<ProvinceDto>> GetAllProvinces();
        Task<ProvinceDto> GetProvinceById(string id);
        Task<IEnumerable<ProductDto>> GetProductsByProvince(string provinceId);
        Task<IEnumerable<StoreDto>> GetStoresByProvince(string provinceId);
    }
}
