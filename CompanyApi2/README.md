# CompanyApi

## Description

This project is a simple example of using Entity Framework Core (EF Core) with an ASP.NET Core Web API.

## Features

- ASP.NET Core Web API
- Entity Framework Core for database access
- .NET 8 compatibility
- CRUD for all entities
- Raw SQL
- Did not have transaction yet

## Prerequisites

- .NET 8 SDK installed
- A database provider: SQl Server
- SQL Server Management Studio (SSMS) or any other database management tool
- Visual Studio or any IDE supporting .NET development

## Getting Started

### Clone the Repository

Clone this Repository:

```bash
git clone https://github.com/dhminh01/CompanyApi2.git
cd CompanyApi2
```

### Setup the Database

1. Config the `appsettings.json` file with your database connection string. Here is an example:

```json
   "ConnectionStrings": {
      "DefaultConnection": "Server={local};Database=database_name;User Id=your_username;Password=your_password;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
   }
```

2. Run the following command to apply migrations and create the database:

```bash
dotnet build
dotnet ef migration InitialCreate
dotnet ef database update
```

### Review the Database

1. Open SQL Server Management Studio (SSMS). If not installed, you can download it from [here](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms).
2. Config and connect to your own server.
3. Choose the database.

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- .NET 8
