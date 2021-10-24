using Microsoft.Extensions.Hosting;
using RestaurantFinder.Domain;
using System;
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
            throw new NotImplementedException();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
