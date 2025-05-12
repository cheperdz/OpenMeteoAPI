using EFC.Context;
using EFC.Repositories;
using EFC.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace EFC;

public static class DependencyContainer
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        // Obtener la cadena de conexión y el nombre de la base de datos desde appsettings
        var connectionString = configuration.GetConnectionString("MongoDB");
        var databaseName = configuration.GetValue<string>("MongoDbConfiguration:DatabaseName");

        services.AddDbContext<WeatherDbContext>(options =>
            options.UseMongoDB(new MongoClient(connectionString), databaseName));

        services.AddScoped<IWeatherRepository, WeatherRepository>();

        return services;
    }
}
