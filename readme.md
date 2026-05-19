# 📨 MessageResponseCM — Sistema de Notificações Assíncronas

Sistema de notificações por e-mail construído com arquitetura orientada a eventos, utilizando **RabbitMQ**, **MassTransit**, **Worker Service** e **FluentEmail** no ecossistema .NET.

---

## 🧩 Visão Geral

O projeto simula um fluxo real de notificação assíncrona: uma API recebe uma requisição, publica um evento em uma fila do RabbitMQ via MassTransit, e um Worker Service consome essa mensagem em background e dispara um e-mail automaticamente.

```
[Cliente] → [API + FluentValidation] → [RabbitMQ] → [Worker Consumer] → [FluentEmail]
```

---

## 🏗️ Estrutura do Projeto

```
NotificationSystemCM/
├── Contracts/          # Mensagens tipadas compartilhadas entre projetos
├── Api/                # Endpoint HTTP que publica eventos na fila
├── Worker/             # Consumer em background que processa mensagens
└── docker-compose.yml  # Infraestrutura RabbitMQ via Docker
```

---

## ⚙️ Tecnologias Utilizadas

| Tecnologia | Função |
|---|---|
| **.NET 8** | Plataforma base |
| **RabbitMQ + Docker** | Message broker para comunicação assíncrona |
| **MassTransit** | Abstração sobre o RabbitMQ (publish/consume) |
| **FluentValidation** | Validação automática no pipeline do ASP.NET |
| **FluentEmail** | Envio de e-mails pelo Worker |
| **Worker Service** | Consumer rodando em background |

---

## 🚀 Como Rodar

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/)

### 1. Suba o RabbitMQ com Docker

```bash
docker-compose up -d
```

Acesse o painel de gerenciamento em: `http://localhost:15672`
- **Usuário:** `guest`
- **Senha:** `guest`

### 2. Rode a API

```bash
cd NotificationSystemCM/Api
dotnet run
```

### 3. Rode o Worker

```bash
cd NotificationSystemCM/Worker
dotnet run
```

### 4. Dispare uma notificação

```http
POST /notification
Content-Type: application/json

{
  "email": "destinatario@email.com",
  "message": "Sua mensagem aqui"
}
```

---

## 🔄 Fluxo da Aplicação

```
1. Cliente envia POST para a API
2. FluentValidation valida o payload automaticamente no pipeline
3. API publica o evento na fila do RabbitMQ via MassTransit
4. Worker (rodando em background) consome a mensagem da fila
5. FluentEmail dispara o e-mail para o destinatário
```

---

## 📦 Contratos Compartilhados

O projeto utiliza uma camada de **Contracts** com mensagens fortemente tipadas, garantindo consistência entre a API (publisher) e o Worker (consumer) sem acoplamento direto entre os projetos.

---

## 💡 Conceitos Praticados

- Arquitetura orientada a eventos (Event-Driven Architecture)
- Comunicação assíncrona com message broker
- Separação de responsabilidades entre projetos
- Validação automática via pipeline behavior
- Consumer em background com Worker Service
- Infraestrutura como código com Docker Compose

---

## 👨‍💻 Autor

**Claudio Matheus**

[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/claudio-matheus-814420278/)
[![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/ClaudioMatheusDev)
