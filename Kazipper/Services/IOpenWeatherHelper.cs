using Kazipper.Models;

namespace Kazipper.Services;

public interface IOpenWeatherHelper
{
    public WeatherResponse GetWeather(string zip);
}