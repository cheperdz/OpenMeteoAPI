using Entities;

namespace Services.Interfaces;

public interface IOpenMeteoService
{
    Task<Weather> GetWeatherDataAsync(double latitude, double longitude);
    Task<(double Latitude, double Longitude)> GetCoordinatesFromCityAsync(string city);
}
