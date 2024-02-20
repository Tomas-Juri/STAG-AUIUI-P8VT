using Application.Backend.Api.Models;
using Application.Backend.Database;
using Application.Backend.Database.Models;
using Application.Backend.Database.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Backend.Api;

[ApiController]
[Route("/api/weather-forecast")]
public class WeatherForecastController(DataContext dataContext, UsersRepository usersRepository) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var weatherForecasts = dataContext.WeatherForecasts.ToList();
        return Ok(weatherForecasts);
    }
    
    // HTTP-GET /api/weather-forecasts/guid
    [HttpGet("{id:guid}")]
    public IActionResult Get(Guid id)
    {
        var weatherForecasts = dataContext.WeatherForecasts.FirstOrDefault(forecast => forecast.Id == id);
        if (weatherForecasts == null)
            return NotFound();
        
        return Ok(weatherForecasts);
    }
    
    [HttpPost]
    public IActionResult Create(WeatherForecast weatherForecast)
    {
        dataContext.Add(weatherForecast);
        dataContext.SaveChanges();

        return Ok();
    }
    
    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, UpdateWeatherForecastRequest request)
    {
        var weatherForecasts = dataContext.WeatherForecasts.FirstOrDefault(forecast => forecast.Id == id);
        if (weatherForecasts == null)
            return NotFound();

        weatherForecasts.Summary = request.Summary;
        
        // dataContext.WeatherForecasts.Update(weatherForecasts);
        dataContext.SaveChanges();

        return Ok();
    }
    
    
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var weatherForecasts = dataContext.WeatherForecasts.FirstOrDefault(forecast => forecast.Id == id);
        if (weatherForecasts == null)
            return NotFound();

        dataContext.WeatherForecasts.Remove(weatherForecasts);
        dataContext.SaveChanges();

        return Ok();
    }
    
}
