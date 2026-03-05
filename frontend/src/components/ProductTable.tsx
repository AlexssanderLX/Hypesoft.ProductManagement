interface Product {
  id: string
  name: string
  stock: number
}

export default function ProductsTable({ products }: { products: Product[] }) {
  return (
    <div
      style={{
        background: "white",
        padding: "24px",
        borderRadius: "12px",
        boxShadow: "0 4px 12px rgba(0,0,0,0.05)"
      }}
    >
      <h2 style={{ marginBottom: "20px" }}>Low Stock Products</h2>

      <table style={{ width: "100%", borderCollapse: "collapse" }}>
        <thead>
          <tr>
            <th style={{ textAlign: "left", paddingBottom: "10px" }}>Product</th>
            <th style={{ textAlign: "left", paddingBottom: "10px" }}>Stock</th>
          </tr>
        </thead>

        <tbody>
          {products.map((product) => (
            <tr key={product.id}>
              <td style={{ padding: "8px 0" }}>{product.name}</td>
              <td style={{ padding: "8px 0" }}>{product.stock}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  )
}