using Microsoft.AspNetCore.Mvc;
using PizzaDelivery_V5.Entities.Entities;
using PizzaDelivery_V5.Repositories.Interfaces;

namespace PizzaDelivery_V5.Controllers
{
    [ApiController]
    [Route("/orderItems")]
    public class OrderItemsController : ControllerBase
    {
        private readonly ILogger<OrderItemsController> _logger;
        private readonly IOrderItemsRepository _orderItemsRepository;

        public OrderItemsController(ILogger<OrderItemsController> logger, IOrderItemsRepository orderItemsRepository)
        {
            _logger = logger;
            _orderItemsRepository = orderItemsRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> OrderItemList()
        {
            var orderItems = await _orderItemsRepository.Get();
            if (orderItems == null) return NotFound();
            return Ok(orderItems);
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddOrderItem(OrderItems orderItems)
        {
            var result = await _orderItemsRepository.Add(orderItems);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateOrderItem(OrderItems orderItems)
        {
            var result = await _orderItemsRepository.Update(orderItems);
            return Ok(result);
        }

        [HttpDelete("delete/12345")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            var result = await _orderItemsRepository.Delete(id);
            return Ok(result);
        }
    }
}
