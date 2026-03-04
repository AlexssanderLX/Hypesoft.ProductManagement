using MediatR;
using Hypesoft.Application.DTOs;

namespace Hypesoft.Application.Queries.Products;

public class GetProductsByCategoryQuery : IRequest<IEnumerable<ProductDto>>
{
    public Guid CategoryId { get; set; }

    public GetProductsByCategoryQuery(Guid categoryId)
    {
        CategoryId = categoryId;
    }
}