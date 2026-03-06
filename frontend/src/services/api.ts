const API_BASE_URL = "https://localhost:7251/api"

export async function apiFetch<T>(
  endpoint: string,
  options: RequestInit = {}
): Promise<T> {

  const response = await fetch(`${API_BASE_URL}${endpoint}`, {
    headers: {
      "Content-Type": "application/json"
    },
    ...options
  })

  if (!response.ok) {
    const text = await response.text()
    console.error("API ERROR:", text)
    throw new Error(`API error: ${response.status}`)
  }

  // evita erro quando API retorna 204
  const text = await response.text()

  if (!text) {
    return {} as T
  }

  return JSON.parse(text)
}