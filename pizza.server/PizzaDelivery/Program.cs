using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using PizzaDelivery;
using Microsoft.Extensions.Configuration;
using PizzaDelivery.Services;

namespace PizzaDelivery
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
            using (ApplicationContext db = new ApplicationContext())
            {
                var orders = db.Order.ToArray();
                Console.WriteLine("Список объектов");
                foreach (Order u in orders)
                {
                    Console.WriteLine(u.Id + " - " + u.Status);
                }
            }*/
            CreateHostBuilder(args).Build().Run();
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                 
                    webBuilder.UseStartup<Startup>();
                });


    }
}