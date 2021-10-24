using RestaurantFinder.Models;
using System;
using System.Threading.Tasks;

namespace RestaurantFinder.Domain
{
    public interface IRestaurantService
    {
        Task FindRestaurantbyCodeAsync(string code);
    }
    public class RestaurantService : IRestaurantService
    {
        private readonly AppSettings _appSettings;
        public RestaurantService(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }
        public async Task FindRestaurantbyCodeAsync(string code)
        {
            throw new NotImplementedException();
        }
    }
}
