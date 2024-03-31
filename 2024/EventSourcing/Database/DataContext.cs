using EventSourcing.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace EventSourcing.Database;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public required DbSet<EventDo> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<EventDo>()
            .ToTable("Events");
    }
}