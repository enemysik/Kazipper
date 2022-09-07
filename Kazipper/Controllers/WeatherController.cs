using Kazipper.Data;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Kazipper.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    private readonly ApplicationContext _context;

    public WeatherController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet("zip/{zip}")]
    public IActionResult GetWeatherByZip(string zip)
    {
        var url = "https://api.openweathermap.org/data/2.5/weather";
        var appid = "98995f3039bae34354af0be4e6ceb5c8";
        var client = new RestClient(url);
        var request = new RestRequest()
            .AddQueryParameter("zip", zip)
            .AddQueryParameter("units", "metric")
            .AddQueryParameter("appid", appid);

        WeatherResponse response;

        try
        {
            response = client.Get<WeatherResponse>(request);
        }
        catch
        {
            return Problem();
        }

        if (response == null)
        {
            return Problem();
        }

        var weather = new Weather();
        weather.Temperature = response.Main.Temp;
        weather.Name = response.Name;

        try
        {
            _context.WeatherRequests.Add(new WeatherRequest
            {
                // Id =
                
                City = weather.Name,
                Temperature = weather.Temperature,
                Zip = zip,
                Date = DateTime.Now
            });

            _context.SaveChanges();
        }
        catch {}

        return Ok(weather);
    }

    [HttpGet("history")]
    public IActionResult GetRequestHistory()
    {
        var requests = _context.WeatherRequests.ToList();

        return Ok(requests);
    }
}

public class WeatherResponse
{
    public MainInfo Main { get; set; }
    public string Name { get; set; }

    public class MainInfo
    {
        public double Temp { get; set; }
    }
}

public class Weather
{
    public double Temperature { get; set; }
    public string Name { get; set; }
}