using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

public class Sale
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("saleid")]
    public int SaleId { get; set; }

    [BsonElement("customer")]
    public Customer Customer { get; set; }

    [BsonElement("employee")]
    public Employee Employee { get; set; }

    [BsonElement("pet")]
    public Pet Pet { get; set; }

    [BsonElement("product")]
    public Product Product { get; set; }

    [BsonElement("saledate")]
    public DateTime SaleDate { get; set; }

    [BsonElement("totalamount")]
    public double TotalAmount { get; set; }

    [BsonElement("paymentmethod")]
    public string PaymentMethod { get; set; }
}
