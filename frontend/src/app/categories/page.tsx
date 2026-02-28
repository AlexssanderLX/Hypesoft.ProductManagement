import DashboardLayout from "../../components/layout/dashboard-layout";

export default function CategoriesPage() {
  return (
    <DashboardLayout>
      <h1 className="text-3xl font-bold mb-6 text-gray-900">
        Categories
      </h1>

      <div className="bg-white rounded-xl shadow p-6 border">
        <table className="w-full text-left text-gray-800">
          <thead>
            <tr className="border-b text-gray-600">
              <th className="py-3 font-semibold">Category Name</th>
              <th className="font-semibold">Products Count</th>
            </tr>
          </thead>
          <tbody>
            <tr className="border-b hover:bg-gray-50">
              <td className="py-4">Electronics</td>
              <td>12</td>
            </tr>
            <tr className="hover:bg-gray-50">
              <td className="py-4">Accessories</td>
              <td>8</td>
            </tr>
          </tbody>
        </table>
      </div>
    </DashboardLayout>
  );
}