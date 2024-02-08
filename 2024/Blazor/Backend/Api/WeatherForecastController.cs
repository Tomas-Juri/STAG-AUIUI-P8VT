using Application.Backend.Database;
using Microsoft.AspNetCore.Mvc;

namespace Application.Backend.Api;

[ApiController]
[Route("/api/weather-forecast")]
public class WeatherForecastController(DataContext dataContext) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var weatherForecasts = dataContext.WeatherForecasts.ToList();
        return Ok(weatherForecasts);
    }
}
