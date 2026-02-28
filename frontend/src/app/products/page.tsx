import DashboardLayout from "../../components/layout/dashboard-layout";

export default function ProductsPage() {
  return (
    <DashboardLayout>
      <h1 className="text-3xl font-bold mb-6 text-gray-900">Products</h1>

     <div className="bg-white rounded-xl shadow p-6 border">
  <table className="w-full text-left text-gray-800">
    <thead>
      <tr className="border-b text-gray-600">
        <th className="py-3 font-semibold">Name</th>
        <th className="font-semibold">Category</th>
        <th className="font-semibold">Price</th>
        <th className="font-semibold">Stock</th>
      </tr>
    </thead>
    <tbody>
      <tr className="border-b hover:bg-gray-50">
        <td className="py-4">Laptop</td>
        <td>Electronics</td>
        <td>$1200</td>
        <td>15</td>
      </tr>
      <tr className="hover:bg-gray-50">
        <td className="py-4">Mouse</td>
        <td>Accessories</td>
        <td>$25</td>
        <td>8</td>
      </tr>
    </tbody>
  </table>
</div>
    </DashboardLayout>
  );
}