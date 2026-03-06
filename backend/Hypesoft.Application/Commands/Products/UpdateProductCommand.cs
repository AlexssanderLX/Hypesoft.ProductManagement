using MediatR;

namespace Hypesoft.Application.Commands.Products;

public class UpdateProductCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public Guid CategoryId { get; set; }

    public int StockQuantity { get; set; }
}