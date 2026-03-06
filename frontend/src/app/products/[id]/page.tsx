"use client"

import { useEffect, useState } from "react"
import { useParams, useRouter } from "next/navigation"

import Sidebar from "@/components/Sidebar"
import PageContainer from "@/components/PageContainer"
import PageHeader from "@/components/PageHeader"

import {
  getProductById,
  updateProduct,
  deleteProduct
} from "@/services/productService"

import toast from "react-hot-toast"

export default function ProductDetailsPage() {

  const { id } = useParams()
  const router = useRouter()

  const [product, setProduct] = useState<any>(null)

  const [name, setName] = useState("")
  const [description, setDescription] = useState("")
  const [price, setPrice] = useState(0)
  const [stock, setStock] = useState(0)

  async function loadProduct() {

    const data = await getProductById(id as string)

    setProduct(data)

    setName(data.name)
    setDescription(data.description)
    setPrice(data.price)

    setStock(
      data.stockQuantity ??
      data.stock?.quantity ??
      0
    )

  }

  useEffect(() => {
    loadProduct()
  }, [])

  async function handleUpdate() {

    try {

      await updateProduct(id as string, {
        name,
        description,
        price,
        categoryId: product.categoryId,
        stockQuantity: stock
      })

      toast.success("Product updated")

      loadProduct()

    } catch {

      toast.error("Failed to update product")

    }

  }

  async function handleDelete() {

    if (!confirm("Delete this product?")) return

    try {

      await deleteProduct(id as string)

      toast.success("Product deleted")

      router.push("/products")

    } catch {

      toast.error("Failed to delete product")

    }

  }

  if (!product) {

    return (

      <div className="flex min-h-screen bg-slate-100">

        <Sidebar />

        <PageContainer>

          <PageHeader title="Product Details" />

          <div className="text-slate-400">
            Loading product...
          </div>

        </PageContainer>

      </div>

    )

  }

  return (

    <div className="flex min-h-screen bg-slate-100">

      <Sidebar />

      <PageContainer>

        <PageHeader title="Product Details" />

        <div className="bg-white p-6 rounded-xl border shadow-sm grid gap-4 max-w-xl">

          <input
            className="border p-2 rounded"
            value={name}
            onChange={(e) => setName(e.target.value)}
          />

          <input
            className="border p-2 rounded"
            value={description}
            onChange={(e) => setDescription(e.target.value)}
          />

          <input
            type="number"
            className="border p-2 rounded"
            value={price}
            onChange={(e) => setPrice(Number(e.target.value))}
          />

          <input
            type="number"
            className="border p-2 rounded"
            value={stock}
            onChange={(e) => setStock(Number(e.target.value))}
          />

          <div className="flex gap-4 mt-4">

            <button
              onClick={handleUpdate}
              className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700"
            >
              Update Product
            </button>

            <button
              onClick={handleDelete}
              className="bg-red-600 text-white px-4 py-2 rounded hover:bg-red-700"
            >
              Delete Product
            </button>

          </div>

        </div>

      </PageContainer>

    </div>

  )

}