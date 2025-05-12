using Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Services;

public static class DependencyContainer
{
    public static IServiceCollection AddExternalServices(this IServiceCollection services)
    {
        services.AddHttpClient<IOpenMeteoService, OpenMeteoService>(client =>
        {
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.Timeout = TimeSpan.FromSeconds(30);
        });

        return services;
    }
}
