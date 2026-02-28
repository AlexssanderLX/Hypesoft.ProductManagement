import DashboardLayout from "../components/layout/dashboard-layout";
import StatCard from "../components/ui/stat-card";

export default function Home() {
  return (
    <DashboardLayout>
      <div className="grid grid-cols-3 gap-6">
        <StatCard title="Total Products" value="120" />
        <StatCard title="Low Stock" value="8" />
        <StatCard title="Stock Value" value="$0,000" />
      </div>
    </DashboardLayout>
  );
}