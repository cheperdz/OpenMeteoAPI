using Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace EFC.Context;

public class WeatherDbContext(DbContextOptions<WeatherDbContext> options) : DbContext(options)
{
    public DbSet<Weather> Weathers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Weather>().ToCollection("weathers");
    }
}
