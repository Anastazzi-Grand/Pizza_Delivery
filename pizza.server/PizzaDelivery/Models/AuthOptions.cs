using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PizzaDelivery.Models
{
    public class AuthOptions
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int TokenLifeTime { get; set; }

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));   
        }

    }
}
