using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V5.Entities.Entities

{
    public class ProductProperties
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string PropertyName { get; set; }

        public decimal? Markup { get; set; }
    }
}
