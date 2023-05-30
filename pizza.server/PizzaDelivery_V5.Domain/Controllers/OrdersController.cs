using Microsoft.AspNetCore.Mvc;
using PizzaDelivery_V5.Entities.Entities;
using System.Text.Json;

namespace PizzaDelivery_V5.BLL.Controllers
{
    [ApiController]
    [Route("api")]
    public class OrdersController : Controller
    {
        private readonly string? _dalConnectionString;
        private readonly HttpClient _client;

        public OrdersController(IConfiguration conf)
        {
            _dalConnectionString = conf.GetValue<string>("DalConnectionString");
            _client = new HttpClient();
        }

        [HttpGet]
        public async Task<ActionResult<Order[]>> GetOrders()
        {
            var response = await _client.GetAsync($"{_dalConnectionString}/api/DAL/orders");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Order[]>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? Array.Empty<Order>();
        }

        [HttpPost("order")]
        public async Task<ActionResult<Order>> PostOrder(Order newOrder)
        {
            JsonContent content = JsonContent.Create(newOrder);
            using var result = await _client.PostAsync($"{_dalConnectionString}/api/DAL/orders/add", content);
            var dalOrder = await result.Content.ReadFromJsonAsync<Order>();
            //Console.WriteLine($"{dalProduct?.Name}");

            if (dalOrder == null) return BadRequest();
            else return dalOrder;
        }
    }
}
