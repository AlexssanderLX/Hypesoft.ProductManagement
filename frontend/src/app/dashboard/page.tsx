"use client"

import { useEffect, useState } from "react"

import Sidebar from "@/components/Sidebar"
import PageContainer from "@/components/PageContainer"
import PageHeader from "@/components/PageHeader"

import DashboardCards from "@/components/DashboardCards"
import ProductsTable from "@/components/ProductTable"
import DashboardSkeleton from "@/components/DashboardSkeleton"
import CategoryChart from "@/components/CategoryChart"

import { getDashboardSummary } from "@/services/dashboardService"

export default function DashboardPage() {

  const [summary, setSummary] = useState<any>(null)

  async function loadDashboard() {

    const data = await getDashboardSummary()

    setSummary(data)

  }

  useEffect(() => {

    loadDashboard()

  }, [])

  if (!summary) {

    return (

      <div className="flex min-h-screen bg-slate-100">

        <Sidebar />

        <PageContainer>

          <PageHeader title="Dashboard" />

          <DashboardSkeleton />

        </PageContainer>

      </div>

    )

  }

  return (

    <div className="flex min-h-screen bg-slate-100">

      <Sidebar />

      <PageContainer>

        <PageHeader title="Dashboard" />

        {/* DASHBOARD CARDS */}

        <DashboardCards
          totalProducts={summary.totalProducts}
          totalStockValue={summary.totalStockValue}
        />

        {/* LOW STOCK PRODUCTS */}

        <div className="mt-8 bg-white p-6 rounded-xl border shadow-sm">

          <h2 className="text-lg font-semibold mb-4">
            Low Stock Products
          </h2>

          <ProductsTable
            products={summary.lowStockProducts}
          />

        </div>

        {/* PRODUCTS BY CATEGORY */}

        <div className="mt-8 bg-white p-6 rounded-xl border shadow-sm">

          <h2 className="text-lg font-semibold mb-4">
            Products by Category
          </h2>

          <CategoryChart
            data={summary.productsByCategory}
          />

        </div>

      </PageContainer>

    </div>

  )

}