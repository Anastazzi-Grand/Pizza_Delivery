using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_server
{
    public class Post
    {
        [Column("Post_ID")]
        public byte Id { get; set; }

        public string? Title { get; set; }

        public LinkedList<Employee> Employees { get; set; } = new();

    }
}
