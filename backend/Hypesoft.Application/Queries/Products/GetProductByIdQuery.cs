using MediatR;
using Hypesoft.Application.DTOs;

namespace Hypesoft.Application.Queries.Products;

public class GetProductByIdQuery : IRequest<ProductDto>
{
    public Guid Id { get; set; }

    public GetProductByIdQuery(Guid id)
    {
        Id = id;
    }
}