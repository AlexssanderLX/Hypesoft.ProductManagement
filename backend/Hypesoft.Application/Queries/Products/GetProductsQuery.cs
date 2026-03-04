using MediatR;
using Hypesoft.Application.DTOs;
using Hypesoft.Application.Common;

namespace Hypesoft.Application.Queries.Products;

public class GetProductsQuery : IRequest<PagedResult<ProductDto>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;

    public GetProductsQuery(int page, int pageSize)
    {
        Page = page;
        PageSize = pageSize;
    }
}