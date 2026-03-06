using MediatR;
using Hypesoft.Application.DTOs;
using Hypesoft.Domain.Repositories;

namespace Hypesoft.Application.Queries.Dashboard;

public class GetDashboardSummaryQueryHandler
    : IRequestHandler<GetDashboardSummaryQuery, DashboardSummaryDto>
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public GetDashboardSummaryQueryHandler(
        IProductRepository productRepository,
        ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<DashboardSummaryDto> Handle(
        GetDashboardSummaryQuery request,
        CancellationToken cancellationToken)
    {
        // pega produtos
        var products = await _productRepository.GetAllAsync(1, int.MaxValue);

        // pega categorias
        var categories = await _categoryRepository.GetAllAsync();

        // cria dicionário Id -> Name
        var categoryDictionary = categories
            .ToDictionary(c => c.Id, c => c.Name);

        // total de produtos
        var totalProducts = products.Count();

        // valor total do estoque
        var totalStockValue = products.Sum(p =>
            p.Price * p.Stock.Quantity
        );

        // produtos com estoque baixo
        var lowStockProducts = products
            .Where(p => p.Stock.Quantity < 10)
            .Select(p => new LowStockProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Stock = p.Stock.Quantity
            })
            .ToList();

        // agrupar produtos por nome da categoria
        var productsByCategory = products
            .GroupBy(p =>
                categoryDictionary.ContainsKey(p.CategoryId)
                    ? categoryDictionary[p.CategoryId]
                    : "Unknown"
            )
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