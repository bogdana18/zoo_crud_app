using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

public class Pet
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("petid")]
    public int PetId { get; set; }

    [BsonElement("species")]
    public string Species { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("breed")]
    public string Breed { get; set; }

    [BsonElement("birthdate")]
    public DateTime Birthdate { get; set; }

    [BsonElement("healthstatus")]
    public string HealthStatus { get; set; }
}
