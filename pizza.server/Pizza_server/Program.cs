using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Pizza_server;

namespace Pizza_server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("мювюкн пюанрш");
            //Console.WriteLine(args);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //Console.WriteLine("яепедхмю пюанрш");
                    webBuilder.UseStartup<StartUp>();
                });
    }
}