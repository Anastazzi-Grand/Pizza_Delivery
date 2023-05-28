using Microsoft.AspNetCore.Mvc;
using PizzaDelivery_V5.Entities.Entities;
using PizzaDelivery_V5.Repositories.Interfaces;

namespace PizzaDelivery_V5.Controllers
{
    [ApiController]
    [Route("/productProperties")]
    public class ProductPropertiesController : ControllerBase
    {
        private readonly ILogger<ProductPropertiesController> _logger;
        private readonly IProductPropertiesRepository _productPropertiesRepository;

        public ProductPropertiesController(ILogger<ProductPropertiesController> logger, IProductPropertiesRepository productPropertiesRepository)
        {
            _logger = logger;
            _productPropertiesRepository = productPropertiesRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> ProductPropertiesList()
        {
            var productProperties = await _productPropertiesRepository.Get();
            if (productProperties == null) return NotFound();
            return Ok(productProperties);
        }

        [HttpGet("12345")]
        public async Task<IActionResult> ProductPropertiesGet(int id)
        {
            var productProperties = await _productPropertiesRepository.GetById(id);
            return Ok(productProperties);
        }

        [HttpGet("name")]
        public async Task<IActionResult> ProductPropertiesGet(string name)
        {
            var productProperties = await _productPropertiesRepository.GetByNameEntity(name);
            return Ok(productProperties);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProductProperties(ProductProperties productProperties)
        {
            var result = await _productPropertiesRepository.Add(productProperties);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProductProperties(ProductProperties productProperties)
        {
            var result = await _productPropertiesRepository.Update(productProperties);
            return Ok(result);
        }

        [HttpDelete("delete/12345")]
        public async Task<IActionResult> DeleteProductProperties(int id)
        {
            var result = await _productPropertiesRepository.Delete(id);
            return Ok(result);
        }
    }
}
