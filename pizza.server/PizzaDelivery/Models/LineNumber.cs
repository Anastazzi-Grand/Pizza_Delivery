using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery
{
    public class LineNumber
    {
        [Column("Order_line_number")]
        public int Id { get; set; }

        public int Count { get; set; }

        [Column("Order_number")]
        public int OrderId { get; set; }

        //[Column("Product_ID")]
        public int Product_ID { get; set; }

    }
}
