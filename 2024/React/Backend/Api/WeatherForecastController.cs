using System.Security.Claims;
using Application.Backend.Api.Models;
using Application.Backend.Authorization;
using Application.Backend.Database;
using Application.Backend.Database.Models;
using Application.Backend.Database.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Backend.Api;

[ApiController]
[Route("/api/weather-forecast")]
[Authorize]
public class WeatherForecastController(DataContext dataContext) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var emailClaim = User.FindFirst(ClaimTypes.Email);
        
        var weatherForecasts = dataContext.WeatherForecasts.ToList();
        return Ok(weatherForecasts);
    }
    
    [HttpGet("{id:guid}")]
    public IActionResult Get(Guid id)
    {
        var weatherForecasts = dataContext.WeatherForecasts.FirstOrDefault(forecast => forecast.Id == id);
        if (weatherForecasts == null)
            return NotFound();
        
        return Ok(weatherForecasts);
    }
    
    [HttpPost]
    [Authorize(Policy = Policy.CanEditForecasts)]
    public IActionResult Create(WeatherForecast weatherForecast)
    {
        dataContext.Add(weatherForecast);
        dataContext.SaveChanges();

        return Ok();
    }
    
    [HttpPut("{id:guid}")]
    [Authorize(Policy = Policy.CanEditForecasts)]
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
    [Authorize(Policy = Policy.CanDeleteForecasts)]
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
