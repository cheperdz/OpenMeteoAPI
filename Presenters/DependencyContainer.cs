using Microsoft.Extensions.DependencyInjection;
using Ports.Output;

namespace Presenters;

public static class DependencyContainer
{
    public static IServiceCollection AddPresenters(this IServiceCollection services)
    {
        services.AddScoped<IGetWeatherByLocationOutputPort, GetWeatherByLocationResponse>();
        services.AddScoped<IGetWeatherByCityOutputPort, GetWeatherByCityResponse>();

        return services;
    }
}
