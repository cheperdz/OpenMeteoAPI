using System.Text.Json.Serialization;

namespace Entities;

public class DailyWeather
{
    [JsonPropertyName("sunrise")]
    public List<string> Sunrise { get; set; }
}