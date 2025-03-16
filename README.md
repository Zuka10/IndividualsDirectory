# IndividualsDirectory

## Project Overview

`IndividualsDirectory` is a web API built with ASP.NET Core 8.0 that allows users to manage a directory of individuals. It follows modern software architecture patterns including Clean Architecture, CQRS, and utilizes various tools like MediatR for handling commands and queries, AutoMapper for object mapping, and Moq for unit testing. The application uses the Repository pattern and UnitOfWork pattern to handle data access, ensuring a clean and maintainable codebase.

### Features
- **Clean Architecture**: The project follows Clean Architecture principles for separation of concerns and maintainability.
- **CQRS**: Command Query Responsibility Segregation (CQRS) for separating the read and write operations.
- **MediatR**: A simple in-process messaging system for decoupling application logic.
- **AutoMapper**: Automatic object-to-object mapping for smoother transformation between layers.
- **Unit Testing**: Using xUnit and Moq for unit tests to ensure quality code.
- **Repository & UnitOfWork Pattern**: For handling data access in a clean and abstracted way.

## Technologies

- **ASP.NET Core 8.0**: The backend framework for building the API.
- **CQRS**: Command-Query Responsibility Segregation for separating read and write logic.
- **MediatR**: A library for sending messages and handling them in a decoupled manner.
- **AutoMapper**: A library for object-to-object mapping.
- **xUnit**: A unit testing framework for .NET.
- **Moq**: A mocking framework for unit tests.
- **Entity Framework Core**: ORM for working with the database.

## Getting Started

### Prerequisites

- .NET 8.0 SDK or higher
- Visual Studio 2022 or higher (or any compatible IDE)
- SQL Server or a compatible database for the application

### Setup Instructions

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/yourusername/IndividualsDirectory.git
