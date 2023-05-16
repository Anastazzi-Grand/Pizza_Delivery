using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V2.Domain.Entities

{
    public class ProductOptions
    {
        [Key]
        public int Id { get; set; }

        public string OptionKey { get; set; }

        public string OptionValue { get; set; }

        public decimal Markup { get; set; }

        public int ProductPropertyId { get; set; }
    }
}
