using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PizzaDelivery_V4.Entities.Entities;

namespace PizzaDelivery_V4
{/*
    public class ClientDAL : Client { }
    public class ClientUI : ClientUseCase { }*/

    public class PDDbContext : DbContext
    {
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductProperties> ProductProperties { get; set; }
        public DbSet<ProductOptions> ProductOptions { get; set; }

        public PDDbContext(DbContextOptions<PDDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("MvcPizzaConnectionString");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
