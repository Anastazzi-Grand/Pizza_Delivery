using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using PizzaDelivery.Models;

namespace PizzaDelivery
{
    public class Pizza
    {
        [Column("Product_ID")]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string CookingTime { get; set; } = null!;

        public byte[]? Picture { get; set; }

        public virtual ICollection<Sizes>? Sizes { get; set; }

    }
}
