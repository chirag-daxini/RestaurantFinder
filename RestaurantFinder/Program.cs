using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestaurantFinder.Domain;
using RestaurantFinder.Models;
using System.Threading.Tasks;

namespace RestaurantFinder
{
    class Program
    {
        async static Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                                    .AddEnvironmentVariables()
                                    .AddCommandLine(args)
                                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                    .Build();

            AppSettings settings = new AppSettings();
            configuration.GetSection("ServiceDiscovery").Bind(settings);

            return Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Startup>();
                    services.AddScoped<IRestaurantService, RestaurantService>();
                    services.AddScoped<IValidationService, ValidationService>();
                    services.AddSingleton(settings);

                }).ConfigureAppConfiguration(builder =>
                {
                    builder.Sources.Clear();
                    builder.AddConfiguration(configuration);
                });
        }
    }
}
