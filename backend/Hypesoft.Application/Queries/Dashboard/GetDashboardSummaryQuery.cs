using MediatR;
using Hypesoft.Application.DTOs;

namespace Hypesoft.Application.Queries.Dashboard;

public class GetDashboardSummaryQuery : IRequest<DashboardSummaryDto>
{
}