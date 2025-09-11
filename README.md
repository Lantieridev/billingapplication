# Billing Application

A console-based billing application developed in C# as a university assignment project.

## Overview

This is a console application that manages billing operations using the Repository design pattern. The application demonstrates good software architecture practices by separating data access logic from business rules.

## Features

- **Customer Management**: Add, view, and manage customer information
- **Product Management**: Maintain product catalog with prices and details
- **Invoice Generation**: Create and manage billing invoices
- **Data Persistence**: Store and retrieve data using the Repository pattern
- **Console Interface**: User-friendly text-based interface

## Architecture

The application follows the **Repository Pattern** to separate the data access layer from the business logic layer:

- **Repository Layer**: Handles all data operations (CRUD)
- **Service Layer**: Contains business logic and application rules
- **Presentation Layer**: Console-based user interface

## Design Patterns Used

- **Repository Pattern**: For data access abstraction
- **Singleton Pattern**: For managing application state

## Project Structure

```
BillingApplication/
├── Models/           # Entity classes (Customer, Product, Invoice, etc.)
├── Repositories/     # Repository interfaces and implementations
├── Services/        # Business logic services
├── Interfaces/      # Interface definitions
└── Program.cs       # Application entry point
```

## Technologies

- **Language**: C#
- **Framework**: .NET (version specified in project file)
- **Pattern**: Repository Design Pattern
- **Storage**: In-memory data storage (can be extended to database)

## Getting Started

### Prerequisites

- .NET SDK (version specified in project file)
- Visual Studio or any C# compatible IDE

### Installation

1. Clone the repository:
```bash
git clone <https://github.com/Lantieridev/billingapplication/>
```

2. Navigate to the project directory:
```bash
cd BillingApplication
```

3. Restore dependencies:
```bash
dotnet restore
```

4. Build the project:
```bash
dotnet build
```

5. Run the application:
```bash
dotnet run
```

## Academic Purpose

This project was developed as part of a university assignment to demonstrate:
- Understanding of design patterns, specifically Repository pattern
- Object-Oriented Programming principles in C#
- Separation of concerns in application architecture
- Clean code practices and proper project organization

## Contributing

This is an academic project. For educational purposes only.

## License

This project is created for academic purposes and is not intended for commercial use.

## Author

Lantieri - Tecnicatura en Programación

## Helper

Franco Gomez - Ingeniería en Sistemas
