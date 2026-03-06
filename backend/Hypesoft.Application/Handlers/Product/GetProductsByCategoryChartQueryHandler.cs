using MediatR;
using Hypesoft.Domain.Repositories;

namespace Hypesoft.Application.Queries.Dashboard;

public class GetProductsByCategoryChartQueryHandler
    : IRequestHandler<GetProductsByCategoryChartQuery, Dictionary<string, int>>
{
    private readonly IProductRepository _repository;

    public GetProductsByCategoryChartQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Dictionary<string, int>> Handle(
        GetProductsByCategoryChartQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetProductsByCategoryAsync();
    }
}