using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Repositories;
using Hypesoft.Infrastructure.Data;
using Hypesoft.Infrastructure.Data.Documents;
using MongoDB.Driver;

namespace Hypesoft.Infrastructure.Repositories
{
    public class MongoCategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<CategoryDocument> _collection;

        public MongoCategoryRepository(MongoContext context)
        {
            _collection = context.Categories;
        }

        public async Task AddAsync(Category category)
        {
            var document = new CategoryDocument
            {
                Id = category.Id.ToString(),
                Name = category.Name,
                IsActive = category.IsActive
            };

            await _collection.InsertOneAsync(document);
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            var document = await _collection
                .Find(x => x.Id == id.ToString())
                .FirstOrDefaultAsync();

            if (document == null)
                return null;

            return MapToEntity(document);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var documents = await _collection
                .Find(_ => true)
                .ToListAsync();

            return documents.Select(MapToEntity);
        }
        public async Task<Category?> GetByNameAsync(string name)
        {
            var document = await _collection
                .Find(x => x.Name == name)
                .FirstOrDefaultAsync();

            if (document == null)
                return null;

            return MapToEntity(document);
        }
        public async Task UpdateAsync(Category category)
        {
            var document = new CategoryDocument
            {
                Id = category.Id.ToString(),
                Name = category.Name,
                IsActive = category.IsActive
            };

            await _collection.ReplaceOneAsync(
                x => x.Id == document.Id,
                document
            );
        }
        private Category MapToEntity(CategoryDocument document)
        {
            var category = new Category(document.Name);

            // sobrescreve o Id gerado no construtor
            typeof(Category)
                .GetProperty("Id")?
                .SetValue(category, Guid.Parse(document.Id));

            if (!document.IsActive)
                category.Deactivate(); // se você tiver esse método

            return category;
        }
    }
}