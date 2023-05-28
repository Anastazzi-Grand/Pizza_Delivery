using Microsoft.AspNetCore.Mvc;
using PizzaDelivery_V5.Entities.Entities;
using PizzaDelivery_V5.Repositories.Interfaces;

namespace PizzaDelivery_V5.Controllers
{
    [ApiController]
    [Route("/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductRepository _productRepository;

        public ProductsController(ILogger<ProductsController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> ProductList()
        {
            var product = await _productRepository.Get();
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet("12345")]
        public async Task<IActionResult> ProductGet(int id)
        {
            var product = await _productRepository.GetById(id);
            return Ok(product);
        }

        [HttpGet("name")]
        public async Task<IActionResult> ProductGet(string name)
        {
            var product = await _productRepository.GetByNameEntity(name);
            return Ok(product);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var result = await _productRepository.Add(product);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var result = await _productRepository.Update(product);
            return Ok(result);
        }

        [HttpDelete("delete/12345")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productRepository.Delete(id);
            return Ok(result);
        }
    }
}
