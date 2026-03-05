namespace Hypesoft.Application.DTOs;

public class DashboardSummaryDto
{
    public int TotalProducts { get; set; }
    public decimal TotalStockValue { get; set; }
    public List<LowStockProductDto> LowStockProducts { get; set; } = new ();
    public Dictionary<string, int> ProductsByCategory { get; set; }
}