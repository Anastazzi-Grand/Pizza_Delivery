using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V4.Entities.Entities

{
    public class Employee
    {
        [Column("EmployeeId")]
        public int Id { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Position { get; set; }
    }
}
