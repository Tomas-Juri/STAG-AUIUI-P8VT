using Application.Backend.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Backend.Api;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(DataContext dataContext) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var weatherForecasts = dataContext.WeatherForecasts.ToList();
        return Ok(weatherForecasts);
    }
    
    [HttpGet("/authorized")]
    [Authorize]
    public IActionResult GetAuthorized()
    {
        var weatherForecasts = dataContext.WeatherForecasts.ToList();
        return Ok(weatherForecasts);
    }
}
