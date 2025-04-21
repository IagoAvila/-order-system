const API_BASE_URL = "https://localhost:5001/api";

export async function getOrders() {
  const response = await fetch(`${API_BASE_URL}/orders`);
  if (!response.ok) {
    throw new Error("Erro ao buscar pedidos");
  }
  return await response.json();
}
