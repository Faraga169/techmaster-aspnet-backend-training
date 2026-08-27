# 🎓 Student Management API

A RESTful Web API built with **ASP.NET Core** for managing student information.

This project was developed as part of **TechMaster ASP.NET Backend Career Training — Phase 02: ASP.NET Core Web API Basics**.

The project focuses on practicing RESTful API development, DTOs, service-layer architecture, LINQ, filtering, pagination, business validation, custom exceptions, and middleware.

---

## 📌 Project Overview

The **Student Management API** provides a backend service for managing student records.

Each student contains information such as:

* Full name
* Email
* Phone number
* Training track
* Active status
* GitHub profile
* LinkedIn profile

The API supports CRUD-style operations, student searching and filtering, pagination, status management, and statistical reporting.

The current implementation uses **in-memory seeded data** rather than a database.

---

## ✨ Features

### 👨‍🎓 Student Management

* Create a student
* Get a student by ID
* Get all students
* Update student information
* Update student active status
* Search students by name
* Filter students by email
* Filter students by track
* Filter students by active status
* Pagination
* Student statistics

### 🛡️ Validation & Error Handling

* Unique email validation
* Required field validation
* Student existence validation
* Page size validation
* Page number validation
* Custom business exceptions
* Centralized exception handling middleware

### 📊 Statistics

The API provides:

* Total number of students
* Number of active students
* Number of inactive students
* Student count grouped by track

---

## 🛠️ Technologies

* **C#**
* **ASP.NET Core Web API**
* **.NET**
* **LINQ**
* **REST API**
* **Dependency Injection**
* **DTOs**
* **Custom Exceptions**
* **Middleware**
* **Swagger / OpenAPI**
* **In-Memory Data Storage**
* **Postman**

---

# 🏗️ Architecture

The project follows a simple layered architecture:

```text
Client
   │
   ▼
Controller
   │
   ▼
Service
   │
   ▼
In-Memory Data
```

### Controller Layer

The `StudentController` is responsible for:

* Handling HTTP requests
* Reading route and query parameters
* Calling the service layer
* Returning HTTP responses

The controller uses the route:

```text
/api/Student
```

The controller depends on the `StudentService` to perform the actual business operations.

### Service Layer

`StudentService` contains the application's business logic, including:

* Student creation
* Student retrieval
* Searching
* Filtering
* Pagination
* Student updates
* Status updates
* Statistics
* Business validation

The service implements:

```text
IStudentService
```

This separates business logic from the controller.

### DTO Layer

DTOs are used to control the data exchanged through the API.

The project includes:

```text
CreateStudentRequest
UpdateStudentRequest
UpdateStudentStatusRequest
StudentResponse
PagedResultResponse
StudentStatsResponse
TrackStatsResponse
```

---

# 📂 Project Structure

```text
StudentManagementAPI/
│
├── Controllers/
│   └── StudentController.cs
│
├── DTOS/
│   ├── CreateStudentRequest.cs
│   ├── UpdateStudentRequest.cs
│   ├── UpdateStudentStatusRequest.cs
│   ├── StudentResponse.cs
│   ├── PagedResultResponse.cs
│   ├── StudentStatsResponse.cs
│   └── TrackStatsResponse.cs
│
├── Exceptions/
│   └── BusinessException.cs
│
├── Middleware/
│   └── ExceptionHandlingMiddleware.cs
│
├── Models/
│   └── Student.cs
│
├── Seeding/
│   └── StudentSeeding.cs
│
├── Services/
│   ├── IStudentService.cs
│   └── StudentService.cs
│
├── Properties/
│
├── Program.cs
├── StudentManagementAPI.csproj
├── StudentManagementAPI.http
├── appsettings.json
└── appsettings.Development.json
```

The project structure above matches the current repository structure.

---

# 👨‍🎓 Student Model

Each student contains:

| Property             | Type      | Description               |
| -------------------- | --------- | ------------------------- |
| `Id`                 | `Guid`    | Unique student identifier |
| `FullName`           | `string`  | Student full name         |
| `Email`              | `string`  | Student email             |
| `PhoneNumber`        | `string`  | Student phone number      |
| `TrackName`          | `string`  | Training track            |
| `IsActive`           | `bool`    | Student active status     |
| `GitHubProfileUrl`   | `string?` | GitHub profile            |
| `LinkedInProfileUrl` | `string?` | LinkedIn profile          |

The model currently uses a `Guid` as the student identifier and optional URLs for GitHub and LinkedIn profiles.

---

# 🔌 API Endpoints

Base URL:

```text
/api/Student
```

---

## 1. Get All Students

```http
GET /api/Student
```

Returns a paginated list of students.

### Query Parameters

| Parameter    | Description                 | Default |
| ------------ | --------------------------- | ------: |
| `name`       | Search by student name      |       — |
| `email`      | Filter by exact email       |       — |
| `trackName`  | Filter by track             |       — |
| `IsActive`   | Filter by active status     |       — |
| `pagenumber` | Page number                 |     `1` |
| `pagesize`   | Number of students per page |     `5` |

### Example

```http
GET /api/Student?name=Ahmed&pagenumber=1&pagesize=5
```

### Example with multiple filters

```http
GET /api/Student?trackName=.NET&IsActive=true&pagenumber=1&pagesize=5
```

The service applies the filters before pagination and returns:

```text
PageNumber
PageSize
TotalCount
TotalPages
Students
```

---

# 🔎 Filtering

The API supports multiple student filters.

### Search by Name

```http
GET /api/Student?name=Ahmed
```

The name search uses case-insensitive partial matching.

For example:

```text
Ahmed
```

can match names containing:

```text
Ahmed
Ahmed Farag
Mohamed Ahmed
```

### Filter by Email

```http
GET /api/Student?email=ahmed@example.com
```

Email matching is case-insensitive.

### Filter by Track

```http
GET /api/Student?trackName=.NET
```

Track matching is case-insensitive.

### Filter by Active Status

```http
GET /api/Student?IsActive=true
```

or:

```http
GET /api/Student?IsActive=false
```

The filters can also be combined.

Example:

```http
GET /api/Student?trackName=.NET&IsActive=true&pagesize=10&pagenumber=1
```

---

# 📄 Pagination

Pagination is supported through:

```text
pagenumber
pagesize
```

Example:

```http
GET /api/Student?pagenumber=2&pagesize=5
```

The response contains:

```json
{
  "pageNumber": 2,
  "pageSize": 5,
  "totalCount": 20,
  "totalPages": 4,
  "students": []
}
```

### Pagination Validation

The API validates pagination parameters.

`pagesize` must be greater than `0`.

`pagenumber` must be greater than `0`.

The requested page cannot exceed the total number of available pages.

Invalid pagination requests result in a business error with HTTP `400 Bad Request`.

---

# 2. Get Student by ID

```http
GET /api/Student/{id}
```

The ID is a `Guid`.

Example:

```http
GET /api/Student/8f7f1d8a-7c4e-4e5a-8f1d-123456789abc
```

If the student exists, the API returns the student's information.

If the student does not exist:

```http
404 Not Found
```

with a business exception indicating that the student was not found.

---

# 3. Create Student

```http
POST /api/Student
```

### Request Body

```json
{
  "fullName": "Ahmed Farag",
  "email": "ahmed@example.com",
  "phoneNumber": "01012345678",
  "trackName": ".NET",
  "isActive": true,
  "gitHubProfileUrl": "https://github.com/example",
  "linkedInProfileUrl": "https://linkedin.com/in/example"
}
```

The API generates a new `Guid` automatically for the student.

### Email Validation

Student emails must be unique.

If the email already exists:

```http
400 Bad Request
```

is returned with:

```text
Email must be unique
```

### Successful Response

The endpoint returns:

```http
201 Created
```

and uses `CreatedAtAction` to reference the newly created student's `GET by ID` endpoint.

---

# 4. Update Student

```http
PUT /api/Student/{Id}
```

### Example

```http
PUT /api/Student/8f7f1d8a-7c4e-4e5a-8f1d-123456789abc
```

### Request Body

```json
{
  "fullName": "Ahmed Farag Fekry",
  "email": "ahmed@example.com",
  "phoneNumber": "01012345678",
  "trackName": ".NET Backend",
  "isActive": true,
  "gitHubProfileUrl": "https://github.com/example",
  "linkedInProfileUrl": "https://linkedin.com/in/example"
}
```

The service validates:

* Full name is required
* Email is required
* Phone number is required
* Track name is required
* Email must be unique
* Student must exist

Successful updates return:

```http
200 OK
```

---

# 5. Update Student Status

```http
PATCH /api/Student
```

The current controller exposes the status update through the `PATCH` method.

### Request Body

```json
{
  "isActive": false
}
```

The service updates only the student's active status.

If the student does not exist:

```http
404 Not Found
```

Successful updates return:

```http
200 OK
```

> **Note:** The current implementation receives the student `Guid` through the `Id` parameter of the action while the route itself is not explicitly defined for the `PATCH` action.

---

# 6. Student Statistics

```http
GET /api/Student/Stats
```

Returns statistics about the current student collection.

### Statistics Include

* Total students
* Active students
* Inactive students
* Number of students per track

Example response:

```json
{
  "totalStudents": 10,
  "activeStudents": 7,
  "inActiveStudents": 3,
  "countByTrack": [
    {
      "trackName": ".NET",
      "count": 5
    },
    {
      "trackName": "Frontend",
      "count": 3
    },
    {
      "trackName": "Data Science",
      "count": 2
    }
  ]
}
```

The statistics are calculated using LINQ `Count`, `Where`, and `GroupBy`.

---

# ⚠️ Error Handling

The project uses:

```text
BusinessException
```

together with:

```text
ExceptionHandlingMiddleware
```

This provides centralized handling for application-level errors.

### Examples

| Situation                           |            Status |
| ----------------------------------- | ----------------: |
| Student not found                   |   `404 Not Found` |
| Duplicate email                     | `400 Bad Request` |
| Missing full name                   | `400 Bad Request` |
| Missing email                       | `400 Bad Request` |
| Missing phone                       | `400 Bad Request` |
| Missing track                       | `400 Bad Request` |
| Invalid page size                   | `400 Bad Request` |
| Invalid page number                 | `400 Bad Request` |
| Page number exceeds available pages | `400 Bad Request` |

Business validation is handled inside the service layer rather than directly inside the controller.

---

# 🌱 In-Memory Data Storage

The current version does not use SQL Server or Entity Framework Core.

Student data is stored in:

```text
StudentSeeding.Students
```

The service performs operations directly against this in-memory collection.

### Important

Because the application uses in-memory data:

* Data is available only while the application is running.
* Created students are lost after restarting the application.
* Updated students are lost after restarting the application.
* No persistent database is currently configured.

---

# 🧩 DTOs

The project uses separate DTOs for different operations.

### Create Student

```text
CreateStudentRequest
```

### Update Student

```text
UpdateStudentRequest
```

### Update Status

```text
UpdateStudentStatusRequest
```

### Student Response

```text
StudentResponse
```

### Paginated Response

```text
PagedResultResponse
```

### Statistics

```text
StudentStatsResponse
TrackStatsResponse
```

This keeps API contracts separated from the underlying model.

---

# 💉 Dependency Injection

The application uses ASP.NET Core Dependency Injection.

The controller receives the service through its constructor:

```csharp
public class StudentController(StudentService studentService)
```

This keeps the controller focused on HTTP handling while the service handles business logic.

---

# 📖 Swagger / OpenAPI

The project is configured as an ASP.NET Core Web API and includes Swagger/OpenAPI support.

Swagger can be used to:

* Explore available endpoints
* Test API requests
* Inspect request parameters
* Test request bodies
* Review API responses

The project's existing documentation references the Swagger/OpenAPI endpoint:

```text
https://localhost:7101/swagger/v1/swagger.json
```

---

# 🧪 Testing

The API can be tested using:

* Swagger UI
* Postman
* `StudentManagementAPI.http`

The repository includes an HTTP request file for testing the API directly from supported IDEs.

---

# ▶️ Getting Started

## Prerequisites

Make sure you have:

* .NET SDK
* Git
* Visual Studio / VS Code
* Postman (optional)

---

## Clone the Repository

```bash
git clone https://github.com/Faraga169/techmaster-aspnet-backend-training.git
```

Navigate to the project:

```powershell
cd "techmaster-aspnet-backend-training/phase-02-web-api-basics/task-02-student-management-api/StudentManagementAPI"
```

---

## Restore Dependencies

```bash
dotnet restore
```

---

## Run the Application

```bash
dotnet run
```

The API will start using the configured ASP.NET Core development environment.

---

# 🎯 Learning Objectives

This project was built to practice:

* ASP.NET Core Web API fundamentals
* RESTful API design
* HTTP methods
* Routing
* Controllers
* Service Layer
* Interfaces
* Dependency Injection
* DTOs
* LINQ
* Filtering
* Pagination
* CRUD operations
* Business validation
* Custom exceptions
* Middleware
* HTTP status codes
* Swagger / OpenAPI
* In-memory data handling
* Statistical queries using LINQ

---

# 🚧 Future Improvements

Possible improvements for future phases:

* Replace in-memory storage with SQL Server
* Add Entity Framework Core
* Add database migrations
* Introduce Repository Pattern
* Add automated unit tests
* Add integration tests
* Improve API validation
* Add sorting
* Add advanced search
* Add authentication and authorization
* Add JWT authentication
* Improve PATCH route design

---

# 👨‍💻 Author

**Ahmed Farag Fekry Dahy**

ASP.NET Backend Career Training
TechMaster — Phase 02: Web API Basics

---

## 📚 Training Repository

This project is part of the **TechMaster ASP.NET Backend Career Training** repository.

The repository contains practical backend tasks covering ASP.NET Core, REST APIs, C#, LINQ, and backend architecture.

---

⭐ Built as part of my ASP.NET backend development training journey.
