# ASP.NET Core WebApi - Clean Architecture
<br />
<p align="center">
  <a href="#">
    <img src="docs/OnionArchitecture.png" alt="Logo" width="20%" height="20%">
  </a>

  <h3 align="center">Clean Architecture</h3>

  <p align="center">
    ASP.NET Core Web Api built using essential features as a Bank application!
  </p>
</p>

## About The Project
This project has been retired and is no longer maintained. 
It was built as a learning project end of 2022 to understand the concepts of Clean Architecture together with Dapper as ORM and MediatR as CQRS library.
The intended purpose was to build a simple bank application, where you can create accounts, deposit and withdraw money, and transfer money between accounts.

Nothing in the project is production ready, and it is not intended to be used as such.
Be free to use the code as you wish, but be aware that it is not maintained and will not be updated.

The database calls are made using Stored Procedures, which are found in the root directory of the project.
*Creation of database and tables are not included in the project, therefor no seedData*
After requests I have added instructions on how to run the project.

## How to run the project
**With Docker:**
This will create a container with the application and a container with a SQL Server database.
Make sure that you have Docker installed on your machine & running.
1. Clone the repository
2. In root directory run `docker compose up`

**Without Docker:**
1. Clone the repository
2. In root directory run `dotnet restore`
3. In root directory run `dotnet build`
4. In root directory run `dotnet run --project BankApplication.Presentation/BankApplication.WebApi `


### Technologies & Features

- [x] ASP.NET Core 7 WebApi
- [x] REST Standards
- [x] Onion Architecture
- [x] CQRS with MediatR Library
- [x] Dapper
- [x] StoredProcedures SQL
- [x] Repository Pattern - Generic
- [x] Global Error Handling - RFC
- [x] Options Pattern
- [x] MediatR Pipeline Logging & Validation
- [x] Swagger UI
- [x] JWT Authentication 
- [x] Role based Authorization
- [x] Custom Exception Handling Middlewares
- [x] API Versioning
- [x] Mapster

