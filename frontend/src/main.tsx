import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App"; // Certifique-se de que o caminho está correto
import "./index.css"; // Caso necessário

ReactDOM.createRoot(document.getElementById("root") as HTMLElement).render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);
