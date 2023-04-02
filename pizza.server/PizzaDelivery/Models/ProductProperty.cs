using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.Models
{
    public class ProductProperty
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string PropertyName { get; set; }

        public List<ProductOption> Options { get; set; }
    }
}
