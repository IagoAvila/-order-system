# Sistema de Gestão de Pedidos

Este projeto é um Sistema de Gestão de Pedidos (Order Management System) desenvolvido com **C# (.NET 7)** para o backend e **React + TailwindCSS** para o frontend. O sistema permite criar, listar e visualizar pedidos, e comunica-se com o **Azure Service Bus** para simular um processamento assíncrono de pedidos.

## Tecnologias Utilizadas

- **Backend**: C# (.NET 7 ou superior), Entity Framework, PostgreSQL
- **Frontend**: React, TailwindCSS
- **Mensageria**: Azure Service Bus
- **Infraestrutura**: Docker (opcional)

## Requisitos

### 1️⃣ Backend (API em C#)

A API possui os seguintes endpoints:

- `POST /orders`: Criar um pedido
- `GET /orders`: Listar todos os pedidos
- `GET /orders/{id}`: Obter detalhes de um pedido

### 2️⃣ Frontend (React + TailwindCSS)

A interface do sistema possui as seguintes funcionalidades:

- Listagem de pedidos em uma tabela responsiva.
- Formulário para criação de pedidos.
- Detalhamento de cada pedido ao clicar em um item da lista.

### 3️⃣ Mensageria (Azure Service Bus)

Ao criar um pedido, a API envia um evento para o **Azure Service Bus**, simulando um processamento assíncrono. Um worker (serviço em segundo plano) consome essas mensagens e atualiza o status do pedido para "Processando" e, após 5 segundos, para "Finalizado".

### 4️⃣ Docker (Opcional)

Para facilitar a inicialização do ambiente, você pode utilizar o **Docker**. O `docker-compose.yml` está configurado para rodar o backend e o banco de dados PostgreSQL.

---

## Funcionalidades

### Criar Pedido

Ao clicar no botão **Criar Pedido**, o sistema cria um novo pedido e envia uma mensagem para o Azure Service Bus. O pedido é armazenado no banco de dados PostgreSQL.

### Listar Pedidos

Os pedidos são exibidos em uma tabela no frontend, com informações sobre o **cliente**, **produto**, **valor** e **status**.

### Detalhes do Pedido

Ao clicar em um pedido na lista, o usuário pode visualizar mais detalhes sobre o pedido.

### Status de Pedido

O status do pedido é atualizado dinamicamente para "Pendente", "Processando" e "Finalizado" através de uma simulação assíncrona com o Azure Service Bus.

---

## Como Rodar o Projeto

### Backend

1. **Clonar o repositório**:
   ```bash
   git clone https://github.com/IagoAvila/-order-system.git
   cd order-system
