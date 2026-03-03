using Hypesoft.Infrastructure.Configurations;
using Hypesoft.Infrastructure.Data.Documents;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Hypesoft.Infrastructure.Data
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(IOptions<MongoOptions> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _database = client.GetDatabase(options.Value.DatabaseName);
        }

        public IMongoCollection<CategoryDocument> Categories =>
            _database.GetCollection<CategoryDocument>("categories");

        public IMongoCollection<ProductDocument> Products =>
            _database.GetCollection<ProductDocument>("products");
    }
}