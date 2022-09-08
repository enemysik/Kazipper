using Kazipper.Data.Enteties;

namespace Kazipper.Data.Repositories.Implementation;

public class WeatherRepository : IWeatherRepository
{
    private readonly ApplicationContext _context;

    public WeatherRepository(ApplicationContext context)
    {
        _context = context;
    }

    public WeatherRequest Add(WeatherRequest request)
    {
        _context.WeatherRequests.Add(request);

        _context.SaveChanges();

        return request;
    }

    public List<WeatherRequest> ListWeatherRequests()
    {
        return _context.WeatherRequests.ToList();
    }
}