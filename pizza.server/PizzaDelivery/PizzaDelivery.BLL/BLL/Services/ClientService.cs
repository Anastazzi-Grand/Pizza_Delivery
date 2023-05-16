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

        public Client GetClientAsync(string phoneNumber, string passwordHash)
        {
           return _context.Client.SingleOrDefault(c => c.PhoneNumber == phoneNumber && c.PasswordHash == passwordHash);

        }
    }
}
