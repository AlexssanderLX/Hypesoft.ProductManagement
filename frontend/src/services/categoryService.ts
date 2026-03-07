const API_URL = "http://localhost:5000/api"

import { apiFetch } from "./api"

export type Category = {
  id: string
  name: string
  isActive?: boolean
}

export async function getCategories(): Promise<Category[]> {
  return apiFetch("/categories")
}

export async function createCategory(data: { name: string }) {
  return apiFetch("/categories", {
    method: "POST",
    body: JSON.stringify(data),
  })
}