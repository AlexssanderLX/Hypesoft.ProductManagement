using MediatR;
using Hypesoft.Application.Commands;
using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Repositories;
using Hypesoft.Application.DTOs;


namespace Hypesoft.API
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
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
            // Retorna DTO
            return new CategoryDto
            {
                Name = category.Name,
                Id = category.Id,
                IsActive = category.IsActive
                
            };
        }

    }
}
