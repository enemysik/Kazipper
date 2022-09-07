namespace Kazipper.Data;

public class WeatherRequest
{
    public long Id { get; set; }
    public string Zip { get; set; }
    public string City { get; set; }
    public double Temperature { get; set; }
    public DateTime Date { get; set; }
}