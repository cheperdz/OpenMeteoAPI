using System.Text.Json.Serialization;

namespace Entities;

public class CurrentWeather
{
    [JsonPropertyName("wind_direction_10m")]
    public double WindDirection { get; set; }

    [JsonPropertyName("temperature_2m")]
    public double Temperature { get; set; }

    [JsonPropertyName("wind_speed_10m")]
    public double WindSpeed { get; set; }
}