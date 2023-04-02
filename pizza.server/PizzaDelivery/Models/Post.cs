using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery
{
    public class Post
    {
        [Column("Post_ID")]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

    }
}
