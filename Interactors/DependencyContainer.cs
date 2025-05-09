using Microsoft.Extensions.DependencyInjection;
using Ports.Input;

namespace Interactors;

public static class DependencyContainer
{
    public static IServiceCollection AddUseCaseInteractors(this IServiceCollection services)
    {
        services.AddScoped<IGetWeatherByLocationInputPort, GetWeatherByLocationInteractor>();
        services.AddScoped<IGetWeatherByCityInputPort, GetWeatherByCityInteractor>();

        return services;
    }
}
