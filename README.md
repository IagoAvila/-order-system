
# Order Management System

Este é um sistema simples de gestão de pedidos (Order Management System), onde é possível criar, listar e visualizar pedidos. Ao criar um pedido, uma mensagem é enviada para o Azure Service Bus, simulando um processamento assíncrono.

## Tecnologias Utilizadas

- **Backend**: C# (.NET 7 ou superior), Entity Framework, PostgreSQL
- **Frontend**: React, TailwindCSS
- **Mensageria**: Azure Service Bus

## Funcionalidades

- **Backend**:
  - Criar, listar e visualizar pedidos via API REST.
  - Cada pedido possui: Id (Guid), Cliente, Produto, Valor, Status e Data de Criação.
  - Envia evento para o Azure Service Bus quando um pedido é criado.
  - Worker (background service) que consome as mensagens do Azure Service Bus, alterando o status do pedido para "Processando" e, após 5 segundos, para "Finalizado".

- **Frontend**:
  - Lista de pedidos em uma tabela responsiva.
  - Formulário para criação de pedidos.
  - Visualização de detalhes do pedido ao clicar nele.

## Passos para Executar o Projeto

### 1. Backend

#### 1.1 Clonar o Repositório

Clone o repositório para o seu ambiente de desenvolvimento:
```bash
git clone https://github.com/IagoAvila/-order-system.git
cd order-system
```

#### 1.2 Configurar o Banco de Dados PostgreSQL

Certifique-se de que o **PostgreSQL** está instalado e rodando na sua máquina ou em um serviço de nuvem.

No arquivo `appsettings.json`, atualize as configurações de conexão com o seu banco de dados PostgreSQL, caso necessário. Um exemplo de configuração seria:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Username=postgres;Password=password;Database=OrderManagementDb"
  }
}
```

#### 1.3 Aplicar as Migrações do Entity Framework

Se for a primeira vez que você está rodando o backend, execute as migrações para criar o banco de dados:
```bash
dotnet ef database update
```

#### 1.4 Rodar o Backend

Após configurar o banco de dados, rode o projeto com o comando:
```bash
dotnet run
```
O backend estará disponível em `http://localhost:5000`.

### 2. Frontend

#### 2.1 Clonar o Repositório do Frontend

Acesse a pasta do frontend do repositório clonado:
```bash
cd frontend
```

#### 2.2 Instalar as Dependências

Instale as dependências do projeto com o npm:
```bash
npm install
```

#### 2.3 Rodar o Frontend

Execute o frontend no modo de desenvolvimento:
```bash
npm run dev
```

O **frontend** estará disponível em `http://localhost:3000`.

### 3. Estrutura do Projeto

#### 3.1 Backend

- **Controllers**: Implementação da API REST para gerenciamento de pedidos.
- **Models**: Estrutura do pedido, incluindo os atributos necessários.
- **Services**: Lógica de negócios, incluindo o envio de mensagens para o Azure Service Bus.
- **Workers**: Worker para consumir as mensagens do Azure Service Bus e atualizar o status do pedido.

#### 3.2 Frontend

- **Pages**: Contém as páginas principais, como a tela de pedidos.
- **Components**: Componentes reutilizáveis, como botões e formulários.
- **Services**: Funções que lidam com a comunicação com a API do backend.

