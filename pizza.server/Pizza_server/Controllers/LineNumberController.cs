using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Pizza_server.Controllers
{ 
        [ApiController]
        [Route("/lineNumber")]
        public class LineNumberController : ControllerBase
        {
            ApplicationContext db;
            public LineNumberController(ApplicationContext context)
            {
                db = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<LineNumber>>> Get()
            {
                return await db.LineNumbers.ToListAsync();
            }

            // GET api/users/5
            [HttpGet("{id}")]
            public async Task<ActionResult<LineNumber>> Get(int Number)
            {
                LineNumber lineNumber = await db.LineNumbers.FirstOrDefaultAsync(x => x.Id == Number);
                if (lineNumber == null)
                    return NotFound();
                return new ObjectResult(lineNumber);
            }

            // POST api/users
            [HttpPost]
            public async Task<ActionResult<LineNumber>> Post(LineNumber lineNumber)
            {
                if (lineNumber == null)
                {
                    return BadRequest();
                }

                db.LineNumbers.Add(lineNumber);
                await db.SaveChangesAsync();
                return Ok(lineNumber);
            }

            // PUT api/users/
            [HttpPut]
            public async Task<ActionResult<LineNumber>> Put(LineNumber lineNumber)
            {
                if (lineNumber == null)
                {
                    return BadRequest();
                }
                if (!db.LineNumbers.Any(x => x.Id == lineNumber.Id))
                {
                    return NotFound();
                }

                db.Update(lineNumber);
                await db.SaveChangesAsync();
                return Ok(lineNumber);
            }

            // DELETE api/users/5
            [HttpDelete("{Id}")]
            public async Task<ActionResult<LineNumber>> Delete(int Id)
            {
                LineNumber lineNumber = db.LineNumbers.FirstOrDefault(x => x.Id == Id);
                if (lineNumber == null)
                {
                    return NotFound();
                }
                db.LineNumbers.Remove(lineNumber);
                await db.SaveChangesAsync();
                return Ok(lineNumber);
            }
        }
}
