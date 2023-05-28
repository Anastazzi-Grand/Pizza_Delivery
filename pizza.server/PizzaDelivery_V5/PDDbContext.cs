using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PizzaDelivery_V5.Entities.Entities;

namespace PizzaDelivery_V5
{/*
    public class ClientDAL : Client { }
    public class ClientUI : ClientUseCase { }*/

    public class PDDbContext : DbContext
    {
        public PDDbContext(DbContextOptions<PDDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductProperties> ProductProperties { get; set; }
    }
}
