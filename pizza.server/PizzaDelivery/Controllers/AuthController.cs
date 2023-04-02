using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.Models;
using PizzaDelivery.Services;
using System.Security.Authentication;
using System.Security.Claims;

namespace PizzaDelivery.Controllers
{
    [ApiController]
    [Route("/auth")]
    public class AuthController : Controller
    {

        private readonly ClientService _clientService;

        private readonly JwtService _jwtService;

        //private Client client;

        public AuthController(ClientService clientService, JwtService jwtService)
        {
            _clientService = clientService;
            _jwtService = jwtService;
        }

        [HttpPost]
        public async Task<AuthResult> AuthenticateAsync(LoginModel loginModel)
        {
            // Проверяем логин и пароль пользователя и получаем информацию о пользователе
            var client = await _clientService.GetClientAsync(loginModel);

            if (client == null)
            {
                throw new AuthenticationException("Invalid email or password.");
            }

            // Генерируем access и refresh токены
            string accessToken = _jwtService.GenerateAccessToken(new List<Claim>
            {
                new Claim(ClaimTypes.Name,client.Value!.Id.ToString()),
                new Claim(ClaimTypes.Role,client.Value.Role)
            }, TimeSpan.FromMinutes(15));
            string refreshToken = _jwtService.GenerateRefreshToken();

            // Сохраняем refresh токен в базе данных1 и связываем его с пользователем
            _jwtService.PutRefreshToken(client.Value!.Id, refreshToken);

            // Возвращаем access и refresh токены
            return new AuthResult(accessToken, refreshToken);
        }
    }
}
