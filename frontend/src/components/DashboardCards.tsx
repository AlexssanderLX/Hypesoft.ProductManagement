export default function DashboardCards({
  totalProducts,
  totalStockValue
}: any) {

  return (

    <div className="grid md:grid-cols-2 gap-6 mb-8">

      <div className="bg-white border rounded-xl p-6 shadow-sm">

        <p className="text-sm text-slate-500">
          Total Products
        </p>

        <h2 className="text-3xl font-semibold mt-2">
          {totalProducts}
        </h2>

      </div>

      <div className="bg-white border rounded-xl p-6 shadow-sm">

        <p className="text-sm text-slate-500">
          Total Stock Value
        </p>

        <h2 className="text-3xl font-semibold mt-2">
          ${totalStockValue}
        </h2>

      </div>

    </div>

  )

}