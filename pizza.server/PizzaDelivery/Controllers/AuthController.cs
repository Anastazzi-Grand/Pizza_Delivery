using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PizzaDelivery.Models;
using PizzaDelivery.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PizzaDelivery.Controllers
{
    //[ApiController]
    //[Route("/auth")]
    public class AuthController : Controller
    {
        private readonly IOptions<AuthOptions> authOptions;

        private readonly ClientService _clientService;

        public AuthController(IOptions<AuthOptions> authOptions,
                                ClientService clientService)
        {
            this.authOptions = authOptions;
            _clientService = clientService;
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult Login(LoginModel loginModel)
        {
            var client = _clientService.GetClientAsync(loginModel.PhoneNumber, loginModel.PasswordHash);

            if (client != null)
            {
                //throw new AuthenticationException("Invalid email or password.");
                var token = GenerateJWT(client);

                return Ok(new
                {
                    access_token = token
                });
            }

           // return AuthenticationException("Invalid email or password."); ;
           return Unauthorized();
        }

        public string GenerateJWT(Client client)
        {
            var authParams = authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.FamilyName, client.FullName),
                new Claim(JwtRegisteredClaimNames.Sub, client.Id.ToString())
            };

            foreach (var role in client.Role)
            {
                claims.Add(new Claim("role", role.ToString()));
            }

            var token = new JwtSecurityToken(
                authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }


}
