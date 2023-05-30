using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V5.Entities.Entities
{
    public class OrderItems
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int OrderId { get; set; }
        public Order? Orders { get; set; }
        public Product? Products { get; set; }
    }
}
