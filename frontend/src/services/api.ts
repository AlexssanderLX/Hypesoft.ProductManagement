const API_BASE = "http://localhost:5000/api"

export async function apiFetch(
  endpoint: string,
  options: RequestInit = {}
) {

  const res = await fetch(`${API_BASE}${endpoint}`, {
    headers: {
      "Content-Type": "application/json",
      ...(options.headers || {})
    },
    ...options
  })

  if (!res.ok) {
    throw new Error("API request failed")
  }

  return res.json()
}