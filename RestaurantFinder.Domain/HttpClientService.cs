using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestaurantFinder.Domain
{
    public interface IHttpClientService
    {
        Task<TResponse> GetAsync<TResponse>(string url);
    }
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;
        public HttpClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<TResponse> GetAsync<TResponse>(string url)
        {
            return await SendAsync<TResponse>(HttpMethod.Get, url);
        }
        private async Task<TResponse> SendAsync<TResponse>(HttpMethod httpMethod, string url)
        {
            try
            {
                var request = new HttpRequestMessage(httpMethod, url);
                var response = await _httpClient.SendAsync(request);

                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<TResponse>(content);
                }
                throw new Exception();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
