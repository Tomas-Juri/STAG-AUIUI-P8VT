using Application.Backend.Database;
using Application.Backend.Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly DataContext _dataContext;

    public WeatherForecastController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpPost]
    [Authorize]
    public void Create(WeatherForecast weatherForecast)
    {
        _dataContext.Add(weatherForecast);
        _dataContext.SaveChanges();
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return _dataContext.WeatherForecasts.ToList();
    }

    [HttpGet("{id:guid}")]
    public IActionResult Get(Guid id)
    {
        var weatherForecast = _dataContext.WeatherForecasts.Find(id);

        if (weatherForecast == null)
            return NotFound();

        return Ok(weatherForecast);
    }

    [HttpPut("{id:guid}")]
    [Authorize]
    public IActionResult Update(Guid id, WeatherForecast request)
    {
        var weatherForecast = _dataContext.WeatherForecasts.Find(id);

        if (weatherForecast == null)
            return NotFound();

        weatherForecast.Summary = request.Summary;
        weatherForecast.Date = request.Date;
        weatherForecast.TemperatureC = request.TemperatureC;

        _dataContext.Update(weatherForecast);
        _dataContext.SaveChanges();

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    [Authorize]
    public IActionResult Delete(Guid id)
    {
        var weatherForecast = _dataContext.WeatherForecasts.Find(id);

        if (weatherForecast == null)
            return NotFound();

        _dataContext.Remove(weatherForecast);
        _dataContext.SaveChanges();

        return Ok();
    }
}