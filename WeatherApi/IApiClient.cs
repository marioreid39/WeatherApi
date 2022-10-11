namespace WeatherApi
{
    public interface IApiClient
    {
        public Task<WeatherApiResponse?> GetWeather(string cityName);
    }
}
