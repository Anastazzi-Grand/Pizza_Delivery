using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.IO;
using Pizza_server;

namespace Pizza_server
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> context) : base(context)
        {
            Database.EnsureCreated();
        }
            public DbSet<Order>? Orders { get; set; }
            public DbSet<LineNumber>? LineNumbers { get; set; }
            public DbSet<Delivery>? Deliveries { get; set; }
            public DbSet<Employee>? Employees { get; set; }
            public DbSet<Pizza>? Pizzas { get; set; }
            public DbSet<Post>? Posts { get; set; }
            public DbSet<Client>? Clients { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                var builder = new ConfigurationBuilder();
            //Console.WriteLine("hhhhhhhhhhhhhh");
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appsettings.json");
                var config = builder.Build();
                string connectionString = config.GetConnectionString("DefaultConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
    }
}
