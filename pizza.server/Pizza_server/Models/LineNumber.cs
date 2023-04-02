using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_server
{
    public class LineNumber
    {
        [Column("Order_line_number")]
        public byte Id { get; set; }

        public byte? Count { get; set; }

        [Column("Order_number")]
        public byte? OrderId { get; set; }
        public Order? Order { get; set; }

        [Column("Product_ID")]
        public byte? PizzaId { get; set; }

        public Pizza? Pizza { get; set; }


    }
}
