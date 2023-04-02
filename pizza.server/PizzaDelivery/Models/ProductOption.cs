using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.Models
{
    public class ProductOption
    {
        [Key]
        public int Id { get; set; }

        public string OptionKey { get; set; }

        public string OptionValue { get; set; }

        public decimal Markup { get; set; }

        public int ProductPropertyId { get; set; }
    }
}
