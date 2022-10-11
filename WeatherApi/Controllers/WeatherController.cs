using Microsoft.AspNetCore.Mvc;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {

        private readonly ILogger<WeatherController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        IApiClient _apiClient;

        public WeatherController(ILogger<WeatherController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;

            _apiClient = new ApiClient(httpClientFactory);

        }

        [HttpGet(Name = "GetWeather")]
        public async Task <WeatherApiResponse> Get()
        {
            var result = await _apiClient.GetWeather("London");

            return result;
        }

      
    }
}