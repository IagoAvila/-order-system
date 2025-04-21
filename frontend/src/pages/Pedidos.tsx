import { useEffect, useState } from "react";
import { motion } from "framer-motion";
import { PackageSearch, Loader2 } from "lucide-react";
import axios from "axios";

type Pedido = {
  id: string;
  cliente: string;
  status: string;
  dataCriacao: string;
};

export default function Pedidos() {
  const [pedidos, setPedidos] = useState<Pedido[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    axios.get("http://localhost:5000/api/pedidos") // Altere se a URL da sua API for diferente
      .then((res) => setPedidos(res.data))
      .catch((err) => console.error(err))
      .finally(() => setLoading(false));
  }, []);

  return (
    <div className="p-6">
      <h1 className="text-2xl font-bold mb-4 text-[#66baff] flex items-center gap-2">
        <PackageSearch size={28} /> Lista de Pedidos
      </h1>

      {loading ? (
        <div className="flex justify-center items-center mt-10">
          <Loader2 className="animate-spin text-[#66baff]" size={40} />
        </div>
      ) : (
        <motion.div
          initial={{ opacity: 0, y: 10 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.3 }}
          className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4"
        >
          {pedidos.map((pedido) => (
            <motion.div
              key={pedido.id}
              className="bg-white shadow-md rounded-2xl p-4 border border-[#66baff]/20"
              whileHover={{ scale: 1.02 }}
            >
              <p><strong>Cliente:</strong> {pedido.cliente}</p>
              <p><strong>Status:</strong> {pedido.status}</p>
              <p><strong>Data:</strong> {new Date(pedido.dataCriacao).toLocaleDateString()}</p>
            </motion.div>
          ))}
        </motion.div>
      )}
    </div>
  );
}
