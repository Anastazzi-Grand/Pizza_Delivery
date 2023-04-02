namespace PizzaDelivery.Controllers
{
    public class LoginModel
    {
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }

        /*
        public LoginModel(string phone, string password)
        {
            PhoneNumber = phone;    
            PasswordHash = password;
        }*/

    }
}