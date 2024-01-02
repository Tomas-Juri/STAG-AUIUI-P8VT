using Application.Backend.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Backend.Database;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public required DbSet<WeatherForecast> WeatherForecasts { get; set; }

    public required DbSet<User> Users { get; set; }
}