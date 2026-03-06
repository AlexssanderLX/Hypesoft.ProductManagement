"use client"

import {
  BarChart,
  Bar,
  XAxis,
  YAxis,
  Tooltip,
  ResponsiveContainer,
  CartesianGrid
} from "recharts"

export default function CategoryChart({ data }: any) {

  const chartData = Object.entries(data).map(([category, count]) => ({
    category,
    count
  }))

  return (

    <div className="bg-white border rounded-xl shadow-sm p-6">

      <h2 className="text-lg font-semibold mb-6">
        Products by Category
      </h2>

      <div style={{ width: "100%", height: 300 }}>

        <ResponsiveContainer>

          <BarChart data={chartData}>

            <CartesianGrid strokeDasharray="3 3" />

            <XAxis dataKey="category" />

            <YAxis />

            <Tooltip />

            <Bar dataKey="count" fill="#2563eb" />

          </BarChart>

        </ResponsiveContainer>

      </div>

    </div>

  )

}