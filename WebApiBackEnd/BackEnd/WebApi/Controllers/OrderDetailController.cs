using BusinessLogicLayer.BaseRequests;
using BusinessLogicLayer.Requests;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.ServicesInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetailRequest>>> GetAllOrderDetails()
        {
            var orderDetails = await _orderDetailService.GetAllOrderDetails();
            return Ok(orderDetails);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetailRequest>> GetOrderDetailById(int id)
        {
            var orderDetail = await _orderDetailService.GetOrderDetailById(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return Ok(orderDetail);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDetailRequest>> InsertOrderDetail([FromBody] BaseOrderDetail baseOrderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderDetail = await _orderDetailService.InsertOrderDetail(baseOrderDetail);

            if (orderDetail == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetOrderDetailById), new { id = orderDetail.Id }, orderDetail);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrderDetail([FromBody] OrderDetailRequest orderDetailRequest, int id)
        {
            var existingOrderDetail = await _orderDetailService.GetOrderDetailById(id);
            if (existingOrderDetail == null)
            {
                return NotFound();
            }

            orderDetailRequest.Id = id;
            // Assuming this takes StoreDto
            await _orderDetailService.UpdateOrderDetail(orderDetailRequest);

            return Ok(orderDetailRequest);
        }

        [HttpGet("Order/{orderId}")]
        public async Task<ActionResult> GetOrderDetailByOrder(int orderId)
        {
            var orderDetails = await _orderDetailService.GetOrderDetailByOrder(orderId);
            return Ok(orderDetails);
        }
    }
}
