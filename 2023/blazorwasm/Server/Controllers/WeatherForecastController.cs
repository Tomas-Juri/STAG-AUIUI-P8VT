using Microsoft.AspNetCore.Mvc;
using OnlyShare.Server.Database.Repositories;
using OnlyShare.Shared;

namespace OnlyShare.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastRepository _repository;

    public WeatherForecastController(IWeatherForecastRepository repository)
    {
        _repository = repository;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return _repository.GetWeatherForecasts();
    }
}
