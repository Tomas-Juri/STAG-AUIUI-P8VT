using Application.Infastructure.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Infastructure.Database;

public class DatabaseContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<UserDo> Users => Set<UserDo>();
}