import { Plus } from "lucide-react";
import { motion } from "framer-motion";
import { useState } from "react";
import OrdersPage from "./pages/OrdersPage";

export default function App() {
  const [count, setCount] = useState(0); // Contador para controle de pedidos ou outro estado, se necessário

  const handleCreateOrder = () => {
    alert("Ação de criação de pedido (ainda não implementada)");
    // Aqui você pode adicionar a lógica real para criar o pedido
  };

  return (
    <motion.div
      className="min-h-screen bg-gray-50 flex flex-col items-center justify-center p-4"
      initial={{ opacity: 0, y: 20 }}
      animate={{ opacity: 1, y: 0 }}
      transition={{ duration: 0.4 }}
    >
      <h1 className="text-4xl font-bold text-[#66baff] mb-4">Sistema de Pedidos</h1>

      {/* Botão para criar pedidos */}
      <button
        onClick={handleCreateOrder}
        className="flex items-center gap-2 bg-[#66baff] hover:bg-blue-500 text-white font-semibold py-2 px-4 rounded-2xl shadow-md transition"
      >
        <Plus size={18} />
        Criar Pedido
      </button>

      {/* Tela de pedidos que vai ser mostrada */}
      <OrdersPage />
    </motion.div>
  );
}
