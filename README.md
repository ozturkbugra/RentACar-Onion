# 🚗 RentACar App - Backend API

This project is a comprehensive **Car Rental System Backend** built with **.NET 8**. It implements **Onion Architecture** and **CQRS** pattern to ensure high scalability, maintainability, and clean code standards.

## 🚀 Tech Stack & Patterns

The project utilizes modern software development technologies and patterns:

* **Framework:** .NET 8 Core Web API
* **Architecture:** Onion Architecture (Clean Architecture)
* **Design Patterns:** CQRS (Command Query Responsibility Segregation), Mediator Pattern, Generic Repository Pattern
* **Libraries:**
    * **MediatR:** For handling command and query requests.
    * **FluentValidation:** For server-side validation pipeline.
    * **AutoMapper:** For object-object mapping.
    * **Entity Framework Core:** ORM for SQL Server (Code First).
    * **SignalR:** For real-time server-client communication.
* **Security:** JWT (JSON Web Token) Authentication.

---

## 🏗️ Project Architecture

The solution is structured into layers to enforce separation of concerns:

1.  **Core (Domain):** Contains Entities and Enums. No external dependencies.
2.  **Application:** Contains Business Logic, Interfaces, CQRS Handlers (Commands/Queries), DTOs, and Validators.
3.  **Infrastructure (Persistence):** Contains DbContext, Migrations, Repository Implementations, and Database Configurations.
4.  **Presentation (WebApi):** API Controllers and Endpoints.

---

## ✨ Key Features & Refactoring

* **Service Registration Pattern:** Dependency Injection logic is decoupled from `Program.cs`. Each layer (Application & Persistence) manages its own service registration via Extension Methods.
* **Pipeline Behavior:** Validation is handled automatically via MediatR Pipeline Behavior before reaching the business logic.
* **Global Exception Handling:** Custom middleware to handle runtime errors gracefully.
* **Clean Program.cs:** Database connection strings and service configurations are organized for better readability.

---

## ⚙️ How to Run

1.  **Clone the repository**
    ```bash
    git clone [https://github.com/YOUR-USERNAME/RentACarApp.git](https://github.com/YOUR-USERNAME/RentACarApp.git)
    ```

2.  **Configure Database**
    Open `appsettings.json` in the WebApi layer and update the Connection String if necessary:
    ```json
    "ConnectionStrings": {
      "RentACarContext": "Server=YOUR_SERVER;Database=RentACarDb;Trusted_Connection=True;TrustServerCertificate=True;"
    }
    ```

3.  **Apply Migrations**
    Open Package Manager Console (PMC) and run:
    ```bash
    update-database
    ```

4.  **Run the Project**
    Set **RentACarApp.WebApi** as the startup project and run!

---

## 👨‍💻 Author

**Buğra Öztürk**
* .NET Developer
