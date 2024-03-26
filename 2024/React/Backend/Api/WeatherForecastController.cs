using System.Security.Claims;
using Application.Backend.Api.Models;
using Application.Backend.Authorization;
using Application.Backend.Database;
using Application.Backend.Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;

namespace Application.Backend.Api;

[ApiController]
[Route("/api/weather-forecast")]
// [Authorize]
public class WeatherForecastController(DataContext dataContext, ILogger<WeatherForecastController> logger, IFeatureManager featureManager) : ControllerBase
{
    private Random Random => Random.Shared;
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var includeFahrenheit = await featureManager.IsEnabledAsync("WeatherForecastIncludesFahrenheits");
        var includeKelvin = await featureManager.IsEnabledAsync("WeatherForecastIncludesKelvins");
  
        var weatherForecasts = dataContext.WeatherForecasts
            .Select(forecast => new
            {
                forecast.Id,
                forecast.Summary,
                forecast.Date,
                Fahrenheit = includeFahrenheit ? Random.Next() : (int?)null,
                Kelvin = includeKelvin ? Random.Next() : (int?)null,
            })
            .ToList();
        
        return Ok(weatherForecasts);
    }
    
    [HttpGet("{id:guid}")]
    public IActionResult Get(Guid id)
    {
        logger.LogInformation("Getting weather forecasts");
        
        var weatherForecasts = dataContext.WeatherForecasts.FirstOrDefault(forecast => forecast.Id == id);
        if (weatherForecasts == null)
        {
            logger.LogInformation("Weather forecast {id} not found", id);
            
            return NotFound();
        }
        
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
