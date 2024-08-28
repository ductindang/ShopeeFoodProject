using BusinessLogicLayer.Requests;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServicesInterface
{
    public interface IDiscountService
    {
        Task<IEnumerable<DiscountRequest>> GetAllDiscounts();
        Task<DiscountRequest> GetDiscountById(int id);
        
    }
}
