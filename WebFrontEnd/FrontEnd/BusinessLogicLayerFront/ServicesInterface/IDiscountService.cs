using BusinessLogicLayerFront.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerFront.ServicesInterface
{
    public interface IDiscountService
    {
        Task<IEnumerable<DiscountDto>> GetAllDiscounts();
        Task<DiscountDto> GetDiscountById(int id);
        Task<IEnumerable<DiscountDto>> GetDiscountByCategoryId(int categoryId);
    }
}
