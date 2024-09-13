using BusinessLogicLayerFront.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerFront.ServicesInterface
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrders();
        Task<OrderDto> GetOrderById(int id);
        Task<OrderDto> InsertOrder(OrderDto baseOrder);
        Task<OrderDto> UpdateOrder(OrderDto orderDto);
        Task<OrderDto> DeleteOrder(OrderDto orderDto);
        Task<IEnumerable<OrderDto>> GetOrdersByUserId(int userId);
    }
}
