using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PizzaDelivery_V4.DAL;
using PizzaDelivery_V4.Domain.Entities;

namespace PizzaDelivery_V4;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();

    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}