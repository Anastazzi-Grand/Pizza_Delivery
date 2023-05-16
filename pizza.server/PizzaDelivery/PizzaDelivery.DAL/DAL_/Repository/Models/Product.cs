using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Group { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Image { get; set; }

        public string CookingTime { get; set; }

        public List<ProductProperty> Properties { get; set; }
    }
}
