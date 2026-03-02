using MediatR;
using Hypesoft.Application.Commands;
using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Repositories;


namespace Hypesoft.Application.Handlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var existinCategory = await _categoryRepository.GetByNameAsync(request.Name);
            if (existinCategory != null)
            {
                throw new Exception("Category with this name already exists.");
            }
            // Domain protege invariantes
            var category = new Category(request.Name);

            // Persiste
            await _categoryRepository.AddAsync(category);
            // Retorna Id
            return category.Id;
        }

    }
}
