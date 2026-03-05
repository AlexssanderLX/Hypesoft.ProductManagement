interface Props {
  totalProducts: number
  totalStockValue: number
}

export default function DashboardCards({ totalProducts, totalStockValue }: Props) {
  return (
    <div
      style={{
        display: "grid",
        gridTemplateColumns: "repeat(2, 1fr)",
        gap: "20px",
        marginBottom: "30px"
      }}
    >
      <div
        style={{
          background: "white",
          padding: "24px",
          borderRadius: "12px",
          boxShadow: "0 4px 12px rgba(0,0,0,0.05)"
        }}
      >
        <h3>Total Products</h3>
        <p style={{ fontSize: "28px", fontWeight: "bold" }}>
          {totalProducts}
        </p>
      </div>

      <div
        style={{
          background: "white",
          padding: "24px",
          borderRadius: "12px",
          boxShadow: "0 4px 12px rgba(0,0,0,0.05)"
        }}
      >
        <h3>Total Stock Value</h3>
        <p style={{ fontSize: "28px", fontWeight: "bold" }}>
          ${totalStockValue}
        </p>
      </div>
    </div>
  )
}