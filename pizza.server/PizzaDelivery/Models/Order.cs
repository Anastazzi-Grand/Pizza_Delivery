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
        [Column("Order_number")]
        public int Id { get; set; }

        [Column("Client_ID")]
        public int ClientId { get; set; }

        public DateTime Order_date { get; set; }

        [Required]
        public string Status { get; set; } = null!;

        public DateTime Date_of_execution { get; set; }

        public decimal Payment { get; set; }

        [Column("Cook_Employee_ID")]
        public int CookId { get; set; }

        [Column("Operator_Employee_ID")]
        public int OpertorId { get; set; }

        [Column("Courier_ID")]
        public int CourierId { get; set; }

    }

}

