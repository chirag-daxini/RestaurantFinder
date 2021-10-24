using RestaurantFinder.Models;
using System.Threading.Tasks;

namespace RestaurantFinder.Domain
{
    public interface IRestaurantService
    {
        Task<RestaurantResponse> FindRestaurantbyCodeAsync(string code);
    }
    public class RestaurantService : IRestaurantService
    {
        private readonly AppSettings _appSettings;
        private readonly IHttpClientService _httpClientService;
        public RestaurantService(AppSettings appSettings, IHttpClientService httpClientService)
        {
            _appSettings = appSettings;
            _httpClientService = httpClientService;
        }
        public async Task<RestaurantResponse> FindRestaurantbyCodeAsync(string code)
        {
            string serviceURL = string.Format($"{AppConstants.ApplicationUrls.BYPOSTCODE}", code);
            var result = await _httpClientService.GetAsync<RestaurantResponse>($"{_appSettings.RestaurantServiceUrl}{serviceURL}");
            return result;
        }
    }
}
