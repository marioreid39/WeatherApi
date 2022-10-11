using Newtonsoft.Json;
using System.Net.Http.Json;

namespace WeatherApi
{
    public class ApiClient : IApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string apiKey = "da60d21da98419e708a2cbb21141e684";
        public ApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<WeatherApiResponse?> GetWeather(string cityName)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient("weather");
            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}";
            var response = await httpClient.GetAsync(apiUrl).ConfigureAwait(false);



            if (response.IsSuccessStatusCode)
            {
                // Good response, return result
                string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                response.EnsureSuccessStatusCode(); // Throws an error under any other circumstance

                var weatherResponse = JsonConvert.DeserializeObject<WeatherApiResponse>(json);
                return weatherResponse;

            }

            return null;
        }
    }
}
