namespace Application.Backend.Database.Models;

public class WeatherForecast
{
    public required Guid Id { get; set; }

    public required DateTime Date { get; set; }

    public required int TemperatureC { get; set; }

    public required string Summary { get; set; }
}