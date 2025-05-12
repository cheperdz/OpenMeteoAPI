using System.Text.Json.Serialization;

namespace Entities;

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
