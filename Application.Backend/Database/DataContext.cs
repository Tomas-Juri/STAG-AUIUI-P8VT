using Application.Backend.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Backend.Database;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    
    }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; } = default!;
}