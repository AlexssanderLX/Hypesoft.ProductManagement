import { apiFetch } from "./api"
import { Product } from "@/types/product"

export async function getProducts(): Promise<Product[]> {
  return apiFetch("/products")
}

export async function getProductById(id: string) {
  return apiFetch(`/products/${id}`)
}

export async function getProductsByCategory(categoryId: string) {
  return apiFetch(`/products/category/${categoryId}`)
}

export async function searchProducts(name: string) {
  return apiFetch(`/products/search?name=${name}`)
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
    body: JSON.stringify(data)
  })
}

export async function updateProduct(id: string, product: {
  name: string
  description: string
  price: number
  categoryId: string
  stockQuantity: number
}) {
  return apiFetch(`/products/${id}`, {
    method: "PUT",
    body: JSON.stringify(product)
  })
}

export async function deleteProduct(id: string) {
  return apiFetch(`/products/${id}`, {
    method: "DELETE"
  })
}

export async function updateStock(id: string, quantity: number) {
  return apiFetch(`/products/${id}/stock`, {
    method: "PATCH",
    body: JSON.stringify(quantity)
  })
}