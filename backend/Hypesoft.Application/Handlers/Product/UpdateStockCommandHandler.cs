using MediatR;
using Hypesoft.Domain.Repositories;

namespace Hypesoft.Application.Commands.Products;

public class UpdateStockCommandHandler
    : IRequestHandler<UpdateStockCommand, bool>
{
    private readonly IProductRepository _repository;

    public UpdateStockCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        UpdateStockCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.ProductId);

        if (product == null)
            return false;

        product.UpdateStock(request.Quantity);

        await _repository.UpdateAsync(product);

        return true;
    }
}