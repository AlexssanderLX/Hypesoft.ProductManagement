using MediatR;
using Hypesoft.Domain.Repositories;
using Hypesoft.Application.Commands.Products;

namespace Hypesoft.Application.Handlers.Product;

public class UpdateStockHandler : IRequestHandler<UpdateStockCommand, bool>
{
    private readonly IProductRepository _repository;

    public UpdateStockHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.ProductId);

        if (product == null)
            return false;

        product.UpdateStock(request.Quantity);

        await _repository.UpdateAsync(product);

        return true;
    }
}