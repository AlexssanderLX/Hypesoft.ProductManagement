import { apiFetch } from "./api"
import { Product } from "@/types/product"

const API_BASE = "https://localhost:7251/api"

export async function getProducts(): Promise<Product[]> {
  return apiFetch("/products")
}

export async function getProductById(id: string) {

  const res = await fetch(`${API_BASE}/products/${id}`)

  if (!res.ok) throw new Error("Failed to fetch product")

  return res.json()
}
export async function getProductsByCategory(categoryId: string) {

  const res = await fetch(
    `https://localhost:7251/api/products/category/${categoryId}`
  )

  if (!res.ok) throw new Error("Failed to fetch products by category")

  return res.json()
}
export async function updateProduct(id: string, product: {
  name: string
  description: string
  price: number
  categoryId: string
  stockQuantity: number
}) {

  const res = await fetch(
    `${API_BASE}/products/${id}`,
    {
      method: "PUT",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(product)
    }
  )

  if (!res.ok) throw new Error("Update failed")
}

export async function searchProducts(name: string) {

  const res = await fetch(
    `https://localhost:7251/api/products/search?name=${name}`
  )

  if (!res.ok) throw new Error("Search failed")

  return res.json()
}

export async function createProduct(data: {
  name: string
  description: string
  price: number
  categoryId: string
  stockQuantity: number
}) {
  return apiFetch("/products", {
    method: "POST",
    body: JSON.stringify(data),
  })
}

export async function deleteProduct(id: string) {

  const res = await fetch(
    `${API_BASE}/products/${id}`,
    {
      method: "DELETE"
    }
  )

  if (!res.ok) throw new Error("Delete failed")
}

export async function updateStock(id: string, quantity: number) {
  return apiFetch(`/products/${id}/stock`, {
    method: "PATCH",
    body: JSON.stringify(quantity),
  })
}