
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DAL.Controllers
{/*
    [ApiController]
    [Route("api/Order")]
    public class OrdersController : Controller
    {
        private readonly ApplicationContext _context;
        public OrdersController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Order.ToListAsync();
        }

        [HttpGet("GetOrder/{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            if (id != 0)
            {
                var order = await _context.Order.FirstOrDefaultAsync(p => p.Id == id);
                if (order == null) return NotFound();
                return order;
            }
            else return NotFound();
        }

        [HttpPost("PostOrder")]
        public async Task<ActionResult<Order>> PostOrder([FromBody] Order order)
        {
            if (order != null)
            {
                _context.Order.Add(order);
                await _context.SaveChangesAsync();

                return Ok(order);
            }
            else return BadRequest();
        }


        [HttpPut("PutOrder/{id}")]
        public async Task<IActionResult> PutOrder([FromBody] Order order)
        {
            if (!_context.Order.Any(p => p.Id == order.Id)) return NotFound();

            _context.Update(order);
            await _context.SaveChangesAsync();
            return Ok(order);
        }

        [HttpDelete("DeleteOrder/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var _order = _context.Order.FirstOrDefaultAsync(p => p.Id == id);
            _context.Order.Remove(await _order);

            await _context.SaveChangesAsync();
            return Ok(_order);
        }
    }*/
}
