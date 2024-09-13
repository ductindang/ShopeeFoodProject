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
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDetailRequest>> GetAllOrderDetails()
        {
            var orderDetails = await _orderDetailRepository.GetAll();
            return _mapper.Map<IEnumerable<OrderDetailRequest>>(orderDetails);
        }

        public async Task<OrderDetailRequest> GetOrderDetailById(int id)
        {
            var orderDetail = await _orderDetailRepository.GetById(id);
            return _mapper.Map<OrderDetailRequest>(orderDetail);
        }

        public async Task<OrderDetailRequest> InsertOrderDetail(BaseOrderDetail baseOrderDetail)
        {
            var orderDetail = _mapper.Map<OrderDetail>(baseOrderDetail);
            await _orderDetailRepository.Insert(orderDetail);
            return _mapper.Map<OrderDetailRequest>(orderDetail);
        }

        public async Task<OrderDetailRequest> UpdateOrderDetail(OrderDetailRequest orderDetailDto)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailDto);
            await _orderDetailRepository.Update(orderDetail);
            return orderDetailDto;
        }
        public async Task<OrderDetailRequest> DeleteOrderDetail(OrderDetailRequest orderDetailDto)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailDto);
            await _orderDetailRepository.Delete(orderDetail);
            return orderDetailDto;
        }

        public async Task<IEnumerable<OrderDetailRequest>> GetOrderDetailByOrder(int orderId)
        {
            var orderDetails = await _orderDetailRepository.GetOrderDetailByOrder(orderId);
            return _mapper.Map<IEnumerable<OrderDetailRequest>>(orderDetails);
        }

    }
}
