# 💰 Expense Tracker API

This project is a simple **RESTful API** built with **ASP.NET Core (.NET 9.0)** for tracking expenses.  
It stores details like:

- `Id` (int)  
- `Name` (string)  
- `Amount` (decimal)  
- `Date` (DateTime)

---

### 🚀 Tech Stack

- ASP.NET Core Web API (.NET 9.0)
- Entity Framework Core
- Microsoft SQL Server
- RESTful Architecture

---

## 🔐 Local Developer Setup

### 📦 Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download)
- SQL Server or SQL Server LocalDB
- Visual Studio 2022+ or any code editor

---

## ⚙️ Steps to Run the Project

### 1. **Clone the repository**

```bash
git clone https://github.com/your-username/ExpenseTrackerAPI.git
```

### 2. **Set local connection string using User Secrets**

```bash
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Your-Db-Connection-String"
```

### 3. **Database Setup**

```powershell
Add-Migration "InitialCreateWithSeed"
Update-Database
```
---

### 4. **Running the project**

```cmd
cd ExpenseTrackerAPI
dotnet run
```
---
##📫 API Endpoints

| Method | Route | Description |
|-----|-----|-----|
| GET	| /api/expenses | Get all expenses |
| GET | /api/expenses/{id} | Get a specific expense |
| POST | /api/expenses | Add a new expense |
| PUT | /api/expenses/{id} | Update an existing expense |
| DELETE | /api/expenses/{id} | Delete an expense |


---

##📄 License

This project is open source and available under the MIT License.
