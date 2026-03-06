export interface Product {
  id: string
  name: string
  description: string
  price: number
  stock: {
    quantity: number
  }
  categoryId: string
}