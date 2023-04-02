using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaDelivery.Models
{
    public class Sizes
    {
        [Column("id")]
        public int Id { get; set; }

        //public int Product_ID { get; set; }

        [Required]
        public string Size { get; set; } = null!;

        public decimal Price { get; set; }

    }
}
