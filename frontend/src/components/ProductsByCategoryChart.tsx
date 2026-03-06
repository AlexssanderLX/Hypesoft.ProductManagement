"use client"

import { useEffect, useState } from "react"
import { PieChart, Pie, Tooltip, Cell } from "recharts"
import { getProductsByCategory } from "@/services/dashboardService"

const COLORS = ["#3b82f6", "#10b981", "#f59e0b", "#ef4444"]

export default function ProductsByCategoryChart() {

  const [data, setData] = useState<any[]>([])

  useEffect(() => {

    async function load() {

      const result = await getProductsByCategory()

      const formatted = Object.entries(result).map(
        ([category, count]) => ({
          name: category,
          value: count
        })
      )

      setData(formatted)

    }

    load()

  }, [])

  return (

    <PieChart width={300} height={300}>

      <Pie
        data={data}
        dataKey="value"
        nameKey="name"
        outerRadius={100}
      >

        {data.map((entry, index) => (

          <Cell
            key={index}
            fill={COLORS[index % COLORS.length]}
          />

        ))}

      </Pie>

      <Tooltip />

    </PieChart>

  )

}