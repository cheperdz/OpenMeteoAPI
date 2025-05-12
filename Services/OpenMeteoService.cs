using System.Text.Json;
using AutoMapper;
using Services.Interfaces;
using Entities;

namespace Services;

public class OpenMeteoService(HttpClient httpClient, IMapper mapper) : IOpenMeteoService
{
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public async Task<Weather> GetWeatherDataAsync(double latitude, double longitude)
    {
        var url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&daily=sunrise&current=wind_direction_10m,temperature_2m,wind_speed_10m&timezone=auto&forecast_days=1";

        var response = await httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var openMeteoResponse = JsonSerializer.Deserialize<OpenMeteoResponse>(json, _jsonOptions)!;
        var weather = mapper.Map<Weather>(openMeteoResponse);

        return weather!;
    }

    public async Task<(double Latitude, double Longitude)> GetCoordinatesFromCityAsync(string city, string countryCode)
    {
        var url = $"https://nominatim.openstreetmap.org/search?city={Uri.EscapeDataString(city)}&country={Uri.EscapeDataString(countryCode)}&format=json&limit=1";

        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "WeatherApp/1.0");

        var response = await httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var results = JsonSerializer.Deserialize<List<dynamic>>(json, _jsonOptions);

        if (results?.Count > 0)
            return (double.Parse(results[0].Lat), double.Parse(results[0].Lon));

        throw new Exception($"City {city}, {countryCode} not found");
    }
}
