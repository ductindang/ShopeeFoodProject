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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderRequest>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderRequest>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<OrderRequest>> InsertOrder([FromBody] BaseOrder baseOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = await _orderService.InsertOrder(baseOrder);

            if (order == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder([FromBody] OrderRequest orderRequest, int id)
        {
            var existingOrder = await _orderService.GetOrderById(id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            orderRequest.Id = id;
            await _orderService.UpdateOrder(orderRequest);

            return Ok(orderRequest);
        }

        [HttpGet("User/{userId}")]
        public async Task<ActionResult> GetOrdersByUserId(int userId)
        {
            var orders = await _orderService.GetOrdersByUserId(userId);
            return Ok(orders);
        }
    }
}
