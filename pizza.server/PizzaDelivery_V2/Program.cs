using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PizzaDelivery_V2.DAL;
using PizzaDelivery_V2.Domain.Entities;

namespace DAL;

public class Program
{
    public static void Main(string[] args)
    {/*
        using (ApplicationContext db = new ApplicationContext())
        {
            
            var orders = db.Client.ToArray();
            foreach (Client u in orders)
            {
                Console.WriteLine(u.Id + " - " + u.Role);
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
