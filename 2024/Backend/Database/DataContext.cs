using Application.Backend.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Backend.Database;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public required DbSet<WeatherForecast> WeatherForecasts { get; set; }

    public required DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        SeedWeatherForecastData(modelBuilder);
    }

    private static void SeedWeatherForecastData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WeatherForecast>().HasData(new WeatherForecast
        {
            Id = Guid.NewGuid(),
            Date = DateTime.Now.AddYears(-2),
            Summary = "Weather 1",
            TemperatureC = 30,
        });
        modelBuilder.Entity<WeatherForecast>().HasData(new WeatherForecast
        {
            Id = Guid.NewGuid(),
            Date = DateTime.Now.AddYears(-1),
            Summary = "Weather 2",
            TemperatureC = 35,
        });
        modelBuilder.Entity<WeatherForecast>().HasData(new WeatherForecast
        {
            Id = Guid.NewGuid(),
            Date = DateTime.Now,
            Summary = "Weather 3",
            TemperatureC = 40,
        });
    }
}