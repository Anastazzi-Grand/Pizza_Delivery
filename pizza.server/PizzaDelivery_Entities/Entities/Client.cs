using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V5.Entities.Entities
{
    public class Client
    {
        [Column("ID")]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }

        public string PasswordHash { get; set; }

        public string RefreshToken { get; set; }

        public List<Order> Order { get; set; }
    }
    /*
    public abstract class ClientUseCase: Client
    {
        public void MakePurchase() { }

    }*/
}
