# 🔀 API Gateway - Microservices Gateway using Ocelot

This project is an API Gateway built with **Ocelot** and **.NET 8** to route and secure traffic between microservices in a distributed architecture.

The gateway acts as a single entry point to multiple backend services like **Order**, **Payment**, and **Account**, enabling:

- Centralized routing
- Token validation (Authentication & Authorization)
- Load balancing
- Path rewriting
- Middleware-based extensibility

---

## 🚀 Features

- 🔁 **Routing** to Order, Payment, and Account APIs
- 🔐 **Authentication/Authorization** support via JWT (configurable)
- 🌍 **Base URL proxying** for simplified frontend/backend interaction
- 📂 **Custom endpoint mapping** using `ocelot.json`
- ♻️ **Extensible** pipeline for future middleware (caching, throttling, etc.)

---

## 🧱 Tech Stack

- ✅ .NET 8
- ✅ Ocelot API Gateway
- ✅ JSON-based routing configuration
- ✅ Supports integration with Identity Server, Auth0, or custom token issuer

---

## 🧭 Route Examples

| Service       | Gateway Route                          | Downstream Route                     |
|---------------|----------------------------------------|--------------------------------------|
| **Order API** | `GET /gateway/order/GetAll`            | `GET /api/Order/GetAll`              |
|               | `GET /gateway/order/{id}`              | `GET /api/Order/{id}`                |
| **Payment API**| `POST /gateway/payment`               | `POST /api/Payment`                  |
| **Account API**| `POST /gateway/account/register`      | `POST /api/Account/register`         |

---

## ⚙️ Configuration

All routing is defined inside the `ocelot.json` file. Example:

```json
{
  "DownstreamPathTemplate": "/api/Order/{everything}",
  "UpstreamPathTemplate": "/gateway/order/{everything}",
  "DownstreamHostAndPorts": [{ "Host": "localhost", "Port": 5283 }],
  "DownstreamScheme": "http",
  "UpstreamHttpMethod": [ "GET", "POST", "PUT", "DELETE" ]
}
