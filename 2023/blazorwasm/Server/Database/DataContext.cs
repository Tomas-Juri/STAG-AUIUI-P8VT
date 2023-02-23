using Microsoft.EntityFrameworkCore;
using OnlyShare.Server.Database.Models;

namespace OnlyShare.Server.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
}
