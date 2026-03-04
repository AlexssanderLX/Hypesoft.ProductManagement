using MediatR;
using Hypesoft.Application.DTOs;
using Hypesoft.Domain.Repositories;

namespace Hypesoft.Application.Queries.Dashboard;

public class GetDashboardSummaryQueryHandler
    : IRequestHandler<GetDashboardSummaryQuery, DashboardSummaryDto>
{
    private readonly IProductRepository _repository;

    public GetDashboardSummaryQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<DashboardSummaryDto> Handle(
        GetDashboardSummaryQuery request,
        CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllAsync(1, 1000);

        var totalProducts = products.Count();
        var totalStockValue = products.Sum(p => p.Price * p.Stock.Quantity);
        var lowStockProducts = products.Count(p => p.Stock.Quantity < 10);

        var productsByCategory = products
            .GroupBy(p => p.CategoryId.ToString())
            .ToDictionary(g => g.Key, g => g.Count());

        return new DashboardSummaryDto
        {
            TotalProducts = totalProducts,
            TotalStockValue = totalStockValue,
            LowStockProducts = lowStockProducts,
            ProductsByCategory = productsByCategory
        };
    }
}