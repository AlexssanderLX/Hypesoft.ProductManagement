import { apiFetch } from "./api";
import { DashboardSummary } from "@/types/dashboard";

export async function getDashboardSummary(): Promise<DashboardSummary> {
  return apiFetch("/dashboard/summary");
}