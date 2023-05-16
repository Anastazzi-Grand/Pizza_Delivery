using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V2.Domain.Entities

{
    public class ProductProperty
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string PropertyName { get; set; }

        public List<ProductOptions> Options { get; set; }
    }
}
