using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.Controllers
{
    public class LoginModel
    {
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        /*
        public LoginModel(string phone, string password)
        {
            PhoneNumber = phone;    
            PasswordHash = password;
        }*/

    }
}