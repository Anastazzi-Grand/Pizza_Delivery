using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V5.Entities.Entities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string? Password { get; set; }
    }
    /*
    public abstract class ClientUseCase: Client
    {
        public void MakePurchase() { }

    }*/
}
