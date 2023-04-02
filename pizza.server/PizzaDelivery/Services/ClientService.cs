using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.Controllers;

namespace PizzaDelivery.Services
{
    public class ClientService
    {
        private readonly ApplicationContext _context;

        public ClientService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Client>> GetClientAsync(LoginModel loginModel)
        {
            var client = _context.Client.FirstOrDefault(c => c.PhoneNumber == loginModel.PhoneNumber);
            if (client != null && client.PasswordHash == loginModel.PasswordHash)
            {
                return client;
            }
            return null;

        }
    }
}
