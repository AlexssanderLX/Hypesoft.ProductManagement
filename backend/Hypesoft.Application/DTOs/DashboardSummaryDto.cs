namespace Hypesoft.Application.DTOs;

public class DashboardSummaryDto
{
    public int TotalProducts { get; set; }
    public decimal TotalStockValue { get; set; }
    public int LowStockProducts { get; set; }
    public Dictionary<string, int> ProductsByCategory { get; set; }
}