using Microsoft.AspNetCore.Mvc;
using PizzaDelivery_V5.Entities.Entities;

namespace PizzaDelivery_V5.BLL.Controllers
{
    [ApiController]
    [Route("DAL/products")]
    public class ProductsController : Controller
    {
        private readonly string? _dalConnectionString;
        private readonly HttpClient _client;

        public ProductsController(IConfiguration conf)
        {
            _dalConnectionString = conf.GetValue<string>("DalConnectionString");
            _client = new HttpClient();
        }

        [HttpGet("")]
        public async Task<ActionResult<Product[]>> GetProducts()
        {
            var response = await _client.GetAsync($"{_dalConnectionString}/products");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<Product[]>() ?? Array.Empty<Product>();
            return result;
        }
    }
}
