using BusinessLogicLayer.BaseRequests;
using BusinessLogicLayer.Requests;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.ServicesInterface
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderRequest>> GetAllOrders();
        public Task<OrderRequest> GetOrderById(int id);
        public Task<OrderRequest> InsertOrder(BaseOrder baseOrder);
        public Task<OrderRequest> UpdateOrder(OrderRequest orderDto);
        public Task<OrderRequest> DeleteOrder(OrderRequest orderDto);
        Task<IEnumerable<OrderRequest>> GetOrdersByUserId(int userId);
    }
}
