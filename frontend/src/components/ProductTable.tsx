"use client"

import { useRouter } from "next/navigation"

export default function ProductsTable({ products }: any) {


  const router = useRouter()
  return (

    <div className="bg-white rounded-xl border shadow-sm p-6">

      <h2 className="text-lg font-semibold mb-6">
        Low Stock Products
      </h2>

      <table className="w-full text-sm">

        <thead>

          <tr className="text-left border-b text-slate-500">

            <th className="pb-3">Product</th>
            <th className="pb-3">Stock</th>

          </tr>

        </thead>

        <tbody>

          {products.map((product: any) => {

            const stock = product.stock ?? product.stockQuantity ?? 0

            return (

              <tr
  key={product.id}
  onClick={() => router.push(`/products/${product.id}`)}
  className="cursor-pointer border-b hover:bg-slate-50"
>

                <td className="py-3 font-medium">
                  {product.name}
                </td>

                <td className="py-3">

                  <span
                    className={
                      stock < 5
                        ? "bg-red-100 text-red-600 text-xs px-2 py-1 rounded-full font-semibold"
                        : stock < 10
                        ? "bg-yellow-100 text-yellow-600 text-xs px-2 py-1 rounded-full font-semibold"
                        : "bg-blue-100 text-blue-700 text-xs px-2 py-1 rounded-full font-semibold"
                    }
                  >
                    {stock}
                  </span>

                </td>

              </tr>

            )

          })}

        </tbody>

      </table>

    </div>

  )

}