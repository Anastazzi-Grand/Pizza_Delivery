using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Pizza_server.Controllers
{
        [ApiController]
        [Route("/pizza")]
        public class PizzaController : ControllerBase
        {
            ApplicationContext db;
            public PizzaController(ApplicationContext context)
            {
                db = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Pizza>>> Get()
            {
                return await db.Pizzas.ToListAsync();
            }

            // GET api/users/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Pizza>> Get(int Number)
            {
                Pizza pizza = await db.Pizzas.FirstOrDefaultAsync(x => x.Id == Number);
                if (pizza == null)
                    return NotFound();
                return new ObjectResult(pizza);
            }

            // POST api/users
            [HttpPost]
            public async Task<ActionResult<Pizza>> Post(Pizza pizza)
            {
                if (pizza == null)
                {
                    return BadRequest();
                }

                db.Pizzas.Add(pizza);
                await db.SaveChangesAsync();
                return Ok(pizza);
            }

            // PUT api/users/
            [HttpPut]
            public async Task<ActionResult<Pizza>> Put(Pizza pizza)
            {
                if (pizza == null)
                {
                    return BadRequest();
                }
                if (!db.Clients.Any(x => x.Id == pizza.Id))
                {
                    return NotFound();
                }

                db.Update(pizza);
                await db.SaveChangesAsync();
                return Ok(pizza);
            }

            // DELETE api/users/5
            [HttpDelete("{Id}")]
            public async Task<ActionResult<Pizza>> Delete(int Id)
            {
                Pizza pizza = db.Pizzas.FirstOrDefault(x => x.Id == Id);
                if (pizza == null)
                {
                    return NotFound();
                }
                db.Pizzas.Remove(pizza);
                await db.SaveChangesAsync();
                return Ok(pizza);
            }
        }
}
