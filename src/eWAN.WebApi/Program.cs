using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using eWAN.Infrastructure.Database;
using Autofac.Extensions.DependencyInjection;

namespace eWAN.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            
            SeedData seedData = (SeedData) host.Services.GetService(typeof(SeedData));
            seedData.Seed();
            
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("http://localhost:5001").UseStartup<Startup>();
                });
    }
}
