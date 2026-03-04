using MediatR;
using Hypesoft.Application.DTOs;

namespace Hypesoft.Application.Queries.Products;

public class SearchProductsByNameQuery : IRequest<IEnumerable<ProductDto>>
{
    public string Name { get; set; }

    public SearchProductsByNameQuery(string name)
    {
        Name = name;
    }
}