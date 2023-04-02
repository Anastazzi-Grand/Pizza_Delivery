using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.Models;
using PizzaDelivery.Services;

namespace PizzaDelivery.Controllers
{
    [ApiController]
    [Route("/products")]
    public class ProductController : Controller
    {

        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts() { 
            var products = await _productService.GetProducts();
            return products;
        }
    }
}
