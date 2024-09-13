using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.RepositoriesInterface
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
    {
        Task<IEnumerable<OrderDetail>> GetOrderDetailByOrder(int orderId);
    }
}
