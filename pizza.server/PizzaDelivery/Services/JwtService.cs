using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PizzaDelivery.Services
{
    public class JwtService
    {
        private readonly string _secret;
        private readonly string _issuer;
        private readonly ApplicationContext _context;
        //private Client client;
        public JwtService(string secret, string issuer)
        {
            _secret = secret;
            _issuer = issuer;
            _context = new ApplicationContext();
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims, TimeSpan expiresIn)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _issuer,
                null,
                claims,
                expires: DateTime.UtcNow.Add(expiresIn),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public void PutRefreshToken(int id, string token)
        {
            //_context.Entry(_context.Client.FindAsync(id)).State = EntityState.Modified;
            var client = _context.Client.Find(id);
            if (client != null)
            {
                client.RefreshToken = token;
                _context.SaveChanges();
            }

        }
    }
}
