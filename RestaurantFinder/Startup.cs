using Microsoft.Extensions.Hosting;
using RestaurantFinder.Domain;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantFinder
{
    public class Startup : IHostedService
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IValidationService _validationService;
        public Startup(IRestaurantService restaurantService, IValidationService validationService)
        {
            _restaurantService = restaurantService;
            _validationService = validationService;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Welcome to RestaurantFinder app");
            Console.WriteLine("Please enter Uk postal code :");
            string code = Console.ReadLine();

            if (await _validationService.ValidatePostCode(code))
            {
                var restaurants = await _restaurantService.FindRestaurantbyCodeAsync(code);
                Console.WriteLine(string.Join(Environment.NewLine, restaurants.Restaurants.Where(x => x.IsOpenNow)));
            }
            else
                Console.WriteLine("You have entered invalid code, Please try again !!");

            Environment.Exit(0);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
