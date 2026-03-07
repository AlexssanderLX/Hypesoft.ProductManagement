"use client"

import { useEffect, useState } from "react"
import Sidebar from "@/components/Sidebar"
import PageContainer from "@/components/PageContainer"
import PageHeader from "@/components/PageHeader"

import {
  getProducts,
  createProduct,
  updateProduct,
  deleteProduct,
  searchProducts,
  getProductsByCategory
} from "@/services/productService"

import { getCategories } from "@/services/categoryService"

import toast from "react-hot-toast"

type Product = {
  id: string
  name: string
  description: string
  price: number
  categoryId: string
  stockQuantity?: number
  stock?: {
    quantity: number
  }
}

type Category = {
  id: string
  name: string
}

export default function ProductsPage() {

  const [products, setProducts] = useState<Product[]>([])
  const [categories, setCategories] = useState<Category[]>([])
  const [loading, setLoading] = useState(true)

  const [editingId, setEditingId] = useState<string | null>(null)

  const [name, setName] = useState("")
  const [description, setDescription] = useState("")
  const [price, setPrice] = useState<number | "">("")
  const [stock, setStock] = useState<number | "">("")
  const [categoryId, setCategoryId] = useState("")

  const [search, setSearch] = useState("")
  const [filterCategory, setFilterCategory] = useState("")

  async function loadProducts() {

    try {

      setLoading(true)

      const data: any = await getProducts()

      if (Array.isArray(data)) setProducts(data)
      else if (data?.items) setProducts(data.items)
      else setProducts([])

    } catch {

      toast.error("Failed to load products")

    } finally {

      setLoading(false)

    }

  }

  async function loadCategories() {

    try {

      const data = await getCategories()

      if (Array.isArray(data)) setCategories(data)
      else setCategories([])

    } catch {

      toast.error("Failed to load categories")

    }

  }

  useEffect(() => {

    loadProducts()
    loadCategories()

  }, [])

  async function handleSubmit(e: React.FormEvent) {

    e.preventDefault()

    if (name.length < 3) {
      toast.error("Name must contain at least 3 characters")
      return
    }

    if (!price || price <= 0) {
      toast.error("Price must be greater than zero")
      return
    }

    if (stock === "" || stock < 0) {
      toast.error("Stock must be zero or greater")
      return
    }

    if (!categoryId) {
      toast.error("Please select a category")
      return
    }

    try {

      if (editingId) {

        await updateProduct(editingId, {
          name,
          description,
          price,
          categoryId,
          stockQuantity: stock
        })

        toast.success("Product updated")

      } else {

        await createProduct({
          name,
          description,
          price,
          categoryId,
          stockQuantity: stock
        })

        toast.success("Product created")

      }

      setEditingId(null)

      setName("")
      setDescription("")
      setPrice("")
      setStock("")
      setCategoryId("")

      await loadProducts()

    } catch {

      toast.error("Operation failed")

    }

  }

  async function handleDelete(id: string) {

    if (!confirm("Delete this product?")) return

    try {

      await deleteProduct(id)

      toast.success("Product deleted")

      await loadProducts()

    } catch {

      toast.error("Failed to delete product")

    }

  }

  function handleEdit(product: Product) {

    setEditingId(product.id)

    setName(product.name)
    setDescription(product.description)
    setPrice(product.price)

    setStock(
      product.stockQuantity ??
      product.stock?.quantity ??
      0
    )

    setCategoryId(product.categoryId)

  }

  async function handleSearch() {

    if (!search) {
      await loadProducts()
      return
    }

    try {

      const result = await searchProducts(search)

      setProducts(result)

    } catch {

      toast.error("Search failed")

    }

  }

  async function handleFilterCategory() {

    if (!filterCategory) {
      await loadProducts()
      return
    }

    try {

      const result = await getProductsByCategory(filterCategory)

      setProducts(result)

    } catch {

      toast.error("Filter failed")

    }

  }

  return (

    <div className="flex min-h-screen bg-slate-100">

      <Sidebar />

      <PageContainer>

        <PageHeader title="Products" />

        {editingId && (

          <div className="mb-4 text-sm text-blue-600 font-medium">
            Editing product...
          </div>

        )}

        <form
          onSubmit={handleSubmit}
          className="bg-white p-6 rounded-xl border shadow-sm mb-6 grid md:grid-cols-3 gap-4"
        >

          <input
            type="text"
            placeholder="Product name"
            value={name}
            onChange={(e) => setName(e.target.value)}
            className="border rounded-md p-2"
            required
          />

          <input
            type="text"
            placeholder="Description"
            value={description}
            onChange={(e) => setDescription(e.target.value)}
            className="border rounded-md p-2"
            required
          />

          <input
            type="number"
            placeholder="Price"
            value={price}
            onChange={(e) =>
              setPrice(e.target.value === "" ? "" : Number(e.target.value))
            }
            className="border rounded-md p-2"
            required
          />

          <input
            type="number"
            placeholder="Stock"
            value={stock}
            onChange={(e) =>
              setStock(e.target.value === "" ? "" : Number(e.target.value))
            }
            className="border rounded-md p-2"
            required
          />

          <select
            value={categoryId}
            onChange={(e) => setCategoryId(e.target.value)}
            className="border rounded-md p-2"
            required
          >

            <option value="">Select Category</option>

            {categories.map((c) => (
              <option key={c.id} value={c.id}>
                {c.name}
              </option>
            ))}

          </select>

          <button
            type="submit"
            className="bg-blue-600 text-white rounded-md px-4 py-2"
          >
            {editingId ? "Update Product" : "Create Product"}
          </button>

        </form>

        <div className="flex gap-4 mb-4">

          <input
            type="text"
            placeholder="Search product..."
            value={search}
            onChange={(e) => setSearch(e.target.value)}
            className="border rounded-md p-2 w-64"
          />

          <button
            onClick={handleSearch}
            className="bg-slate-800 text-white px-4 py-2 rounded-md"
          >
            Search
          </button>

          <select
            value={filterCategory}
            onChange={(e) => setFilterCategory(e.target.value)}
            className="border rounded-md p-2"
          >

            <option value="">All Categories</option>

            {categories.map((c) => (
              <option key={c.id} value={c.id}>
                {c.name}
              </option>
            ))}

          </select>

          <button
            onClick={handleFilterCategory}
            className="bg-blue-600 text-white px-4 py-2 rounded-md"
          >
            Filter
          </button>

        </div>

        <div className="bg-white rounded-xl border shadow-sm p-6">

          <table className="w-full text-sm">

            <thead>

              <tr className="text-left border-b text-slate-500">

                <th>Name</th>
                <th>Description</th>
                <th>Price</th>
                <th>Stock</th>
                <th className="text-right">Actions</th>

              </tr>

            </thead>

            <tbody>

              {products.map((product) => (

                <tr key={product.id} className="border-b">

                  <td className="py-3 font-medium">{product.name}</td>

                  <td>{product.description}</td>

                  <td>${product.price.toLocaleString()}</td>

                  <td>

                    <span className="bg-blue-100 text-blue-700 px-2 py-1 text-xs rounded-full">

                      {product.stockQuantity ??
                        product.stock?.quantity ??
                        0}

                    </span>

                  </td>

                  <td className="py-3 flex justify-end gap-2">

                    <button
                      onClick={() => handleEdit(product)}
                      className="px-3 py-1 text-xs border rounded-md"
                    >
                      Edit
                    </button>

                    <button
                      onClick={() => handleDelete(product.id)}
                      className="px-3 py-1 text-xs bg-red-500 text-white rounded-md"
                    >
                      Delete
                    </button>

                  </td>

                </tr>

              ))}

            </tbody>

          </table>

        </div>

      </PageContainer>

    </div>

  )

}