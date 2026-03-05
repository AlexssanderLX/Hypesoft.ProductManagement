"use client"

import { useEffect, useState } from "react"
import Sidebar from "@/components/Sidebar"
import DashboardCards from "@/components/DashboardCards"
import ProductsTable from "@/components/ProductTable"
import { getDashboardSummary } from "@/services/dashboardService"

export default function DashboardPage() {

  const [summary, setSummary] = useState<any>(null)

  useEffect(() => {
    async function load() {
      const data = await getDashboardSummary()
      setSummary(data)
    }

    load()
  }, [])

  if (!summary) return <p>Loading...</p>

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
        <h1 style={{ marginBottom: "30px" }}>Dashboard</h1>

        <DashboardCards
          totalProducts={summary.totalProducts}
          totalStockValue={summary.totalStockValue}
        />

        <ProductsTable
          products={summary.lowStockProducts}
        />
      </div>
    </div>
  )
}