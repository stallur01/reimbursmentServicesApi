# Reimbursment Services API

This is the backend service for the Reimbursement Portal application.  
It is built with **ASP.NET Core Web API** and connects to **MongoDB Atlas** to store reimbursement records, including file uploads (receipts).

The API accepts form submissions from the Angular frontend and stores:
- Purchase Date
- Amount
- Description
- Receipt (file upload)

Uploaded files are served via static file hosting in .NET.

---

## 📦 Tech Stack

- ASP.NET Core Web API (.NET 7 / 8)
- MongoDB Atlas (Cloud Database)
- CORS enabled for Angular frontend
- Swagger (OpenAPI documentation)

---

## 🚀 Setup & Run Locally

### 1. Clone the repository

```bash
git clone https://github.com/your-username/reimbursmentServicesApi.git
cd reimbursmentServicesApi

dotnet clean
dotnet build
dotnet run

