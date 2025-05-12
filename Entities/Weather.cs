using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities;

public class Weather
{
    [BsonId]
    public ObjectId Id { get; set; }

    public double Longitude { get; set; }
    public double Latitude { get; set; }

    public double WindDirection { get; set; }
    public double Temperature { get; set; }
    public double WindSpeed { get; set; }

    public DateTime Sunrise { get; set; }

    [BsonElement("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
