# Task 06 — API Standards & Refactor

## 📌 Overview

This task focuses on refactoring a poorly structured ASP.NET Core Web API into a cleaner and more professional architecture.

The original API contained multiple design and architectural problems, including business logic inside the controller, direct data storage, unclear routes, missing DTOs, and incorrect HTTP status codes.

The goal of the refactoring was to improve the API structure while preserving its original functionality.

---

## 🎯 Task Objectives

* Identify common problems in poorly designed APIs.
* Separate responsibilities between Controllers and Services.
* Introduce DTOs for API requests and responses.
* Apply proper RESTful routing.
* Return appropriate HTTP status codes.
* Move business logic out of the Controller.
* Introduce Dependency Injection and Service Interfaces.
* Improve API readability and maintainability.

---

# ❌ Before Refactoring

The original API had several design problems:

### 1. Public Fields Instead of Properties

The original `Product` model used public fields:

```csharp
public int Id;
public string Name;
public decimal Price;
public int Stock;
```

This was refactored into properties:

```csharp
public int Id { get; set; }
public string Name { get; set; }
public decimal Price { get; set; }
public int Stock { get; set; }
```

---

### 2. Parameters Directly in POST

The original `POST` endpoint accepted separate parameters:

```csharp
Add(string name, decimal price, int stock)
```

This was replaced with a request DTO:

```csharp
CreateProductRequest
```

The API now receives the product data through the request body.

Example:

```json
{
  "name": "Laptop",
  "price": 35000,
  "stock": 10
}
```

---

### 3. No Service Layer

The original Controller was responsible for:

* Data storage
* Validation
* Business logic
* Creating products
* Searching products

The refactored version introduces:

```text
Controller
    ↓
IProductService
    ↓
ProductService
    ↓
Product Data
```

This separates HTTP handling from business logic.

---

### 4. Business Logic Inside Controller

The original Controller directly manipulated the product collection.

After refactoring, product operations are handled by:

```text
ProductService
```

The Controller only handles HTTP concerns and delegates operations to the service.

---

### 5. No DTOs

The original API returned the `Product` model directly.

The refactored API introduces:

```text
CreateProductRequest
ProductResponse
```

This provides a clear contract between the API and its clients.

---

### 6. Incorrect HTTP Status Codes

The original API returned:

```http
200 OK
```

even when an error occurred.

For example:

```csharp
return Ok("bad price");
```

or:

```csharp
return Ok("not found");
```

These were replaced with appropriate HTTP status codes.

| Situation           | Before   | After             |
| ------------------- | -------- | ----------------- |
| Successful creation | `200 OK` | `201 Created`     |
| Successful GET      | `200 OK` | `200 OK`          |
| Invalid request     | `200 OK` | `400 Bad Request` |
| Product not found   | `200 OK` | `404 Not Found`   |

---

# ✅ After Refactoring

The API now follows a cleaner structure:

```text
Client
   ↓
ProductsController
   ↓
IProductService
   ↓
ProductService
   ↓
Product Data
```

---

## 📂 Project Structure

```text
task-06-api-standards-refactor-pack/
│
├── Exceptions/
│   └── BusinessException.cs
│
├── Middleware/
│   └── ExceptionHandlingMiddleware.cs
│
├── OriginalBadCode/
│   └── ProductsController.cs
│
├── RefactoredAPI/
│   ├── Controllers/
│   │   └── ProductsController.cs
│   │
│   ├── DTOS/
│   │   ├── CreateProductRequest.cs
│   │   └── ProductResponse.cs
│   │
│   ├── Models/
│   │   └── Product.cs
│   │
│   ├── Seeding/
│   │   └── ProductsSeeding.cs
│   │
│   └── Services/
│       ├── IProductService.cs
│       └── ProductService.cs
│
├── appsettings.json
└── Program.cs
```

---

# 🔌 API Endpoints

The original routes were replaced with RESTful routes.

### Create Product

```http
POST /api/products
```

Returns:

```http
201 Created
```

---

### Get All Products

```http
GET /api/products
```

Returns:

```http
200 OK
```

---

### Get Product by ID

```http
GET /api/products/{id}
```

Returns:

```http
200 OK
```

when the product exists.

If the product does not exist:

```http
404 Not Found
```

---

# 🛡️ Validation

Input validation is handled through the request DTO.

Example:

```csharp
[Required]
public string Name { get; set; }

[Range(100, 1000000)]
public decimal Price { get; set; }

[Range(1, 100000)]
public int Stock { get; set; }
```

With `[ApiController]`, invalid model data is automatically rejected before the Controller action executes.

Business rules remain inside the Service Layer.

This creates a clear separation between:

* **Input validation**
* **Business validation**

---

# 💉 Dependency Injection

The service is registered using ASP.NET Core Dependency Injection:

```csharp
builder.Services.AddScoped<IProductService, ProductService>();
```

The Controller depends on the interface rather than directly depending on the concrete service implementation.

```text
ProductsController
        ↓
 IProductService
        ↓
 ProductService
```

This improves maintainability, testability, and separation of concerns.

---

# 🧪 API Testing

The refactored API can be tested using:

* Swagger
* Postman

Important scenarios to verify:

### Success Cases

* Create Product → `201 Created`
* Get All Products → `200 OK`
* Get Existing Product → `200 OK`

### Failure Cases

* Invalid product data → `400 Bad Request`
* Product does not exist → `404 Not Found`

---

# 📸 Evidence

Screenshots can be added to demonstrate the difference between the original and refactored API.

## Old API

Examples:

* Invalid data returning `200 OK`
* Missing product returning `200 OK`
* Logic and storage inside the Controller

## Refactored API

Examples:

* Successful product creation with `201 Created`
* Successful product retrieval with `200 OK`
* Missing product with `404 Not Found`
* Invalid request with `400 Bad Request`
* Swagger showing the DTO request and response shapes

---

# 📊 Before vs After

| Area                 | Before ❌       | After ✅           |
| -------------------- | -------------- | ----------------- |
| Model                | Public fields  | Properties        |
| POST input           | Parameters     | Request DTO       |
| Response             | Model / string | Response DTO      |
| Validation           | Controller     | DTO + Service     |
| Business Logic       | Controller     | Service           |
| Data Storage         | Controller     | Service           |
| Service Layer        | ❌              | ✅                 |
| Interface            | ❌              | `IProductService` |
| Routes               | `/all`, `/get` | RESTful routes    |
| Invalid Data         | `200 OK`       | `400 Bad Request` |
| Missing Product      | `200 OK`       | `404 Not Found`   |
| Created Product      | `200 OK`       | `201 Created`     |
| Dependency Injection | ❌              | ✅                 |

---

# 🎓 Learning Outcomes

Through this task, the API was refactored to demonstrate professional ASP.NET Core Web API practices.

The main concepts practiced were:

* RESTful API design
* Controllers
* DTOs
* Service Layer
* Interfaces
* Dependency Injection
* Model validation
* Business validation
* HTTP status codes
* Separation of concerns
* Clean API structure
* Maintainable backend architecture

---

## 👨‍💻 Author

**Ahmed Farag Fekry Dahy**

TechMaster Academy
ASP.NET Backend Career Training
Phase 02 — Web API Basics

---

⭐ Refactored as part of the TechMaster ASP.NET Backend Career Training.
