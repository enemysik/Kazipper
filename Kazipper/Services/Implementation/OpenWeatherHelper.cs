using Kazipper.Configuration;
using Kazipper.Models;
using RestSharp;

namespace Kazipper.Services.Implementation;

public class OpenWeatherHelper : IOpenWeatherHelper
{
    private readonly Settings _settings;

    public OpenWeatherHelper(Settings settings)
    {
        _settings = settings;
    }

    public WeatherResponse GetWeather(string zip)
    {
        var client = new RestClient(_settings.WeatherSettings.Url);
        var request = new RestRequest()
            .AddQueryParameter("zip", zip)
            .AddQueryParameter("units", "metric")
            .AddQueryParameter("appid", _settings.WeatherSettings.AppId);

        WeatherResponse response;

        try
        {
            response = client.Get<WeatherResponse>(request);
        }
        catch
        {
            throw new ApplicationException("Remote weather request failed");
        }

        if (response?.Name == null)
        {
            throw new ApplicationException("Remote weather request failed with empty body");
        }

        return response;
    }
}