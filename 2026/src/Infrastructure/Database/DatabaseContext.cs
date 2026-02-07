using Application.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.Database;

public class DatabaseContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<UserDo> Users => Set<UserDo>();
}