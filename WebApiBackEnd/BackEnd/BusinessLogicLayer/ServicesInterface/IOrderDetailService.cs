using BusinessLogicLayer.BaseRequests;
using BusinessLogicLayer.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServicesInterface
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetailRequest>> GetAllOrderDetails();
        Task<OrderDetailRequest> GetOrderDetailById(int id);
        Task<OrderDetailRequest> InsertOrderDetail(BaseOrderDetail baseOrderDetail);
        Task<OrderDetailRequest> UpdateOrderDetail(OrderDetailRequest orderDetailDto);
        Task<OrderDetailRequest> DeleteOrderDetail(OrderDetailRequest orderDetailDto);
        Task<IEnumerable<OrderDetailRequest>> GetOrderDetailByOrder(int orderId);
    }
}
