using Kazipper.Data.Enteties;
using Kazipper.Data.Repositories;
using Kazipper.Models;

namespace Kazipper.Services.Implementation;

public class WeatherService : IWeatherService
{
    private readonly IWeatherRepository _weatherRepository;
    private readonly IOpenWeatherHelper _openWeatherHelper;

    public WeatherService(IWeatherRepository weatherRepository, IOpenWeatherHelper openWeatherHelper)
    {
        _weatherRepository = weatherRepository;
        _openWeatherHelper = openWeatherHelper;
    }

    public Weather GetWeatherByZip(string zip)
    {
        var response = _openWeatherHelper.GetWeather(zip);

        var weather = new Weather();
        weather.Temperature = response.Main.Temp;
        weather.Name = response.Name;

        try
        {
            var weatherRequest = new WeatherRequest
            {
                City = weather.Name,
                Temperature = weather.Temperature,
                Zip = zip,
                Date = DateTime.Now
            };

            _weatherRepository.Add(weatherRequest);
        }
        catch
        {
            // TODO log error
        }

        return weather;
    }

    public List<WeatherRequest> ListWeatherRequests()
    {
        return _weatherRepository.ListWeatherRequests();
    }
}