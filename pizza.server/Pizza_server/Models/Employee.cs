using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_server
{
    public class Employee
    {
        [Column("Employee_ID ")]
        public byte Id { get; set; }

        public string? Surname { get; set; }

        [Column("Position_ID")]
        public byte? PostId { get; set; }

        public Post? Post { get; set; }
        public LinkedList<Delivery> Deliveries { get; set; } = new();

        public LinkedList<Order> Orders { get; set; } = new();


    }
}
