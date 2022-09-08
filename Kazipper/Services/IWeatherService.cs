using Kazipper.Data.Enteties;
using Kazipper.Models;

namespace Kazipper.Services;

public interface IWeatherService
{
    public Weather GetWeatherByZip(string zip);
    public List<WeatherRequest> ListWeatherRequests();
}