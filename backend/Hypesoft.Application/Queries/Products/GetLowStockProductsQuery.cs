using MediatR;
using Hypesoft.Application.DTOs;

namespace Hypesoft.Application.Queries.Products;

public class GetLowStockProductsQuery : IRequest<IEnumerable<ProductDto>>
{
}