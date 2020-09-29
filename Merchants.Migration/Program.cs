using Merchants.Web.DbContexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace Merchants.Migration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Applying migrations");
            var webHost = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<ConsoleStartup>()
                .Build();
            using (var context = (MerchantContext)webHost.Services.GetService(typeof(MerchantContext)))
            {
                context.Database.Migrate();
            }
            Console.WriteLine("Done");
        }
    }
}
