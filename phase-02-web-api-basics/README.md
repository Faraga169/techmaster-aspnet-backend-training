# TechMaster Academy — ASP.NET Backend Training

## Phase 02 — ASP.NET Core Web API Basics

This phase focuses on building professional **ASP.NET Core Web APIs** using REST principles, DTOs, Services, Dependency Injection, validation, Swagger/OpenAPI, Postman, API architecture, and clean backend practices.

---

## 📌 Phase Overview

**Phase:** 02
**Track:** ASP.NET Backend
**Focus:** ASP.NET Core Web API Basics

### Main Topics

* REST & HTTP
* ASP.NET Core Web API
* Controllers
* Routing
* Model Binding
* DTOs
* Data Annotations
* Input Validation
* Business Validation
* Service Layer
* Dependency Injection
* RESTful API Design
* HTTP Status Codes
* Search & Filtering
* Pagination
* Swagger / OpenAPI
* Postman
* API Testing
* Exception Handling
* API Security Awareness
* Clean Architecture
* Git & GitHub

---

# 📂 Phase 02 Projects

## 1. Student Management API

A RESTful Web API for managing students.

### Main Features

* Create Student
* Get All Students
* Get Student By Id
* Update Student
* Update Student Status
* Student Statistics

### Concepts Applied

* Controllers
* DTOs
* Services
* Dependency Injection
* Validation
* HTTP Status Codes
* Search / Filtering
* Pagination
* RESTful Routing

---

## 2. Products & Categories API

An API for managing products and categories.

### Main Features

* Create Category
* Create Product
* Search Products
* Low Stock Products
* Stock Value Report

### Concepts Applied

* DTOs
* Service Layer
* Business Logic
* Validation
* LINQ
* Search & Filtering
* Reporting
* RESTful Endpoints

---

## 3. Book Store API

A RESTful API for managing a bookstore.

### Main Features

* Create Author
* Create Category
* Create Book
* Search Books
* Book Reports

### Concepts Applied

* DTOs
* Controllers
* Services
* Dependency Injection
* Model Validation
* Business Validation
* Search & Filtering
* LINQ
* RESTful Routing
* Exception Handling

---

# 🧪 REST & Routing Drill Pack

A collection of small ASP.NET Core Web API drills focused on controllers, routing, query strings, request bodies, headers, validation, CRUD operations, pagination, and HTTP status codes.

## Required Output

* Minimum 15 API drills.
* Each drill documented in this README.
* Swagger screenshot for at least 5 drills.
* Postman evidence for at least 8 drills.
* Commit after every 3–5 drills.

---

## Drill Table

| Drill No. | Endpoint                                            | Concept                                    | Status | Evidence           |
| --------- | --------------------------------------------------- | ------------------------------------------ | ------ | ------------------ |
| 01        | `GET /api/health`                                   | Basic endpoint / Controller action         | Done   | Swagger screenshot |
| 02        | `GET /api/tools/echo/{name}`                        | Route parameter                            | Done   | Postman screenshot |
| 03        | `GET /api/calculator/add?a=10&b=5`                  | Query parameters                           | Done   | Postman screenshot |
| 04        | `GET /api/converter/celsius-to-fahrenheit?value=25` | Business calculation + Service + DI        | Done   | Swagger screenshot |
| 05        | `GET /api/grades/calculate?score=85`                | Validation + Conditions                    | Done   | Postman screenshot |
| 06        | `POST /api/notes`                                   | Request body + DTO + Create resource       | Done   | Postman screenshot |
| 07        | `GET /api/notes`                                    | Collection response                        | Done   | Swagger screenshot |
| 08        | `GET /api/notes/{id}`                               | Route ID + 404 Not Found                   | Done   | Postman screenshot |
| 09        | `PUT /api/notes/{id}`                               | PUT update + DTO validation                | Done   | Postman screenshot |
| 10        | `DELETE /api/notes/{id}`                            | DELETE + 204 No Content                    | Done   | Postman screenshot |
| 11        | `GET /api/notes/search?keyword=api`                 | Query string search + LINQ                 | Done   | Postman screenshot |
| 12        | `GET /api/notes/pagination?pageNumber=1&pageSize=5` | Pagination + Skip / Take                   | Done   | Swagger screenshot |
| 13        | `GET /api/request-info`                             | Custom request headers                     | Done   | Postman screenshot |
| 14        | `GET/POST multiple`                                 | HTTP status codes: 200, 201, 204, 400, 404 | Done   | —                  |
| 15        | `GET /api/errors/demo`                              | Standard error response shape              | Done   | —                  |

---

## Drill Details

### Drill 01 — Health Check

**Endpoint:** `GET /api/health`

**Purpose:** Verify that the API is running and reachable.

**Response:**

* HTTP `200 OK`
* JSON response containing status, service name, and server time.

---

### Drill 02 — Route Parameter Echo

**Endpoint:** `GET /api/tools/echo/{name}`

**Purpose:** Practice receiving data directly from the route.

**Example:**

```http
GET /api/tools/echo/Ahmed
```

The response contains the original name and a greeting message.

---

### Drill 03 — Query String Calculator

**Endpoint:** `GET /api/calculator/add?a=10&b=5`

**Purpose:** Practice receiving values from the query string and returning a calculated result.

**Response fields:**

* `a`
* `b`
* `operation`
* `result`

---

### Drill 04 — Temperature Conversion API

**Endpoint:** `GET /api/converter/celsius-to-fahrenheit?value=25`

**Purpose:** Convert the Phase 01 temperature calculation into an API endpoint.

The calculation is handled by `ConverterService` and injected through Dependency Injection.

**Formula:**

```text
Fahrenheit = (Celsius × 9 / 5) + 32
```

---

### Drill 05 — Grade API

**Endpoint:** `GET /api/grades/calculate?score=85`

**Purpose:** Practice validation and conditional logic inside an API endpoint.

The score must be between `0` and `100`.

Invalid values return:

```text
400 Bad Request
```

Valid values return the grade and pass/fail status.

---

### Drill 06 — Create Note

**Endpoint:** `POST /api/notes`

**Purpose:** Practice receiving JSON request bodies through a DTO and creating a new resource.

The request uses `CreateNoteRequest`.

A successful creation returns the generated:

* ID
* Title
* Content
* CreatedAt

---

### Drill 07 — Get Notes List

**Endpoint:** `GET /api/notes`

**Purpose:** Practice returning a collection from an API endpoint.

The endpoint returns all in-memory notes as a JSON collection.

If no notes exist, an empty collection can be returned.

---

### Drill 08 — Get Note By ID

**Endpoint:** `GET /api/notes/{id}`

**Purpose:** Practice route parameters and `404 Not Found`.

If the note exists:

```text
200 OK
```

If the note does not exist:

```text
404 Not Found
```

---

### Drill 09 — Update Note

**Endpoint:** `PUT /api/notes/{id}`

**Purpose:** Practice updating an existing resource using a route ID and request body DTO.

The endpoint validates:

* Title
* Content

If the note does not exist:

```text
404 Not Found
```

If validation fails:

```text
400 Bad Request
```

A successful update returns the updated note.

---

### Drill 10 — Delete Note

**Endpoint:** `DELETE /api/notes/{id}`

**Purpose:** Practice RESTful DELETE behavior and HTTP status codes.

If the note exists, it is removed and the endpoint returns:

```text
204 No Content
```

If the note does not exist:

```text
404 Not Found
```

---

### Drill 11 — Search Notes

**Endpoint:** `GET /api/notes/search?keyword=api`

**Purpose:** Practice query string search and LINQ filtering.

The endpoint searches both:

* Note title
* Note content

The search is case-insensitive.

An empty keyword returns:

```text
400 Bad Request
```

---

### Drill 12 — Pagination

**Endpoint:** `GET /api/notes/pagination?pageNumber=1&pageSize=5`

**Purpose:** Practice API pagination using LINQ `Skip()` and `Take()`.

Pagination calculation:

```text
Skip = (pageNumber - 1) × pageSize
Take = pageSize
```

The response contains:

* `items`
* `pageNumber`
* `pageSize`
* `totalCount`

Validation:

* `pageNumber` must be greater than `0`.
* `pageSize` must be between `1` and `50`.

---

### Drill 13 — Header Reader

**Endpoint:** `GET /api/request-info`

**Purpose:** Practice reading custom HTTP request headers.

The endpoint reads:

```http
X-Student-Name: Ahmed
```

The response contains:

* Student name from the header.
* Current request path.

If the header is missing:

```text
400 Bad Request
```

---

## HTTP Status Codes Used

| Status Code       | Meaning                                         | Example                         |
| ----------------- | ----------------------------------------------- | ------------------------------- |
| `200 OK`          | Request succeeded and response data is returned | Get note                        |
| `201 Created`     | A new resource was created                      | Create note                     |
| `204 No Content`  | Operation succeeded without response body       | Delete note                     |
| `400 Bad Request` | Client sent invalid or incomplete input         | Invalid score / missing keyword |
| `404 Not Found`   | Requested resource does not exist               | Note not found                  |

---

## Key Concepts Practiced

* Controllers and Actions
* HTTP Methods
* Route Parameters
* Query Parameters
* Request Body
* DTOs
* Model Validation
* Dependency Injection
* Services
* LINQ
* CRUD Operations
* HTTP Headers
* HTTP Status Codes
* Search
* Pagination
* `Skip()` and `Take()`
* Standard API Response Shapes

---

# 🏗️ Architecture

The projects follow a layered architecture based on **Separation of Concerns**.

```text
Client / UI
    ↓
HTTP Request
    ↓
Controller
    ↓
Service Layer
    ↓
Data Access / Storage
    ↓
Database / In-Memory Storage
```

### Controller

Responsible for handling HTTP concerns such as:

* Routing
* Model Binding
* Input Validation
* HTTP Status Codes
* Returning HTTP Responses

Controllers should remain thin and delegate business operations to the Service Layer.

### Service Layer

Responsible for:

* Business Logic
* Business Rules
* Application Operations
* Business Validation

### Data Access / Storage

Responsible for:

* Storing data
* Retrieving data
* Updating data
* Removing data

---

# 🔄 Request Flow

A typical request follows this flow:

```text
Client
  ↓
HTTP Request
  ↓
Routing
  ↓
Model Binding
  ↓
Model Validation
  ↓
Controller Action
  ↓
Service
  ↓
Data Access
  ↓
Storage
```

The response travels back through the layers:

```text
Storage
  ↓
Data Access
  ↓
Service
  ↓
Controller
  ↓
HTTP Response
  ↓
Client
```

---

# 📦 DTOs

DTOs are used to control the data exchanged between the client and the API.

Different DTOs can be used for different purposes:

```text
CreateRequest
UpdateRequest
Response
```

DTOs help with:

* Security
* Preventing overposting
* Separation of concerns
* API contract definition
* Different request and response shapes
* Maintainability

---

# 💉 Dependency Injection

Dependency Injection is used to provide Services to Controllers without creating dependencies manually.

Example:

```csharp
public ProductsController(IProductService productService)
{
    _productService = productService;
}
```

Services are registered in the DI container:

```csharp
builder.Services.AddScoped<IProductService, ProductService>();
```

This helps achieve:

* Loose Coupling
* Maintainability
* Flexibility
* Testability

---

# 📖 Swagger / OpenAPI

Swagger/OpenAPI is used to document and test the APIs.

The Swagger documentation provides visibility into:

* Available endpoints
* HTTP methods
* Request parameters
* Request bodies
* DTO schemas
* Response types
* HTTP status codes

Swagger UI also allows endpoints to be tested directly from the browser.

---

# 📮 Postman

A dedicated Postman collection was created for Phase 02.

## Collection Structure

```text
TechMaster ASP.NET Phase 02
│
├── Student Management API
│   ├── Create Student
│   ├── Get All Students
│   ├── Get Student By Id
│   ├── Update Student
│   ├── Update Student Status
│   └── Student Stats
│
├── Products & Categories API
│   ├── Create Category
│   ├── Create Product
│   ├── Search Products
│   ├── Low Stock Products
│   └── Stock Value Report
│
├── Book Store API
│   ├── Create Author
│   ├── Create Category
│   ├── Create Book
│   ├── Search Books
│   └── Book Reports
│
└── Error Cases
    ├── Missing Resource 404
    ├── Invalid Request 400
    └── Validation Error
```

The collection is exported as a JSON file and can be imported into Postman.

---

# 🔧 Task 06 — API Standards & Refactor Pack

Task 06 focused on identifying and refactoring bad API code into a cleaner and more professional structure.

## Original Problems

The original implementation contained:

* Public fields instead of properties
* String parameters in POST instead of a request body DTO
* Validation returning `200 OK` with error text
* Logic and storage inside the Controller
* No Service Layer
* Poor route names such as `all` and `get`
* No clear response shape

## Refactoring Improvements

The API was refactored to include:

* `Product` model with properties
* `CreateProductRequest` DTO
* `ProductResponse` DTO
* `IProductService`
* `ProductService`
* Service-based validation and business logic
* RESTful routes
* Correct HTTP status codes
* `400 Bad Request` for invalid data
* `404 Not Found` for missing products
* `201 Created` or `200 OK` for successful operations
* README documentation

### Refactored Structure

```text
Controller
    ↓
IProductService
    ↓
ProductService
    ↓
Storage
```

---

# 🛡️ Exception Handling

A centralized Exception Handler Middleware is used to handle unhandled exceptions.

Instead of exposing internal exception details directly to clients, exceptions can be handled centrally and converted into appropriate HTTP responses.

This provides:

* Consistent error handling
* Cleaner Controllers
* Better debugging
* Safer production responses

---

# 🔐 Security Awareness

The API does not trust data received from the client.

Client-side validation can be bypassed because users can send requests directly using tools such as:

* Postman
* cURL
* Custom HTTP clients
* Browser Developer Tools

Therefore, validation and business rules must also be enforced on the backend.

---

# 🧠 Required Questions & Answers

## 1. What does REST mean in the context of Web APIs?

REST stands for Representational State Transfer. It is an architectural style for designing distributed systems and Web APIs. It uses resources identified by URLs and standard HTTP methods such as GET, POST, PUT and DELETE to operate on those resources. RESTful systems follow constraints such as client-server, statelessness, uniform interface, cacheability and layered system.

## 2. What is the difference between GET, POST, PUT, PATCH and DELETE?

GET is used to retrieve resources. POST is commonly used to create a new resource. PUT is used to replace an entire resource, while PATCH is used to partially update a resource. DELETE is used to remove a resource. GET and DELETE typically don't use request bodies, while POST, PUT, and PATCH commonly send data in the request body.

## 3. When should an API return 200, 201, 204, 400 and 404?

200 OK is returned when a request is successfully processed and a response is returned. 201 Created is used when a new resource is successfully created. 204 No Content means the operation succeeded but there is no response body. 400 Bad Request indicates that the client's request is invalid, such as validation errors. 404 Not Found means the requested resource or route could not be found.

## 4. What is the difference between route parameters and query parameters?

A route parameter is part of the URL path and is typically used to identify a specific resource, such as /api/products/5. A query parameter comes after ? in the URL and is commonly used for filtering, searching, sorting, or pagination, such as /api/products?name=laptop&page=2.

## 5. What is the role of a controller in ASP.NET Core Web API?

A Controller is responsible for handling HTTP requests and returning HTTP responses. It defines routes and actions, receives input from the client, and delegates business operations to the Service Layer. The Controller should remain thin and should not contain business logic or data access logic. Services are injected into the Controller using Dependency Injection. Input validation can be handled through DTOs and model validation, while business validation belongs in the Service Layer.

## 6. Why should we use DTOs instead of exposing models directly?

We use DTOs to control the data exchanged between the client and the API instead of exposing our internal models directly. DTOs improve security by preventing sensitive properties from being exposed, prevent overposting, and provide separation between the API contract and the internal domain model. They also allow us to have different request and response shapes and make the API easier to maintain when the internal model changes.

## 7. Why should business logic not stay inside the controller?

Business logic should not stay inside the Controller because Controllers should focus on handling HTTP concerns such as routing, model binding, and returning HTTP responses. Business rules should be placed in the Service Layer to follow Separation of Concerns. This makes the application easier to maintain, test, and reuse. Input validation can be handled through DTOs and model validation, while business validation belongs in the Service Layer.

## 8. What is Dependency Injection and why is it useful?

Dependency Injection is a design technique used to provide a class with the dependencies it needs instead of creating them internally. It helps reduce tight coupling by making classes depend on abstractions rather than concrete implementations. In ASP.NET Core, dependencies are registered in the DI container and injected, usually through the constructor. This improves maintainability, flexibility, and testability.

## 9. Where can validation happen in a Web API?

Validation can happen at different levels. Input or model validation can be handled using Data Annotations on DTOs, and with [ApiController], ASP.NET Core automatically returns a 400 Bad Request when model validation fails before the action executes. Business validation, such as checking whether a product already exists or whether there is enough stock, should be handled in the Service Layer.

## 10. What is Swagger/OpenAPI used for?

OpenAPI is a standard specification used to describe and document Web APIs, including their endpoints, parameters, request bodies, responses, and schemas. Swagger is a set of tools built around the OpenAPI specification, such as Swagger UI, which provides interactive API documentation and allows developers to test endpoints directly from the browser.

## 11. Why do we need Postman if Swagger already exists?

Swagger can be used to interact with and test individual endpoints, but Postman provides more advanced and organized testing capabilities such as collections, environments, variables, scripts, and automated test scenarios.

## 12. What makes an API response professional and predictable?

A professional API should have a clear and consistent response shape. We should use DTOs to define the response contract and ActionResult<T> to make the expected response type explicit. HTTP status codes should accurately represent the result of the operation, and error responses should follow a consistent structure. This makes the API predictable for clients and easier to document with Swagger/OpenAPI.

## 13. How would you implement search and filtering in an API?

Search and filtering are usually implemented using query parameters because they modify how we retrieve a collection without identifying a specific resource. I can use LINQ Where to apply filters, and for text search I can use methods such as Contains for partial matching. Multiple query parameters can be combined to support different filtering criteria.

## 14. Why is pagination important in APIs?

Pagination is important because returning a large number of records in a single response can increase response size, memory usage, network bandwidth, database load, and response time. We can use pageNumber and pageSize to return only a specific portion of the data. In LINQ, this can be implemented using Skip((pageNumber - 1) * pageSize) and Take(pageSize), preferably at the database query level.

## 15. What is the difference between UI, controller, service and data storage?

The UI is responsible for user interaction and sending HTTP requests. The Controller handles HTTP concerns such as routing, model binding, validation, and returning HTTP responses. The Service Layer contains business logic and business rules. The Data Access or Storage layer is responsible for storing and retrieving data from sources such as a database. This separation follows Separation of Concerns and makes the application easier to maintain and test.

## 16. What should reviewers see in your commit history?

Reviewers should see clear and focused commits where each commit represents a specific change or feature. Meaningful commit messages make the project history easier to understand and allow reviewers to follow how the project evolved.

## 17. How do you prove that your API works without running it on the reviewer device?

I can prove that the API works using Swagger and Postman evidence. I can provide screenshots showing successful and failure responses, export the Postman collection as JSON so the reviewer can inspect or import the requests, and include a README explaining how to use the collection. I can also provide a demo video showing the API in action.

## 18. How do you investigate an endpoint that returns 500?

When an endpoint returns 500, I first reproduce the issue and check the logs and exception details, including the stack trace. Then I debug through the request flow from the Controller to the Service and Data Access layer to identify where the exception occurs. I also check database issues, dependency injection, and configuration if needed. After fixing the issue, I retest the endpoint. In production, I avoid exposing detailed exception information to the client and use centralized exception handling and logging instead.

## 19. Why should we not trust request data from users?

We should never trust data coming from the client because client-side validation can be bypassed or removed, and users can send requests directly using tools such as Postman or custom clients. Therefore, the backend must validate and verify all incoming data and enforce business rules, authentication, and authorization before processing the request or storing the data.

## 20. Why is in-memory storage not enough for real applications?

In-memory storage is not enough for real applications because the data is temporary and is lost when the application restarts or crashes. It also does not work well when the application runs on multiple servers because each server has its own memory. In addition, it does not provide the persistence, concurrency control, transactions, backup, and querying capabilities that a real database provides.

---

# 📊 Phase 02 Learning Outcomes

By completing Phase 02, the following concepts were practiced:

* Designing RESTful APIs
* Using HTTP methods correctly
* Returning appropriate HTTP status codes
* Building Controllers
* Creating and using DTOs
* Implementing input validation
* Implementing business validation
* Applying Separation of Concerns
* Creating Service Layers
* Using Dependency Injection
* Implementing search and filtering
* Implementing pagination
* Documenting APIs with Swagger/OpenAPI
* Testing APIs with Postman
* Handling API exceptions
* Understanding backend security responsibilities
* Using Git and meaningful commit history
* Providing API testing evidence

---

# 📁 Evidence & Delivery

The Phase 02 submission includes:

* Swagger documentation
* Swagger screenshots
* Postman collection
* Postman success-case screenshots
* Postman failure-case screenshots
* Error response evidence
* README documentation
* Demo video reference
* Organized GitHub commit history

---

# 🚀 Future Improvements

The current Phase 02 projects use in-memory storage for learning purposes.

For a real production application, the next step is to introduce:

* SQL Server
* Entity Framework Core
* Persistent database storage
* Repository / Data Access patterns where appropriate
* Authentication & Authorization
* Database relationships
* Migrations
* Production-ready logging
* Testing
* Deployment

---

## 👨‍💻 TechMaster Academy

**ASP.NET Backend Career Training — Phase 02**

Focus:

> Build APIs that are not only functional, but also structured, documented, testable, and reviewable.
