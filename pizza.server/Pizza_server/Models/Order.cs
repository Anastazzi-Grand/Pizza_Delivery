using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza_server
{
    public class Order
    {
        [Column("Order_number")]
        public byte Id { get; set; }

        [Column("Client_ID")]
        public byte? ClientId { get; set; }

        public DateTime? Order_date { get; set; }

        public string? Status { get; set; }

        public DateTime? Date_of_execution { get; set; }

        public decimal? Payment { get; set; }

        [Column("Cook_Employee_ID")]
        public byte? CookId { get; set; }

        [Column("Operator_Employee_ID")]
        public byte? OpertorId { get; set; }

        [Column("Courier_ID")]
        public byte CourierId { get; set; }

        public LinkedList<LineNumber> LineNumbers { get; set; } = new();

        public Delivery? Delivery { get; set; }

        public Client? Client { get; set; }

    }

}

