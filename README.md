# IT Asset Manager

A Windows desktop application built with **C# (.NET 10)** and **Windows Forms** for managing IT assets, employees, and assignments within an organization.

---

## 📋 Table of Contents

- [About the Project](#about-the-project)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [Database Setup](#database-setup)
- [Usage](#usage)
- [Team Members](#team-members)

---

## About the Project

IT Asset Manager is a semester project that provides a centralized system for tracking IT hardware assets (laptops, monitors, peripherals, etc.), managing employee records, and recording asset assignments. It includes a real-time dashboard that summarizes the current state of all assets.

---

## Features

- **Dashboard** — Live summary of total assets, available assets, assigned assets, assets under repair, total employees, and active assignments.
- **Asset Management** — Add, edit, view, and delete IT assets with details such as brand, model, serial number, purchase date, category, status, and notes.
- **Employee Management** — Maintain employee records including name, department, contact number, email, and active status.
- **Assignment Tracking** — Assign assets to employees and track all active assignments.
- **Category Management** — Organize assets into categories for easier filtering and reporting.

---

## Tech Stack

| Layer | Technology |
|---|---|
| Language | C# |
| Framework | .NET 10 |
| UI | Windows Forms (WinForms) |
| Database | SQL Server (via ADO.NET) |
| IDE | Visual Studio 2022 |

---

## Project Structure

```
ITAssetManager/
├── App.Core/                  # Business logic layer
│   ├── Models/                # Data models (Asset, Employee, Assignment, Category, DashboardStats)
│   ├── Interfaces/            # Service interfaces (IAssetService, IEmployeeService, IAssignmentService)
│   └── Services/              # Service implementations (AssetService, EmployeeService, AssignmentService, CategoryService)
│
└── App.WindowsApp/            # Presentation layer (WinForms)
    ├── Forms/                 # UI Forms
    │   ├── MainForm            # Main navigation shell
    │   ├── DashboardView       # Summary dashboard
    │   ├── AssetForm           # Asset list & management
    │   ├── EmployeeForm        # Employee list & management
    │   ├── AssignmentForm      # Assignment list & management
    │   └── CategoryForm        # Category management
    └── Program.cs             # Application entry point
```

---

## Getting Started

### Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/) with the **.NET Desktop Development** workload
- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download)
- SQL Server (Express or higher) or SQL Server LocalDB

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/YOUR_USERNAME/ITAssetManager.git
   ```

2. **Open the solution** in Visual Studio:
   ```
   ITAssetManager/ITAssetManager.slnx
   ```

3. **Restore NuGet packages** (Visual Studio does this automatically on build).

4. **Set up the database** — see [Database Setup](#database-setup) below.

5. **Update the connection string** in `App.WindowsApp/App.config`:
   ```xml
   <connectionStrings>
     <add name="DefaultConnection"
          connectionString="Server=YOUR_SERVER;Database=ITAssetManager;Trusted_Connection=True;"
          providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```

6. **Build and run** the project (`F5` or `Ctrl+F5`).

---

## Database Setup

Run the following SQL script in SQL Server Management Studio (SSMS) or Azure Data Studio to create the required tables:

```sql
CREATE DATABASE ITAssetManager;
GO

USE ITAssetManager;
GO

CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY,
    CategoryName NVARCHAR(100) NOT NULL
);

CREATE TABLE Assets (
    AssetID INT PRIMARY KEY IDENTITY,
    AssetName NVARCHAR(150) NOT NULL,
    CategoryID INT REFERENCES Categories(CategoryID),
    Brand NVARCHAR(100),
    Model NVARCHAR(100),
    SerialNumber NVARCHAR(100),
    PurchaseDate DATE,
    Status NVARCHAR(50) DEFAULT 'Available',  -- Available | Assigned | Under Repair
    Notes NVARCHAR(500)
);

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY,
    FullName NVARCHAR(150) NOT NULL,
    Department NVARCHAR(100),
    ContactNumber NVARCHAR(20),
    Email NVARCHAR(150),
    IsActive BIT DEFAULT 1
);

CREATE TABLE Assignments (
    AssignmentID INT PRIMARY KEY IDENTITY,
    AssetID INT REFERENCES Assets(AssetID),
    EmployeeID INT REFERENCES Employees(EmployeeID),
    AssignedDate DATE,
    ReturnDate DATE,
    Notes NVARCHAR(500)
);
```

---

## Usage

1. Launch the application.
2. The **Dashboard** loads automatically with a live count of assets and assignments.
3. Use the navigation menu to switch between **Assets**, **Employees**, **Assignments**, and **Categories**.
4. Use the **Add / Edit / Delete** buttons within each section to manage records.

---

## Team Members

| Name | Roll Number | Role |
|---|---|---|
| Zohaib Hassan | F23BDOCS1M01156 | Group Leader |
| Nosheeb Bibi | F23BDOCS1M01200 | Developer |
| Qamar Shehzadi | F23BDOCS1M01193 | Developer |

---

## License

This project was developed as part of a university semester project.
