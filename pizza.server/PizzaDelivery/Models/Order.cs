using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaDelivery
{
    public class Order
    {
        [Column("OrderNumber")]
        public int Id { get; set; }

        public int ClientId { get; set; }

        public DateTime OrderDate { get; set; }

        public string Status { get; set; }

        public DateTime DeliveryDate { get; set; }

        public decimal Payment { get; set; }

        public int CookEmployeeId { get; set; }

        public int OperatorEmployeeId { get; set; }

        public int CourierId { get; set; }

        public decimal? TotalPrice { get; set; }

    }

}

