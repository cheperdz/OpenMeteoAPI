﻿using EFC.Configuration;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace EFC.Context;

public class WeatherTemplateDbContext(DbContextOptions<WeatherTemplateDbContext> options) : DbContext(options)
{
    public DbSet<Weather> Weathers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new WeatherTypeConfiguration());
    }
}
