using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RestaurantFinder.Domain;
using RestaurantFinder.Models;
using System.Threading.Tasks;

namespace RestaurantFinder.Tests
{
    [TestClass]
    public class RestaurantServiceTests
    {
        private IRestaurantService _restautantService;
        private AppSettings _appSettings;
        private IHttpClientService _httpClientService;
        [TestInitialize]
        public void Intialize()
        {
            _appSettings = new AppSettings() { RestaurantServiceUrl = "https://uk.api.just-eat.io/" };
            _httpClientService = Substitute.For<IHttpClientService>();
            _restautantService = new RestaurantService(_appSettings, _httpClientService);
        }

        [TestMethod]
        public async Task Should_Call_HttpClient_For_ValidData()
        {
            //arrange
            string testCode = "EC4M 7RF";
            string testURl = $"{_appSettings.RestaurantServiceUrl}{string.Format(AppConstants.ApplicationUrls.BYPOSTCODE, testCode)}";

            //act
            var result = await _restautantService.FindRestaurantbyCodeAsync(testCode);

            //assert
            await _httpClientService.Received().GetAsync<RestaurantResponse>(Arg.Is(testURl));
        }
    }
}
