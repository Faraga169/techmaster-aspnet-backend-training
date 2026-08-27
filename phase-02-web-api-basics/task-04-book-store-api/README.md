# 📚 Book Store API

A RESTful Web API built with **ASP.NET Core** as part of the **TechMaster ASP.NET Backend Career Training — Phase 02: Web API Basics**.

The project provides a backend system for managing **books, authors, and categories**, with support for CRUD operations, filtering, pagination, stock reporting, DTOs, service-layer architecture, validation, and centralized exception handling.

---

## 🎯 Project Overview

The **Book Store API** is designed to practice and demonstrate core ASP.NET Core Web API concepts through a realistic bookstore management system.

The application separates responsibilities between:

* Controllers
* Services
* DTOs
* Models
* Seeded data
* Custom exceptions
* Exception-handling middleware

The project currently uses **in-memory seeded collections** instead of a database.

---

## ✨ Features

### 📚 Books

* Get all books
* Get a book by ID
* Create a new book
* Update an existing book
* Delete a book
* Filter books by:

  * Title
  * Category
  * Author
  * Availability
* Pagination
* Stock summary report

### ✍️ Authors

* Get all authors
* Create an author
* Delete an author

### 🏷️ Categories

* Get all categories
* Create a category
* Delete a category

### 🛡️ Validation & Error Handling

* Required field validation
* Positive price validation
* Positive stock quantity validation
* Category existence validation
* Author existence validation
* Duplicate book title validation
* Duplicate ISBN validation
* Inactive category validation
* Invalid pagination validation
* Custom business exceptions
* Centralized exception handling middleware

---

## 🛠️ Technologies

* **C#**
* **ASP.NET Core Web API**
* **.NET**
* **LINQ**
* **Dependency Injection**
* **DTOs**
* **Swagger / OpenAPI**
* **In-Memory Collections**

---

## 🏗️ Architecture

The project follows a simple layered structure:

```text
Client
   │
   ▼
Controller Layer
   │
   ▼
Service Layer
   │
   ▼
Seeded In-Memory Data
```

### Controller Layer

Responsible for:

* Receiving HTTP requests
* Calling the appropriate service
* Returning HTTP responses
* Mapping API routes to application operations

### Service Layer

Contains the business logic for:

* Books
* Authors
* Categories
* Filtering
* Pagination
* Validation
* Stock reporting

Services are accessed through interfaces such as:

```text
IBookService
IAuthorService
ICategoryService
```

This keeps the controllers independent from the concrete service implementations.

### DTO Layer

DTOs are used to define the data exchanged through the API.

Examples include:

```text
BookResponse
CreateBookRequest
UpdateBookRequest
AuthorResponse
CreateAuthorRequest
CategoryResponse
CreateCategoryRequest
StockReportResponse
```

### Exception Handling

Business errors are represented using custom exceptions and handled centrally through:

```text
ExceptionHandlingMiddleware
```

---

## 📂 Project Structure

```text
Book Store API/
│
├── Controllers/
│   ├── AuthorsController.cs
│   ├── BooksController.cs
│   └── CategoriesController.cs
│
├── DTOS/
│   ├── AuthorResponse.cs
│   ├── BookResponse.cs
│   ├── CategoryResponse.cs
│   ├── CreateAuthorRequest.cs
│   ├── CreateBookRequest.cs
│   ├── CreateCategoryRequest.cs
│   ├── UpdateBookRequest.cs
│   ├── StockReportResponse.cs
│   ├── booksperAuthorResponse.cs
│   └── booksperCategoryResponse.cs
│
├── Exceptions/
│   └── BusinessException.cs
│
├── Middleware/
│   └── ExceptionHandlingMiddleware.cs
│
├── Models/
│   ├── Author.cs
│   ├── Book.cs
│   └── Category.cs
│
├── Seeding/
│   └── BookSeeding.cs
│
├── Services/
│   ├── AuthorService.cs
│   ├── BookService.cs
│   ├── CategoryService.cs
│   ├── IAuthorService.cs
│   ├── IBookService.cs
│   └── ICategoryService.cs
│
├── Program.cs
├── appsettings.json
└── Book Store API.csproj
```

---

# 🔌 API Endpoints

## 📚 Books

Base route:

```http
/api/Books
```

### Get All Books

```http
GET /api/Books
```

Optional query parameters:

| Parameter      | Description              | Default |
| -------------- | ------------------------ | ------: |
| `Title`        | Filter by title          |       — |
| `category`     | Filter by category name  |       — |
| `author`       | Filter by author name    |       — |
| `availability` | Filter by availability   |  `true` |
| `pagesize`     | Number of books per page |     `5` |
| `pagenumber`   | Requested page number    |     `1` |

Example:

```http
GET /api/Books?Title=Clean&availability=true&pagesize=5&pagenumber=1
```

Example with category and author:

```http
GET /api/Books?category=Programming&author=Robert%20Martin
```

The service applies the filters first, calculates the number of pages, and then applies pagination using `Skip` and `Take`.

---

### Get Book by ID

```http
GET /api/Books/{id}
```

Example:

```http
GET /api/Books/1
```

Returns the requested book including:

* ID
* ISBN
* Title
* Price
* Stock quantity
* Published year
* Availability
* Category name
* Author name

---

### Create Book

```http
POST /api/Books
```

Example request:

```json
{
  "isbn": "9780132350884",
  "title": "Clean Code",
  "price": 45.99,
  "stockQuantity": 10,
  "publishedYear": 2008,
  "isAvailable": true,
  "authorId": 1,
  "categoryId": 1
}
```

The service validates:

* Title
* ISBN
* Price
* Stock quantity
* Author
* Category
* Category status
* Duplicate title
* Duplicate ISBN

A successful creation returns:

```http
201 Created
```

---

### Update Book

```http
PUT /api/Books/{id}
```

Example:

```http
PUT /api/Books/1
```

The same major business validations used during creation are applied during update.

---

### Delete Book

```http
DELETE /api/Books/{id}
```

Example:

```http
DELETE /api/Books/1
```

Successful deletion returns:

```http
204 No Content
```

---

### Stock Report

```http
GET /api/Books/reports/summary
```

Returns a stock-related summary generated by the book service.

---

# ✍️ Authors API

Base route:

```http
/api/Authors
```

### Get All Authors

```http
GET /api/Authors
```

### Create Author

```http
POST /api/Authors
```

Example:

```json
{
  "fullName": "Robert C. Martin"
}
```

### Delete Author

```http
DELETE /api/Authors/{id}
```

Example:

```http
DELETE /api/Authors/1
```

Successful deletion returns:

```http
204 No Content
```

---

# 🏷️ Categories API

Base route:

```http
/api/Categories
```

### Get All Categories

```http
GET /api/Categories
```

### Create Category

```http
POST /api/Categories
```

Example:

```json
{
  "name": "Programming"
}
```

### Delete Category

```http
DELETE /api/Categories/{id}
```

Example:

```http
DELETE /api/Categories/1
```

---

# 🔎 Filtering

The Books endpoint supports multiple filters.

### Filter by Title

```http
GET /api/Books?Title=Clean
```

Title matching is case-insensitive.

### Filter by Category

```http
GET /api/Books?category=Programming
```

The API resolves the category name to its ID before filtering books.

### Filter by Author

```http
GET /api/Books?author=Robert%20C.%20Martin
```

The API resolves the author name to its ID before filtering.

### Filter by Availability

```http
GET /api/Books?availability=true
```

Availability defaults to:

```text
true
```

---

# 📄 Pagination

Pagination is supported through:

```text
pagesize
pagenumber
```

Example:

```http
GET /api/Books?pagesize=5&pagenumber=2
```

The service validates pagination parameters:

* `pagesize` must be greater than `0`
* `pagenumber` must be greater than `0`
* `pagenumber` cannot exceed the available pages

---

# ⚠️ Error Handling

The application uses a custom `BusinessException` together with centralized exception-handling middleware.

Examples of handled business errors include:

| Situation                | Status |
| ------------------------ | -----: |
| Book not found           |  `404` |
| Author not found         |  `404` |
| Category not found       |  `404` |
| Invalid page size        |  `400` |
| Invalid page number      |  `400` |
| Page exceeds total pages |  `400` |
| Missing title            |  `400` |
| Missing ISBN             |  `400` |
| Negative price           |  `400` |
| Negative stock quantity  |  `400` |
| Duplicate book title     |  `400` |
| Duplicate ISBN           |  `400` |
| Inactive category        |  `404` |

This keeps error handling centralized instead of duplicating `try/catch` logic inside every controller.

---

# 💉 Dependency Injection

The application registers its services using ASP.NET Core's built-in dependency injection container.

```csharp
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBookService, BookService>();
```

Controllers depend on service interfaces rather than concrete implementations.

Example:

```csharp
public class BooksController(IBookService bookService)
```

This improves separation of concerns and makes the application easier to maintain and test.

---

# 📦 Data Storage

The current version does **not** use a database.

Data is stored in static in-memory collections provided through:

```text
BookSeeding
```

The seeded data contains:

* Books
* Authors
* Categories

Any data created or updated while the application is running is stored only in memory and will be lost when the application restarts.

---

# 📖 Swagger / OpenAPI

Swagger is configured through ASP.NET Core:

```csharp
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
```

Swagger UI is enabled in the development environment.

After running the application, open the Swagger URL provided by ASP.NET Core to explore and test the API interactively.

---

# ▶️ Getting Started

## Prerequisites

Make sure you have:

* .NET SDK installed
* Git installed
* An IDE such as Visual Studio or VS Code

## Clone the Repository

```bash
git clone https://github.com/Faraga169/techmaster-aspnet-backend-training.git
```

Navigate to the project:

```bash
cd techmaster-aspnet-backend-training/phase-02-web-api-basics/task-04-book-store-api/Book\ Store\ API
```

On Windows PowerShell:

```powershell
cd "phase-02-web-api-basics/task-04-book-store-api/Book Store API"
```

## Restore Dependencies

```bash
dotnet restore
```

## Run the Application

```bash
dotnet run
```

The application will start using the configured ASP.NET Core development settings.

---

# 🧪 Testing the API

You can test the API using:

* Swagger UI
* Postman
* `.http` request file included in the project

The project contains:

```text
Book Store API.http
```

which can be used to send HTTP requests directly from supported IDEs.

---

# 🎓 Learning Objectives

This project was developed to practice the following ASP.NET Core Web API concepts:

* RESTful API design
* HTTP methods
* Routing
* Controller-based APIs
* Dependency Injection
* Service Layer
* Interfaces
* DTOs
* LINQ
* Filtering
* Pagination
* CRUD operations
* HTTP status codes
* Custom exceptions
* Middleware
* Swagger / OpenAPI
* In-memory data seeding
* Business validation
* Separation of concerns

---

# 🚧 Future Improvements

Possible improvements for future phases include:

* Replace in-memory storage with SQL Server
* Add Entity Framework Core
* Introduce Repository Pattern
* Add authentication and authorization
* Add JWT authentication
* Add automated unit tests
* Add integration tests
* Improve API documentation
* Add sorting capabilities
* Add advanced search
* Add database migrations

---

## 👨‍💻 Author

**Ahmed Farag Fekry Dahy**

ASP.NET Backend Career Training
TechMaster — Phase 02: Web API Basics

---

## 📌 Training Repository

This project is part of the **TechMaster ASP.NET Backend Career Training** repository.

The repository contains multiple phases covering backend development concepts with ASP.NET and .NET.

---

⭐ Built as part of my backend development training journey.
