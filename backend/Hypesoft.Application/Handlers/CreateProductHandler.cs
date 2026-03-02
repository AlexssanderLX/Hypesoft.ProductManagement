
using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Repositories;
using Hypesoft.Domain.Exceptions;
using MediatR;
using Hypesoft.Application.Commands;

namespace Hypesoft.Application.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CreateProductHandler(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Guid> Handle(
            CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            
            var category = await _categoryRepository
                .GetByIdAsync(request.CategoryId);

            if (category is null)
                throw new DomainException("Category not found.");

            if (!category.IsActive)
                throw new DomainException("Category is inactive.");

            
            var existingProduct = await _productRepository
                .GetByNameAsync(request.Name);

            if (existingProduct is not null)
                throw new DomainException("Product name already exists.");

            // Domain protege invariantes
            var product = new Product(
                request.Name,
                request.Description,
                request.Price,
                request.CategoryId,
                request.InitialStock);

            //Persiste
            await _productRepository.AddAsync(product);
            // Retorna id
            return product.Id;
        }
    }
}