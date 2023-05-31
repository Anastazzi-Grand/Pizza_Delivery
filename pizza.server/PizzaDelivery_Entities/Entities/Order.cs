using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V5.Entities.Entities

{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string OrderDate { get; set; }

        public int? TotalPrice { get; set; }

        public string DeliveryDate { get; set; }

        public int? ClientId { get; set; }

        public List<OrderItems> OrderItems { get; set; }
    }
}
