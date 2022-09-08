using Kazipper.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kazipper.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _service;

    public WeatherController(IWeatherService service)
    {
        _service = service;
    }

    [HttpGet("zip/{zip}")]
    public IActionResult GetWeatherByZip(string zip)
    {
        return Ok(_service.GetWeatherByZip(zip));
    }

    [HttpGet("history")]
    public IActionResult GetRequestHistory()
    {
        return Ok(_service.ListWeatherRequests());
    }
}