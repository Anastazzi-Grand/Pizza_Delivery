using Microsoft.AspNetCore.Mvc;
using PizzaDelivery_V5.Entities.Entities;
using PizzaDelivery_V5.Repositories.Interfaces;

namespace PizzaDelivery_V5.Controllers
{
    [ApiController]
    [Route("api/DAL/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IOrderRepository _orderRepository;

        public OrdersController(ILogger<OrdersController> logger, IOrderRepository orderRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> OrderList()
        {
            var order = await _orderRepository.Get();
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpGet("12345")]
        public async Task<IActionResult> OrderGet(int id)
        {
            var order = await _orderRepository.GetById(id);
            return Ok(order);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddOrder(Order order)
        {
            var result = await _orderRepository.Add(order);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            var result = await _orderRepository.Update(order);
            return Ok(result);
        }

        [HttpDelete("delete/12345")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderRepository.Delete(id);
            return Ok(result);
        }

    }
}
