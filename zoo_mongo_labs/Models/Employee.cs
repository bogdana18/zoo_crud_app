using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Employee
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("employeeid")]
    public int EmployeeId { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("position")]
    public string Position { get; set; }

    [BsonElement("email")]
    public string Email { get; set; }

    [BsonElement("salary")]
    public double Salary { get; set; }
}

