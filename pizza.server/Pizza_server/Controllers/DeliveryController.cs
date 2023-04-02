using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Pizza_server.Controllers
{
        [ApiController]
        [Route("/delivery")]
        public class DeliveryController : ControllerBase
        {
            ApplicationContext db;
            public DeliveryController(ApplicationContext context)
            {
                db = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Delivery>>> Get()
            {
                return await db.Deliveries.ToListAsync();
            }

            // GET api/users/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Delivery>> Get(int Number)
            {
                Delivery delivery = await db.Deliveries.FirstOrDefaultAsync(x => x.Id == Number);
                if (delivery == null)
                    return NotFound();
                return new ObjectResult(delivery);
            }

            // POST api/users
            [HttpPost]
            public async Task<ActionResult<Delivery>> Post(Delivery delivery)
            {
                if (delivery == null)
                {
                    return BadRequest();
                }

                db.Deliveries.Add(delivery);
                await db.SaveChangesAsync();
                return Ok(delivery);
            }

            // PUT api/users/
            [HttpPut]
            public async Task<ActionResult<Delivery>> Put(Delivery delivery)
            {
                if (delivery == null)
                {
                    return BadRequest();
                }
                if (!db.Deliveries.Any(x => x.Id == delivery.Id))
                {
                    return NotFound();
                }

                db.Update(delivery);
                await db.SaveChangesAsync();
                return Ok(delivery);
            }

            // DELETE api/users/5
            [HttpDelete("{Id}")]
            public async Task<ActionResult<Delivery>> Delete(int Id)
            {
                Delivery delivery = db.Deliveries.FirstOrDefault(x => x.Id == Id);
                if (delivery == null)
                {
                    return NotFound();
                }
                db.Deliveries.Remove(delivery);
                await db.SaveChangesAsync();
                return Ok(delivery);
            }
        }

}
