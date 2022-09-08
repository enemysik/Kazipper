using Kazipper.Data.Enteties;
using Microsoft.EntityFrameworkCore;

namespace Kazipper.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<WeatherRequest> WeatherRequests { get; set; }
}