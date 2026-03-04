using MediatR;
using Hypesoft.Application.Common;
using Hypesoft.Application.DTOs;
using Hypesoft.Domain.Repositories;

namespace Hypesoft.Application.Queries.Products;

public class GetProductsQueryHandler
    : IRequestHandler<GetProductsQuery, PagedResult<ProductDto>>
{
    private readonly IProductRepository _repository;

    public GetProductsQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResult<ProductDto>> Handle(
        GetProductsQuery request,
        CancellationToken cancellationToken)
    {
        var (products, totalCount) =
            await _repository.GetPagedAsync(request.Page, request.PageSize);

        var dtos = products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            CategoryId = p.CategoryId,
            StockQuantity = p.Stock.Quantity
        });

        return new PagedResult<ProductDto>(
            dtos,
            totalCount,
            request.Page,
            request.PageSize
        );
    }
}