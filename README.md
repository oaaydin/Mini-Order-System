# Mini Order System (Console App)

This project is a simple **product management system** developed using C# and Entity Framework Core.  
Its main purpose is to practice layered architecture, EF Core Code First approach, and basic CRUD operations.

## Technologies Used
- C#
- .NET
- Entity Framework Core
- SQL Server
- Code First
- Layered Architecture (UI / Business / DataAccess / Entities)

## Features
- Add new products
- List all products
- Find product by ID
- Update product information
- Soft delete products
- User input validation (TryParse)
- Connection string management via `appsettings.json`

## Project Structure
- **ConsoleUI**  
  Handles user input and console output.
- **Business**  
  Contains business rules and validations.
- **DataAccess**  
  Entity Framework Core, DbContext, and repository implementations.
- **Entities**  
  Database models (Product, Category, BaseEntity).

## Setup and Run
1. Make sure **SQL Server** is installed on your machine.
2. Clone the repository.
3. Check the connection string in `ConsoleUI/appsettings.json`.
4. Open **Package Manager Console** in Visual Studio.
5. Run the following command: Update-Database
6. Run the ConsoleUI project.

## Notes
- The project uses the **Code First** approach.
- Database tables are created using migrations.
- Product deletion is implemented as **soft delete**.
- Connection string is not hardcoded in the source code.

## Purpose
This project is built for educational purposes to practice  
Entity Framework Core, layered architecture, and clean application design.
