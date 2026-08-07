# Financial Control API

API desenvolvida como solução para o desafio técnico de controle financeiro.

O projeto foi construído utilizando **.NET 9**, seguindo princípios de **Clean Architecture**, **CQRS**, **Repository Pattern**, **Dependency Injection** e **SOLID**, com persistência em **MongoDB** e documentação automática através do **Swagger**.

---

# Objetivo

Disponibilizar uma API REST para gerenciamento de transações financeiras, permitindo:

- Cadastro de transações
- Consulta de todas as transações
- Consulta por identificador
- Atualização de transações
- Exclusão de transações

---

# Arquitetura

A solução foi organizada em camadas para garantir baixo acoplamento e alta coesão.

```
                +----------------------+
                |      Swagger         |
                +----------+-----------+
                           |
                           v
                +----------------------+
                |  ASP.NET Core API    |
                +----------+-----------+
                           |
                           v
                +----------------------+
                |   Application Layer  |
                |   CQRS + MediatR     |
                +----------+-----------+
                           |
                           v
                +----------------------+
                |     Domain Layer     |
                | Entities + Contracts |
                +----------+-----------+
                           |
                           v
                +----------------------+
                | Infrastructure Layer |
                | MongoDB Repository   |
                +----------+-----------+
                           |
                           v
                     MongoDB Database
```

---

# Tecnologias Utilizadas

- .NET 9
- ASP.NET Core Web API
- MongoDB
- MongoDB.Driver
- MediatR
- FluentValidation
- Docker
- RabbitMQ
- Swagger / OpenAPI
- xUnit
- FluentAssertions

---

# Padrões Utilizados

- Clean Architecture
- CQRS (Command Query Responsibility Segregation)
- Repository Pattern
- Dependency Injection
- SOLID
- Validation Pattern
- Domain Driven Design (conceitos)

---

# Estrutura da Solução

```
FinancialControl
│
├── docker
│   └── docker-compose.yml
│
├── src
│   ├── FinancialControl.Domain
│   ├── FinancialControl.Application
│   ├── FinancialControl.Infrastructure
│   ├── FinancialControl.CrossCutting
│   └── FinacialControl.Api
│
└── testes
    └── FinancialControl.UnitTests
```

---

# Pré-requisitos

Antes de executar a aplicação é necessário possuir instalado:

- .NET SDK 9
- Git
- Docker
- Docker Compose
- MongoDB (caso não utilize Docker)
- RabbitMQ (caso não utilize Docker)

> **Observação:** durante o desenvolvimento deste projeto o MongoDB e o RabbitMQ foram executados via Docker.

---

# Executando o Projeto

## 1. Clonar o repositório

```bash
git clone <url-do-repositorio>
```

---

## 2. Entrar na pasta

```bash
cd FinancialControl
```

---

## 3. Subir os containers

```bash
docker compose up -d
```

Serão iniciados:

- MongoDB
- RabbitMQ

---

## 4. Restaurar os pacotes

```bash
dotnet restore
```

---

## 5. Compilar

```bash
dotnet build
```

---

## 6. Executar a API

```bash
cd src/FinacialControl.Api

dotnet run
```

---

## 7. Abrir o Swagger

```
https://localhost:xxxx/swagger
```

ou

```
http://localhost:xxxx/swagger
```

A porta poderá variar conforme o `launchSettings.json`.

---

# Banco de Dados

O projeto utiliza MongoDB.

Database:

```
FinancialControlDb
```

Collection:

```
transactions
```

---

# RabbitMQ

O RabbitMQ já está preparado via Docker para futuras implementações envolvendo mensageria e processamento assíncrono.

Interface Web:

```
http://localhost:15672
```

Usuário padrão:

```
guest
```

Senha:

```
guest
```

---

# Endpoints

## Criar Transação

```
POST /api/transactions
```

Exemplo:

```json
{
  "description": "Compra supermercado",
  "type": 1,
  "amount": 150.50,
  "date": "2026-08-06T13:00:00Z"
}
```

Resposta:

```
201 Created
```

---

## Listar Todas

```
GET /api/transactions
```

Resposta:

```
200 OK
```

---

## Buscar por Id

```
GET /api/transactions/{id}
```

Resposta:

```
200 OK
```

ou

```
404 Not Found
```

---

## Atualizar

```
PUT /api/transactions/{id}
```

Resposta:

```
204 No Content
```

---

## Excluir

```
DELETE /api/transactions/{id}
```

Resposta:

```
204 No Content
```

---

# Fluxo CQRS

### Escrita

```
Controller

↓

Command

↓

Validator

↓

Handler

↓

Repository

↓

MongoDB
```

### Leitura

```
Controller

↓

Query

↓

Handler

↓

Repository

↓

MongoDB
```

---

# Testes

O projeto possui testes unitários utilizando:

- xUnit
- FluentAssertions

Execução:

```bash
dotnet test
```

---

# Funcionalidades Implementadas

- ✔ Cadastro de transações
- ✔ Consulta de todas as transações
- ✔ Consulta por Id
- ✔ Atualização
- ✔ Exclusão
- ✔ Validações com FluentValidation
- ✔ Persistência em MongoDB
- ✔ Swagger
- ✔ Docker
- ✔ RabbitMQ
- ✔ CQRS
- ✔ MediatR
- ✔ Repository Pattern
- ✔ Dependency Injection
- ✔ Testes Unitários

---

# Melhorias Futuras

Algumas funcionalidades que podem ser incorporadas futuramente:

- Autenticação JWT
- Autorização baseada em Roles
- Health Checks
- Paginação
- Ordenação
- Filtros por período
- Filtros por tipo de transação
- Cache
- Logging estruturado
- Observabilidade
- Versionamento da API
- Testes de integração
- Pipeline CI/CD
- Publicação em ambiente Cloud

---

# Autor

Desenvolvido como solução para o desafio técnico **Financial Control API**, utilizando boas práticas de desenvolvimento, arquitetura em camadas e princípios de engenharia de software.