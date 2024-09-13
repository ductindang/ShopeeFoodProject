using AutoMapper;
using BusinessLogicLayer.BaseRequests;
using BusinessLogicLayer.Requests;
using BusinessLogicLayer.ServicesInterface;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.RepositoriesInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderRequest>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAll();
            return _mapper.Map<IEnumerable<OrderRequest>>(orders);
        }

        public async Task<OrderRequest> GetOrderById(int id)
        {
            var order = await _orderRepository.GetById(id);
            return _mapper.Map<OrderRequest>(order);
        }

        public async Task<OrderRequest> InsertOrder(BaseOrder baseOrder)
        {
            baseOrder.OrderDate = DateTime.UtcNow.AddHours(7);
            var order = _mapper.Map<Order>(baseOrder);
            await _orderRepository.Insert(order);
            return _mapper.Map<OrderRequest>(order);
        }

        public async Task<OrderRequest> UpdateOrder(OrderRequest orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.Update(order);
            return orderDto;
        }

        public async Task<OrderRequest> DeleteOrder(OrderRequest orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.Delete(order);
            return orderDto;
        }

        public async Task<IEnumerable<OrderRequest>> GetOrdersByUserId(int userId)
        {
            var orders = await _orderRepository.GetOrdersByUserId(userId);
            return _mapper.Map<IEnumerable<OrderRequest>>(orders);
        }


    }
}
