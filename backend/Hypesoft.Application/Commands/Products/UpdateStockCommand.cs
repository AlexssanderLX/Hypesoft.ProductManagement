using MediatR;

namespace Hypesoft.Application.Commands.Products;

public class UpdateStockCommand : IRequest<bool>
{
    public Guid ProductId { get; set; }

    public int Quantity { get; set; }
}