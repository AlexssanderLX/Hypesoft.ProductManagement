import { apiFetch } from "./api";
import { DashboardSummary } from "@/types/dashboard";

export async function getDashboardSummary(): Promise<DashboardSummary> {
  return apiFetch("/dashboard/summary");
}
export async function getProductsByCategory() {

  const res = await fetch(
    "https://localhost:7251/api/dashboard/products-by-category"
  )

  if (!res.ok) throw new Error("Failed to fetch chart data")

  return res.json()
}