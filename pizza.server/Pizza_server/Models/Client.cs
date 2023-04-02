﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_server
{
    public class Client
    {
        [Column("ID")]
        public byte Id { get; set; }

        public string? Full_Name { get; set; }

        public string? Address { get; set; }

        public string? Telephone { get; set; }

        public LinkedList<Order> Orders { get; set; } = new();

    }
}
