using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V4.Domain.Entities
{
    public class Delivery
    {
        [Column("DeliveryId")]
        public int Id { get; set; }

        public int CourierEmployeeId { get; set; }

        public DateTime Date { get; set; }

    }
}
