# Financial Control API

API para gerenciamento de transações financeiras desenvolvida em **.NET 9**, utilizando princípios de **Clean Architecture**, **CQRS**, persistência em **MongoDB** e mensageria assíncrona com **RabbitMQ**.


---

## Índice

- [Tecnologias utilizadas](#tecnologias-utilizadas)
- [Arquitetura](#arquitetura)
- [Funcionalidades implementadas](#funcionalidades-implementadas)
- [Fluxo de criação de uma transação](#fluxo-de-criação-de-uma-transação)
- [Pré-requisitos](#pré-requisitos)
- [Executando a infraestrutura](#executando-a-infraestrutura)
- [Configuração da aplicação](#configuração-da-aplicação)
- [Executando a API](#executando-a-api)
- [Exemplos de endpoints](#exemplos-de-endpoints)
- [Testando RabbitMQ](#testando-rabbitmq)
- [Estrutura Docker](#estrutura-docker)
- [Próximas evoluções](#próximas-evoluções)

---

## Tecnologias utilizadas

| Tecnologia | Finalidade |
|---|---|
| .NET 9 | Runtime e SDK principal |
| ASP.NET Core Web API | Exposição dos endpoints REST |
| MongoDB 7 | Persistência de dados |
| RabbitMQ 3 Management | Mensageria assíncrona / eventos |
| MediatR | Implementação de CQRS |
| FluentValidation | Validação de comandos e requisições |
| Docker | Orquestração da infraestrutura local |
| Swagger / OpenAPI | Documentação interativa da API |

---

## Arquitetura

O projeto foi desenvolvido utilizando uma arquitetura baseada em camadas, seguindo os princípios de **Clean Architecture**:

```
src
│
├── FinancialControl.Domain
│   └── Entidades e regras de negócio
│
├── FinancialControl.Application
│   ├── Commands
│   ├── Queries
│   ├── Validators
│   ├── Events
│   └── Interfaces
│
├── FinancialControl.Infrastructure
│   ├── MongoDB
│   ├── Repositories
│   ├── RabbitMQ
│   └── Configurações externas
│
├── FinancialControl.CrossCutting
│
└── FinacialControl.Api
    └── Controllers e configuração da API
```

> A separação em camadas garante baixo acoplamento entre regras de negócio, aplicação e infraestrutura, facilitando testes, manutenção e evolução do sistema.

---

## Funcionalidades implementadas

### Transações

A aplicação permite:

- [x] Criar transações
- [x] Consultar todas as transações
- [x] Consultar transação por Id
- [x] Remover transações

---

## Fluxo de criação de uma transação

Ao criar uma transação, o seguinte fluxo é executado:

```
Cliente
   |
   ▼
API REST
   |
   ▼
CreateTransactionHandler
   |
   +----------------+
   |                |
   ▼                ▼
MongoDB          RabbitMQ
                    |
                    ▼
           transaction-created
```

A transação é persistida no **MongoDB** e um evento é publicado na fila **`transaction-created`** do **RabbitMQ**.

---

## Pré-requisitos

Antes de executar o projeto, tenha instalado:

### .NET SDK

Versão necessária:

```
.NET 9 SDK
```

Verificar instalação:

```bash
dotnet --version
```

### Docker

Necessário para executar o MongoDB e o RabbitMQ.

Verificar instalação:

```bash
docker --version
```

---

## Executando a infraestrutura

Acesse a pasta do Docker:

```bash
cd docker
```

Suba os containers:

```bash
docker compose up -d
```

Verifique se os containers estão em execução:

```bash
docker ps
```

Deve apresentar os seguintes containers:

```
financialcontrol-mongodb
financialcontrol-rabbitmq
```

### MongoDB

| Parâmetro | Valor |
|---|---|
| Host | `localhost` |
| Port | `27017` |
| Database | `FinancialControlDb` |

### RabbitMQ

Painel administrativo:

```
http://localhost:15672
```

| Credencial | Valor |
|---|---|
| Usuário | `admin` |
| Senha | `admin` |

Fila utilizada:

```
transaction-created 
```

---

## Configuração da aplicação

Arquivo de configuração:

```
src/FinacialControl.Api/appsettings.json
```

Exemplo:

```json
{
  "MongoSettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "FinancialControlDb"
  },

  "RabbitMq": {
    "Host": "localhost",
    "Port": 5672,
    "Username": "admin",
    "Password": "admin",
    "QueueName": "transaction-created"
  }
}
```

---

## Executando a API

Na raiz do projeto, restaure e compile as dependências:

```bash
dotnet build
```

Execute a aplicação:

```bash
dotnet run --project src/FinacialControl.Api
```

A API ficará disponível em:

```
http://localhost:5143
```

Documentação interativa (Swagger):

```
http://localhost:5143/swagger
```

---

## Exemplos de endpoints

### Criar transação

`POST /api/transactions`

**Payload:**

```json
{
  "description": "Compra supermercado",
  "type": 1,
  "amount": 150.50,
  "date": "2026-08-06T13:00:00"
}
```

**Resposta:**

```json
{
  "id": "guid-gerado"
}
```

### Consultar transações

`GET /api/transactions`

### Consultar transação por Id

`GET /api/transactions/{id}`

### Remover transação

`DELETE /api/transactions/{id}`

---

## Testando RabbitMQ

Após criar uma transação, é possível validar a publicação do evento:

1. Acesse o painel administrativo:

   ```
   http://localhost:15672
   ```

2. Entre no menu **Queues and Streams**.

3. Abra a fila:

   ```
   transaction-created
   ```

4. Consulte a mensagem publicada.

**Exemplo de mensagem:**

```json
{
  "id": "guid",
  "description": "Compra supermercado",
  "amount": 150.50,
  "type": 1
}
```

---

## Estrutura Docker

Arquivo de orquestração:

```
docker/docker-compose.yml
```

Responsável por subir:

- MongoDB
- RabbitMQ Management

---

## Próximas evoluções

Possíveis melhorias planejadas para o projeto:

- [ ] Consumer RabbitMQ Worker
- [ ] Retry de mensagens
- [ ] Dead Letter Queue
- [ ] Autenticação JWT
- [ ] Testes de integração
- [ ] Observabilidade com logs e métricas

---

<p align="center">Desenvolvido com .NET 9, MongoDB e RabbitMQ 🚀</p>
