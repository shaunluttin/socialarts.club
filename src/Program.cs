using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenIddict.Core;
using OpenIddict.EntityFrameworkCore.Models;
using socialarts.club.Data;

namespace socialarts.club
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            // see https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-2.1&tabs=visual-studio#add-code-to-initialize-the-db-with-test-data
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    var manager = scope.ServiceProvider.GetRequiredService<OpenIddictApplicationManager<OpenIddictApplication>>();

                    DbInitializer.Initialize(context, manager);
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
