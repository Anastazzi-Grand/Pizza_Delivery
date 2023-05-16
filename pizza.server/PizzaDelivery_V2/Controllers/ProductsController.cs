using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaDelivery_V2.BLL.Interfaces;

namespace DAL.Controllers
{

    [ApiController]
    [Route("api/Product")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var response = await _productService.GetProducts();
            return Ok(response);
        }
        /*
        [HttpGet("/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            if (id != 0)
            {
                var product = await _context.Product.FirstOrDefaultAsync(p => p.Id == id);
                if (product == null) return NotFound();
                return product;
            }
            else return NotFound();
        }

        [HttpPost("PostProduct")]
        public async Task<ActionResult<Product>> PostProduct([FromBody] Product product)
        {
            if (product != null)
            {
                _context.Product.Add(product);
                await _context.SaveChangesAsync();

                return Ok(product);
            }
            else return BadRequest();
        }


        [HttpPut("PutProduct/{id}")]
        public async Task<IActionResult> PutProduct([FromBody] Product product)
        {
            if (!_context.Product.Any(p => p.Id == product.Id)) return NotFound();

            _context.Update(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var _product = _context.Product.FirstOrDefaultAsync(p => p.Id == id);
            _context.Product.Remove(await _product);

            await _context.SaveChangesAsync();
            return Ok(_product);
        }
    }*/
    }
}