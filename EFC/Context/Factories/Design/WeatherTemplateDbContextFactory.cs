using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MongoDB.Driver;

namespace EFC.Context.Factories.Design;

public class WeatherTemplateDbContextFactory : IDesignTimeDbContextFactory<WeatherTemplateDbContext>
{
    private const string MongoDbConnectionString = "mongodb://localhost:27017";
    private const string DatabaseName = "WeatherTemplateDb";

    public WeatherTemplateDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<WeatherTemplateDbContext>();

        var mongoClient = new MongoClient(MongoDbConnectionString);
        builder.UseMongoDB(mongoClient, DatabaseName);

        return new WeatherTemplateDbContext(builder.Options);
    }
}
