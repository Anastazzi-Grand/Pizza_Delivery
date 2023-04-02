using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pizza_server
{
    public class Pizza
    {
        [Column("Product_ID")]
        public byte? Id { get; set; }

        public string Name { get; set; }

        public decimal? Price { get; set; }

        public string? CookingTime { get; set; }

        public string PropertyName { get; set; }

        public decimal? PropertyMarkUp { get; set; }

        public string PropertyOption { get; set; }

        public byte[] Image { get; set; }
        
        public LinkedList<LineNumber> LineNumbers { get; set; } = new();
    }
}
