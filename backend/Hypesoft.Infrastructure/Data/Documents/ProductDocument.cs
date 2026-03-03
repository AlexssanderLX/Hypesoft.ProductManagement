using MongoDB.Bson.Serialization.Attributes;

namespace Hypesoft.Infrastructure.Data.Documents;

public class ProductDocument
{
    [BsonId]
    public string Id { get; set; } = string.Empty;

    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    [BsonElement("description")]
    public string Description { get; set; } = string.Empty;

    [BsonElement("price")]
    public decimal Price { get; set; }

    [BsonElement("categoryId")]
    public string CategoryId { get; set; } = string.Empty;

    [BsonElement("stockQuantity")]
    public int StockQuantity { get; set; }
}