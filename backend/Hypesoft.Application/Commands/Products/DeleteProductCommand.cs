using MediatR;

namespace Hypesoft.Application.Commands.Products;

public class DeleteProductCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}