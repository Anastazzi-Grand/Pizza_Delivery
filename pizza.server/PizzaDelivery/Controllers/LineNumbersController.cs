using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PizzaDelivery.Controllers
{
    [ApiController]
    [Route("/lineNumber")]
    public class LineNumbersController : Controller
    {
        private readonly ApplicationContext _context;

        public LineNumbersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/LineNumbers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LineNumber>>> GetLineNumber()
        {
            return await _context.LineNumber.ToListAsync();
        }

        // GET: api/LineNumbers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LineNumber>> GetLineNumber(int id)
        {
            var lineNumber = await _context.LineNumber.FindAsync(id);

            if (lineNumber == null)
            {
                return NotFound();
            }

            return lineNumber;
        }

        // PUT: api/LineNumbers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLineNumber(int id, LineNumber lineNumber)
        {
            if (id != lineNumber.Id)
            {
                return BadRequest();
            }

            _context.Entry(lineNumber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineNumberExists(id))
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

        // POST: api/LineNumbers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LineNumber>> PostLineNumber(LineNumber lineNumber)
        {
            _context.LineNumber.Add(lineNumber);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLineNumber", new { id = lineNumber.Id }, lineNumber);
        }

        // DELETE: api/LineNumbers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLineNumber(int id)
        {
            var lineNumber = await _context.LineNumber.FindAsync(id);
            if (lineNumber == null)
            {
                return NotFound();
            }

            _context.LineNumber.Remove(lineNumber);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LineNumberExists(int id)
        {
            return _context.LineNumber.Any(e => e.Id == id);
        }
    }
}
