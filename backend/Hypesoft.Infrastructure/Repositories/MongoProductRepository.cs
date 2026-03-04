using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Repositories;
using Hypesoft.Infrastructure.Data;
using Hypesoft.Infrastructure.Data.Documents;
using MongoDB.Driver;

namespace Hypesoft.Infrastructure.Repositories;

public class MongoProductRepository : IProductRepository
{
    private readonly IMongoCollection<ProductDocument> _collection;

    public MongoProductRepository(MongoContext context)
    {
        _collection = context.Products;
    }

    public async Task AddAsync(Product product)
    {
        var document = new ProductDocument
        {
            Id = product.Id.ToString(),
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            CategoryId = product.CategoryId.ToString(),
            StockQuantity = product.Stock.Quantity
        };

        await _collection.InsertOneAsync(document);
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        var document = await _collection
            .Find(x => x.Id == id.ToString())
            .FirstOrDefaultAsync();

        if (document == null)
            return null;

        return MapToEntity(document);
    }
    public async Task<IEnumerable<Product>> GetAllAsync(int page, int pageSize)
    {
        var skip = (page - 1) * pageSize;

        var documents = await _collection
            .Find(_ => true)
            .Skip(skip)
            .Limit(pageSize)
            .ToListAsync();

        return documents.Select(MapToEntity);
    }
    public async Task DeleteAsync(Guid id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id.ToString());
    }
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var documents = await _collection
            .Find(_ => true)
            .ToListAsync();

        return documents.Select(MapToEntity);
    }
    public async Task<(IEnumerable<Product> Items, int TotalCount)>
    GetPagedAsync(int page, int pageSize)
    {
        var totalCount = await _collection.CountDocumentsAsync(_ => true);

        var documents = await _collection
            .Find(_ => true)
            .Skip((page - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();

        var products = documents.Select(MapToEntity);

        return (products, (int)totalCount);
    }
    public async Task<Product?> GetByNameAsync(string name)
    {
        var document = await _collection
            .Find(x => x.Name == name)
            .FirstOrDefaultAsync();

        if (document == null)
            return null;

        return MapToEntity(document);
    }

    public async Task UpdateAsync(Product product)
    {
        var document = new ProductDocument
        {
            Id = product.Id.ToString(),
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            CategoryId = product.CategoryId.ToString(),
            StockQuantity = product.Stock.Quantity
        };

        await _collection.ReplaceOneAsync(
            x => x.Id == document.Id,
            document
        );
    }
    public async Task<IEnumerable<Product>> SearchByNameAsync(string name)
    {
        
        var filter = Builders<ProductDocument>.Filter.Regex(
            x => x.Name,
            new MongoDB.Bson.BsonRegularExpression(name, "i")
        );

        var documents = await _collection.Find(filter).ToListAsync();

        return documents.Select(MapToEntity);
    }
    public async Task<IEnumerable<Product>> GetByCategoryAsync(Guid categoryId)
    {
        var filter = Builders<ProductDocument>.Filter
            .Eq(p => p.CategoryId, categoryId.ToString());

        var documents = await _collection
            .Find(filter)
            .ToListAsync();

        return documents.Select(MapToEntity);
    }
    private Product MapToEntity(ProductDocument document)
    {
        var product = new Product(
            document.Name,
            document.Description,
            document.Price,
            Guid.Parse(document.CategoryId),
            document.StockQuantity
        );

        typeof(Product)
            .GetProperty("Id")?
            .SetValue(product, Guid.Parse(document.Id));

        return product;
    }
}