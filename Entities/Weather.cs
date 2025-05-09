using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities;

public class Weather
{
    [BsonId]
    public ObjectId Id { get; set; }

    public string Name { get; set; } = "";




    [BsonElement("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
