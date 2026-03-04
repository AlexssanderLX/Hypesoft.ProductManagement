
using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Repositories;
using Hypesoft.Domain.Exceptions;
using MediatR;
using Hypesoft.Application.Commands;
using Hypesoft.Application.DTOs;

namespace Hypesoft.Application.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
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

        public async Task<ProductDto> Handle(
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
                .SearchByNameAsync(request.Name);

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
            // Retorna DTO
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                StockQuantity = product.Stock.Quantity
            };
        }
    }
}