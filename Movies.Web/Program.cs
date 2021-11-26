using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Movies.Web.Data;

namespace Movies.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // in dev env we auto migrate and test seed database
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var env = services.GetRequiredService<IWebHostEnvironment>();
                if (env.IsDevelopment())
                {
                    var context = services.GetRequiredService<MovieDbContext>();
                    context.Database.Migrate();
                    try
                    {
                        MovieDbInitialiser.SeedTestData(context).Wait();
                    }
                    catch (Exception e)
                    {
                        var logger = services.GetRequiredService<ILogger<Program>>();
                        logger.LogDebug("Seeding test data failed.");
                    }
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
