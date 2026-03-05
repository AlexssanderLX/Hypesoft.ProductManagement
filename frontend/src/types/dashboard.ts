export interface LowStockProduct {
  id: string;
  name: string;
  stock: number;
}

export interface DashboardSummary {
  totalProducts: number;
  totalStockValue: number;
  lowStockProducts: LowStockProduct[];
  productsByCategory: Record<string, number>;
}