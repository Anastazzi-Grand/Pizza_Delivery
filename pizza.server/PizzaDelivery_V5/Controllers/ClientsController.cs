using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaDelivery_V5.Entities.Entities;
using PizzaDelivery_V5.Repositories.Interfaces;

namespace PizzaDelivery_V5.Controllers
{
    [ApiController]
    [Route("api/DAL/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly IClientRepository _clientRepository;

        public ClientsController(ILogger<ClientsController> logger, IClientRepository clientRepository)
        {
            _logger = logger;
            _clientRepository = clientRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> ClientList()
        {
            var client = await _clientRepository.Get();
            if (client == null) return NotFound();
            return Ok(client);
        }

        [HttpGet("12345")]
        public async Task<IActionResult> ClientGet(int id)
        {
            var client = await _clientRepository.GetById(id);
            return Ok(client);
        }

        [HttpGet("name")]
        public async Task<IActionResult> ClientGet(string name)
        {
            var client = await _clientRepository.GetByNameEntity(name);
            return Ok(client);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddClient(Client client)
        {
            var result = await _clientRepository.Add(client);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateClient(Client client)
        {
            var result = await _clientRepository.Update(client);
            return Ok(result);
        }

        [HttpDelete("delete/12345")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var result = await _clientRepository.Delete(id);
            return Ok(result);
        }

    }
}
