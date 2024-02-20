using Application.Backend.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Backend.Database;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public required DbSet<WeatherForecast> WeatherForecasts { get; set; }

    public required DbSet<User> Users { get; set; }
    
    public required DbSet<Car> Cars { get; set; }
    
    public required DbSet<Delivery> Deliveries { get; set; }
}