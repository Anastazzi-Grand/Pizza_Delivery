using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Pizza_server.Controllers
{
        [ApiController]
        [Route("/post")]
        public class PostController : ControllerBase
        {
            ApplicationContext db;
            public PostController(ApplicationContext context)
            {
                db = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Post>>> Get()
            {
                return await db.Posts.ToListAsync();
            }

            // GET api/users/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Post>> Get(int Number)
            {
                Post post = await db.Posts.FirstOrDefaultAsync(x => x.Id == Number);
                if (post == null)
                    return NotFound();
                return new ObjectResult(post);
            }

            // POST api/users
            [HttpPost]
            public async Task<ActionResult<Post>> Post(Post post)
            {
                if (post == null)
                {
                    return BadRequest();
                }

                db.Posts.Add(post);
                await db.SaveChangesAsync();
                return Ok(post);
            }

            // PUT api/users/
            [HttpPut]
            public async Task<ActionResult<Post>> Put(Post post)
            {
                if (post == null)
                {
                    return BadRequest();
                }
                if (!db.Clients.Any(x => x.Id == post.Id))
                {
                    return NotFound();
                }

                db.Update(post);
                await db.SaveChangesAsync();
                return Ok(post);
            }

            // DELETE api/users/5
            [HttpDelete("{Id}")]
            public async Task<ActionResult<Post>> Delete(int Id)
            {
                Post post = db.Posts.FirstOrDefault(x => x.Id == Id);
                if (post == null)
                {
                    return NotFound();
                }
                db.Posts.Remove(post);
                await db.SaveChangesAsync();
                return Ok(post);
            }
        }
}
