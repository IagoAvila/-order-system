import { Plus, Edit, Trash } from "lucide-react";
import { motion } from "framer-motion";
import { useState } from "react";

export default function OrdersPage() {
  const [orders, setOrders] = useState([
    { id: "1", description: "Pedido 1", status: "Pendente" },
    { id: "2", description: "Pedido 2", status: "Processando" },
  ]);

  const handleCreateOrder = () => {
    const newOrder = {
      id: crypto.randomUUID(),
      description: `Pedido ${orders.length + 1}`,
      status: "Pendente",
    };
    setOrders((prev) => [...prev, newOrder]);
  };

  const handleDeleteOrder = (id: string) => {
    setOrders(orders.filter(order => order.id !== id));
  };

  const handleEditOrder = (id: string) => {
    const editedOrders = orders.map(order =>
      order.id === id ? { ...order, description: `${order.description} (Editado)` } : order
    );
    setOrders(editedOrders);
  };

  return (
    <motion.div
      className="min-h-screen bg-gray-50 flex flex-col items-center justify-start p-8"
      initial={{ opacity: 0, y: 20 }}
      animate={{ opacity: 1, y: 0 }}
      transition={{ duration: 0.4 }}
    >
      <h1 className="text-4xl font-bold text-[#66baff] mb-6">Sistema de Pedidos</h1>

      <button
        onClick={handleCreateOrder}
        className="flex items-center gap-2 bg-[#66baff] hover:bg-blue-500 text-white font-semibold py-2 px-4 rounded-2xl shadow-md transition"
      >
        <Plus size={18} />
        Criar Pedido
      </button>

      <h2 className="text-2xl font-semibold mt-10 mb-4 text-gray-800">Pedidos</h2>

      <div className="w-full max-w-md space-y-4">
        {orders.map((order) => (
          <motion.div
            key={order.id}
            className="border border-gray-300 rounded-xl p-4 shadow-sm bg-white"
            initial={{ opacity: 0, y: 10 }}
            animate={{ opacity: 1, y: 0 }}
            transition={{ duration: 0.3 }}
          >
            <p className="font-semibold text-lg text-gray-800">{order.description}</p>
            <p className="text-sm text-gray-500">Status: {order.status}</p>

            <div className="flex gap-2 mt-4">
              <button
                onClick={() => handleEditOrder(order.id)}
                className="flex items-center gap-1 bg-yellow-500 hover:bg-yellow-400 text-white p-2 rounded-lg"
              >
                <Edit size={16} /> Editar
              </button>
              <button
                onClick={() => handleDeleteOrder(order.id)}
                className="flex items-center gap-1 bg-red-500 hover:bg-red-400 text-white p-2 rounded-lg"
              >
                <Trash size={16} /> Excluir
              </button>
            </div>
          </motion.div>
        ))}
      </div>
    </motion.div>
  );
}
