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

        try
        {
            var response = await httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode(); // This will throw HttpRequestException if status code is not successful

            var json = await response.Content.ReadAsStringAsync();
            var openMeteoResponse = JsonSerializer.Deserialize<OpenMeteoResponse>(json, _jsonOptions) ?? throw new InvalidOperationException("Failed to deserialize OpenMeteo response");

            var weather = mapper.Map<Weather>(openMeteoResponse) ?? throw new InvalidOperationException("Failed to map to Weather object");

            return weather;
        }

        catch (HttpRequestException ex) // Network errors, connection issues, or non-success status codes
        {
            throw new InvalidOperationException("Weather API request failed", ex);
        }
        catch (TaskCanceledException ex) // Request Timeout
        {
            throw new InvalidOperationException("Weather API request timed out", ex);
        }
        catch (JsonException ex) // JSON parsing errors
        {
            throw new InvalidOperationException("Failed to parse weather API response", ex);
        }
    }

    public async Task<(double Latitude, double Longitude)> GetCoordinatesFromCityAsync(string city) => throw new NotImplementedException();
}
