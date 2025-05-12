using EFC.Context;
using EFC.Repositories;
using EFC.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace EFC;

public static class DependencyContainer
{
    private const string MongoDbConnectionString = "mongodb://localhost:27017";
    private const string DatabaseName = "WeatherTemplateDb";

    public static IServiceCollection AddRepositories(this IServiceCollection services )
    {
        services.AddDbContext<WeatherDbContext>(options => options.UseMongoDB(new MongoClient(MongoDbConnectionString), DatabaseName));

        services.AddScoped<IWeatherRepository, WeatherRepository>();

        return services;
    }
}
