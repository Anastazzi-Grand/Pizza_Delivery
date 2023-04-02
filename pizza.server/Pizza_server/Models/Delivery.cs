using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_server
{
    public class Delivery
    {
        [Column("Delivery_ID")]
        public byte Id { get; set; }

        public byte Courier_Employee_ID { get; set; }

        public DateTime Date { get; set; }

        public LinkedList<Order> Orders { get; set; } = new();


    }
}
