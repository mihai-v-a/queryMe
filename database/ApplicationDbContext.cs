using domain;
using Microsoft.EntityFrameworkCore;

namespace database;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("WeatherForecast");
    }

    public DbSet<WeatherForecast> Forecast;
}
