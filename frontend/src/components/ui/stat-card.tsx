export default function StatCard({
  title,
  value,
}: {
  title: string;
  value: string;
}) {
   return (
    <div className="bg-white p-6 rounded-xl shadow border">
      <p className="text-gray-900 text-sm font-medium">{title}</p>
      <h2 className="text-3xl font-bold mt-2 text-gray-900">{value}</h2>
    </div>
  );
}