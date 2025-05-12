using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
namespace Mappings;

public static class DependencyContainer
{
    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(WeatherProfile));

        return services;
    }
}
