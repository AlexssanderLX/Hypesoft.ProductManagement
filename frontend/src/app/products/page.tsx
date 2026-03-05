"use client"

import { useEffect, useState } from "react"
import Sidebar from "@/components/Sidebar"

interface Product {
  id: string
  name: string
  price: number
}

export default function ProductsPage() {

  const [products, setProducts] = useState<Product[]>([])

  useEffect(() => {
    async function loadProducts() {

      const response = await fetch("https://localhost:7251/api/products")
      const data = await response.json()

      setProducts(data.items || data)
    }

    loadProducts()

  }, [])

  return (

    <div
      style={{
        display: "flex",
        minHeight: "100vh",
        background: "#f1f5f9"
      }}
    >

      <Sidebar />

      <div
        style={{
          flex: 1,
          padding: "40px",
          maxWidth: "1200px"
        }}
      >

        <h1 style={{ marginBottom: "30px" }}>Products</h1>

        <div
          style={{
            background: "white",
            borderRadius: "12px",
            padding: "24px",
            boxShadow: "0 4px 12px rgba(0,0,0,0.05)"
          }}
        >

          <table
            style={{
              width: "100%",
              borderCollapse: "collapse"
            }}
          >

            <thead>

              <tr style={{ borderBottom: "1px solid #e5e7eb" }}>
                <th style={{ textAlign: "left", padding: "12px" }}>Product</th>
                <th style={{ textAlign: "left", padding: "12px" }}>Price</th>
              </tr>

            </thead>

            <tbody>

              {products.map(product => (

                <tr
                  key={product.id}
                  style={{
                    borderBottom: "1px solid #f1f5f9"
                  }}
                >

                  <td style={{ padding: "12px" }}>
                    {product.name}
                  </td>

                  <td style={{ padding: "12px" }}>
                    ${product.price}
                  </td>

                </tr>

              ))}

            </tbody>

          </table>

        </div>

      </div>

    </div>

  )
}