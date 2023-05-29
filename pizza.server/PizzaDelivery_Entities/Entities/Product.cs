using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V5.Entities.Entities

{
    public class Product
    {

        [Key]
        public int Id { get; set; }

        public string Group { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string CookingTime { get; set; }

        public byte[] Image { get; set; }
        
    }
}
