"use client"

import { useEffect, useState } from "react"

import Sidebar from "@/components/Sidebar"
import PageContainer from "@/components/PageContainer"
import PageHeader from "@/components/PageHeader"

import { getCategories, createCategory } from "@/services/categoryService"

import toast from "react-hot-toast"

type Category = {
  id: string
  name: string
  isActive: boolean
}

export default function CategoriesPage() {

  const [categories, setCategories] = useState<Category[]>([])
  const [name, setName] = useState("")
  const [loading, setLoading] = useState(true)

  async function loadCategories() {

    try {

      setLoading(true)

      const data: any = await getCategories()

      if (Array.isArray(data)) {
        setCategories(data)
      } else {
        setCategories([])
      }

    } catch {

      toast.error("Failed to load categories")

    } finally {

      setLoading(false)

    }

  }

  useEffect(() => {

    loadCategories()

  }, [])

  async function handleCreate(e: React.FormEvent) {

    e.preventDefault()

    if (name.trim().length < 3) {
      toast.error("Category must contain at least 3 characters")
      return
    }

    try {

      await createCategory({ name })

      toast.success("Category created")

      setName("")

      loadCategories()

    } catch {

      toast.error("Failed to create category")

    }

  }

  return (

    <div className="flex min-h-screen bg-slate-100">

      <Sidebar />

      <PageContainer>

        <PageHeader title="Categories" />

        {/* CREATE CATEGORY */}

        <form
          onSubmit={handleCreate}
          className="bg-white p-6 rounded-xl border shadow-sm mb-8 flex gap-4"
        >

          <input
            type="text"
            placeholder="Category name"
            value={name}
            onChange={(e) => setName(e.target.value)}
            minLength={3}
            maxLength={120}
            required
            className="border rounded-md p-2 flex-1 focus:ring-2 focus:ring-blue-500"
          />

          <button
            type="submit"
            className="bg-blue-600 text-white rounded-md px-4 py-2 hover:bg-blue-700 transition"
          >
            Create
          </button>

        </form>

        {/* LOADING */}

        {loading && (

          <div className="text-center py-10 text-slate-400">
            Loading categories...
          </div>

        )}

        {/* EMPTY */}

        {!loading && categories.length === 0 && (

          <div className="text-center py-10 text-slate-500">

            <p className="text-lg font-medium">
              No categories yet
            </p>

            <p className="text-sm">
              Create your first category above
            </p>

          </div>

        )}

        {/* TABLE */}

        {!loading && categories.length > 0 && (

          <div className="bg-white rounded-xl border shadow-sm p-6">

            <table className="w-full text-sm">

              <thead>

                <tr className="text-left border-b text-slate-500">

                  <th className="pb-3">Name</th>
                  <th>Status</th>

                </tr>

              </thead>

              <tbody>

                {categories.map((category) => (

                  <tr
                    key={category.id}
                    className="border-b hover:bg-slate-50"
                  >

                    <td className="py-3 font-medium">
                      {category.name}
                    </td>

                    <td>

                      <span
                        className={`px-2 py-1 text-xs rounded-full font-medium ${
                          category.isActive
                            ? "bg-green-100 text-green-700"
                            : "bg-gray-200 text-gray-600"
                        }`}
                      >
                        {category.isActive ? "Active" : "Inactive"}
                      </span>

                    </td>

                  </tr>

                ))}

              </tbody>

            </table>

          </div>

        )}

      </PageContainer>

    </div>

  )

}