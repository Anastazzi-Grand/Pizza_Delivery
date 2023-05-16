using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V2.Domain.Entities
{ 
    public class OrderItems
    {
        [Column("OrderLineNumber")]
        public int Id { get; set; }

        public int OrderNumber { get; set; }

        public int Count { get; set; }

        public int ProductId { get; set; }

        public int? ProductPropertyId { get; set; }

        public int? ProductOptionId { get; set; }
    }
}
