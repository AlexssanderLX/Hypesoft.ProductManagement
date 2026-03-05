export default function Sidebar() {
  return (
    <div
      style={{
        width: "220px",
        height: "100vh",
        background: "#0f172a",
        color: "white",
        padding: "20px",
        position: "sticky",
        top: 0
      }}
    >
      <h2 style={{ marginBottom: "40px" }}>ShopSense</h2>

      <nav style={{ display: "flex", flexDirection: "column", gap: "20px" }}>
        <a href="/dashboard" style={{ color: "white", textDecoration: "none" }}>
          Dashboard
        </a>

        <a href="/products" style={{ color: "white", textDecoration: "none" }}>
          Products
        </a>
      </nav>
    </div>
  )
}