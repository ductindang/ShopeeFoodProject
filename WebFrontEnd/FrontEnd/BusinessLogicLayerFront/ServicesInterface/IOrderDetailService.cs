using BusinessLogicLayerFront.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerFront.ServicesInterface
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetailDto>> GetAllOrderDetail();
        Task<OrderDetailDto> GetOrderDetailById(int id);
        Task<OrderDetailDto> InsertOrderDetail(BaseOrderDetailDto baseOrderDetail);
        Task<OrderDetailDto> UpdateOrderDetail(OrderDetailDto orderDetailDto);
        Task<OrderDetailDto> DeleteOrderDetail(OrderDetailDto orderDetailDto);
        Task<IEnumerable<OrderDetailDto>> GetOrderDetailsByOrder(int orderId);
    }
}
