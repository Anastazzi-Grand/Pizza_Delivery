using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Models;

namespace PizzaDelivery.Controllers
{
    [ApiController]
    [Route("/sizes")]
    public class SizesController : Controller
    {
        private readonly ApplicationContext _context;

        public SizesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Sizess
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sizes>>> GetSizes()
        {
            return await _context.Sizes.ToListAsync();
        }

        // GET: api/Sizess/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sizes>> GetSizes(int id)
        {
            var sizes = await _context.Sizes.FindAsync(id);

            if (sizes == null)
            {
                return NotFound();
            }

            return sizes;
        }

        // PUT: api/Sizess/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSizes(int id, Sizes sizes)
        {
            if (id != sizes.Id)
            {
                return BadRequest();
            }

            _context.Entry(sizes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SizesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sizess
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sizes>> PostSizes(Sizes sizes)
        {
            _context.Sizes.Add(sizes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSizes", new { id = sizes.Id }, sizes);
        }

        // DELETE: api/Sizess/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSizes(int id)
        {
            var sizes = await _context.Sizes.FindAsync(id);
            if (sizes == null)
            {
                return NotFound();
            }

            _context.Sizes.Remove(sizes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SizesExists(int id)
        {
            return _context.Sizes.Any(e => e.Id == id);
        }
    }
}
