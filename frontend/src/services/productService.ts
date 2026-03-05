import { apiFetch } from "./api";
import { Product } from "@/types/product";

export async function getProducts(): Promise<Product[]> {
  return apiFetch("/products");
}
export async function getProductById(id: string) {
  return apiFetch(`/products/${id}`);
}

export async function createProduct(data: any) {
  return apiFetch("/products", {
    method: "POST",
    body: JSON.stringify(data),
  });
}

export async function deleteProduct(id: string) {
  return apiFetch(`/products/${id}`, {
    method: "DELETE",
  });
}

export async function updateStock(id: string, stock: number) {
  return apiFetch(`/products/${id}/stock`, {
    method: "PATCH",
    body: JSON.stringify({ stock }),
  });
}