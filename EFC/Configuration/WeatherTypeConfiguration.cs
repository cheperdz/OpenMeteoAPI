using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace EFC.Configuration;

public class WeatherTypeConfiguration : IEntityTypeConfiguration<Weather>
{
    public void Configure(EntityTypeBuilder<Weather> builder)
    {
        builder.ToCollection("weathers");

        builder
            .Property(weather => weather.Name)
            .IsRequired();

        builder
            .HasIndex(w => w.Name);
    }
}
