using Pizza_server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Pizza_server.Controllers
{
    [ApiController]
    [Route("/order")]
    public class OrderController : ControllerBase
    {
        ApplicationContext db;
        public OrderController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            return await db.Orders.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int Number)
        {
            Order order = await db.Orders.FirstOrDefaultAsync(x => x.Id == Number);
            if (order == null)
                return NotFound();
            return new ObjectResult(order);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Order>> Post(Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            db.Orders.Add(order);
            await db.SaveChangesAsync();
            return Ok(order);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Order>> Put(Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            if (!db.Orders.Any(x => x.Id == order.Id))
            {
                return NotFound();
            }

            db.Update(order);
            await db.SaveChangesAsync();
            return Ok(order);
        }

        // DELETE api/users/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Order>> Delete(int Id)
        {
            Order order = db.Orders.FirstOrDefault(x => x.Id == Id);
            if (order == null)
            {
                return NotFound();
            }
            db.Orders.Remove(order);
            await db.SaveChangesAsync();
            return Ok(order);
        }
    }
}