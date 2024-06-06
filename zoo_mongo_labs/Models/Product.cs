using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("productid")]
    public int ProductId { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("price")]
    public double Price { get; set; }

    [BsonElement("category")]
    public string Category { get; set; }

    [BsonElement("stockquantity")]
    public int StockQuantity { get; set; }
}
