using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities;

public class Weather
{
    [BsonId]
    public ObjectId Id { get; set; }

    public double Longitude { get; set; }
    public double Latitude { get; set; }

    public int WindDirection { get; set; }
    public double Temperature { get; set; }
    public double WindSpeed { get; set; }

    public DateTime Sunrise { get; set; }

    [BsonElement("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class OpenMeteoResponse
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("current")]
    public CurrentWeather Current { get; set; }

    [JsonPropertyName("daily")]
    public DailyWeather Daily { get; set; }
}

public class CurrentWeather
{
    [JsonPropertyName("wind_direction_10m")]
    public int WindDirection { get; set; }

    [JsonPropertyName("temperature_2m")]
    public double Temperature { get; set; }

    [JsonPropertyName("wind_speed_10m")]
    public double WindSpeed { get; set; }
}

public class DailyWeather
{
    [JsonPropertyName("sunrise")]
    public List<string> Sunrise { get; set; }
}
