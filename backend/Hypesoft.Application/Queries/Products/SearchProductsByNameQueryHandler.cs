using MediatR;
using Hypesoft.Application.DTOs;
using Hypesoft.Domain.Repositories;
using System.Linq;

namespace Hypesoft.Application.Queries.Products;

public class SearchProductsByNameQueryHandler
    : IRequestHandler<SearchProductsByNameQuery, IEnumerable<ProductDto>>
{
    private readonly IProductRepository _repository;

    public SearchProductsByNameQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProductDto>> Handle(
        SearchProductsByNameQuery request,
        CancellationToken cancellationToken)
    {
        var products = await _repository.SearchByNameAsync(request.Name);

        return products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            CategoryId = p.CategoryId,
            StockQuantity = p.Stock.Quantity
        });
    }
}