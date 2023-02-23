using OnlyShare.Shared;

namespace OnlyShare.Server.Database.Repositories
{
    public interface IWeatherForecastRepository
    {
        IEnumerable<WeatherForecast> GetWeatherForecasts();
    }
}
