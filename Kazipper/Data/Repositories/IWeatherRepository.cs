using Kazipper.Data.Enteties;

namespace Kazipper.Data.Repositories;

public interface IWeatherRepository
{
    public WeatherRequest Add(WeatherRequest request);
    public List<WeatherRequest> ListWeatherRequests();
}