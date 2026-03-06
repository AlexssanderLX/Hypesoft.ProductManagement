using MediatR;

namespace Hypesoft.Application.Queries.Dashboard;

public class GetProductsByCategoryChartQuery : IRequest<Dictionary<string, int>>
{
}