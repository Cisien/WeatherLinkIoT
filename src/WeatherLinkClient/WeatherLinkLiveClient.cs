using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherLinkClient
{
    public class WeatherLinkLiveClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherLinkLiveClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<CurrentConditionsResponse?> GetCurrentConditionsAsync(string weatherLinkBaseUrl)
        {
            try
            {
                using var httpClient = _httpClientFactory.CreateClient("WeatherLinkLive");
                httpClient.BaseAddress = new Uri(weatherLinkBaseUrl);

                var result = await httpClient.GetAsync("v1/current_conditions");

                var response = await result.Content.ReadAsStringAsync();

                var responseData = JsonSerializer.Deserialize<CurrentConditionsResponse>(response);

                return responseData;
            }
            catch(HttpRequestException)
            {
                return null;
            }
        }
    }
}
