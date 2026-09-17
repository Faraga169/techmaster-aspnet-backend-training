# Task 07 — EF Core / API Refactor Pack

A practical ASP.NET Core Web API refactoring task focused on transforming poorly structured EF Core API code into cleaner, maintainable, and review-ready backend code.

This task was completed as part of **TechMaster Academy — ASP.NET Backend Career Training, Phase 03: Real Backend & Data Systems**.

The main goal was not to rewrite the application randomly, but to identify concrete problems in the original implementation and improve its structure, data access, validation, HTTP behavior, and maintainability while preserving the original business purpose.

---

## 🎯 Task Objective

The original implementation contained a single controller responsible for:

* Retrieving enrollments
* Creating enrollments
* Processing payments
* Deleting enrollments

The original code directly interacted with Entity Framework Core, returned database entities, used synchronous operations, performed insufficient validation, and used hard deletion.

The refactored implementation separates responsibilities and applies cleaner backend practices using:

* DTOs
* Service Layer
* Async EF Core operations
* Projection
* Pagination
* Business validation
* Correct HTTP status codes
* Soft delete
* Structured error responses

---

# 📁 Project Structure

The project follows a layered backend structure that separates API concerns from business logic and data access.

```text
EFCoreRefactoring
│
├── API
│   ├── Controllers
│   └── ...
│
├── BLL
│   ├── Services
│   ├── DTOs
│   └── ...
│
├── DAL
│   ├── Persistent
│   ├── Models
│   └── ...
│
└── ...
```

The exact responsibilities are separated so that controllers remain focused on handling HTTP requests while business rules are handled outside the controller.

---

# 🔴 Before Refactoring

The original implementation was intentionally provided as bad EF Core API code.

The original controller directly depended on `AppDbContext` and contained database queries, business rules, entity creation, payment processing, and deletion logic.

Example:

```csharp
private readonly AppDbContext _db;
```

The controller also directly executed EF Core operations such as:

```csharp
_db.Enrollments
    .Include(e => e.Student)
    .Include(e => e.TrainingTrack)
    .Include(e => e.Payments)
    .ToList();
```

This created several problems related to performance, maintainability, validation, separation of concerns, and API design.

The original version was preserved as required by the task.

---

# ⚠️ Problems Found

The following problems were identified in the original implementation:

### 1. Entity Framework Core was used directly inside the controller

The controller was responsible for database access instead of delegating data/business operations to a service layer.

### 2. EF entities were accepted directly from API requests

The `Create` endpoint accepted:

```csharp
Enrollment enrollment
```

This exposes the persistence model directly to API clients.

### 3. EF entities were returned directly

The GET endpoint returned database entities instead of dedicated response DTOs.

### 4. Navigation properties were eagerly loaded unnecessarily

The original GET endpoint used multiple `Include()` calls:

```csharp
.Include(e => e.Student)
.Include(e => e.TrainingTrack)
.Include(e => e.Payments)
```

This can result in unnecessarily large queries and responses.

### 5. No pagination

The original GET endpoint retrieved all enrollments at once.

This does not scale well as the number of records increases.

### 6. No projection

The query retrieved full entities instead of selecting only the data required by the API response.

### 7. Synchronous database operations

Operations such as:

```csharp
.ToList();
.SaveChanges();
.FirstOrDefault();
```

were synchronous.

### 8. No duplicate enrollment validation

The original implementation allowed a student to create duplicate active enrollments.

### 9. Track capacity was ignored

The original enrollment creation logic did not check whether the selected training track had available capacity.

### 10. Payment amount was not validated

The payment endpoint accepted zero or negative amounts.

### 11. Incorrect HTTP status codes

Missing resources were returned using:

```csharp
return Ok("not found");
```

and:

```csharp
return Ok("missing");
```

A successful HTTP response should not be used to represent a missing resource.

### 12. Hard delete was used

The original DELETE endpoint permanently removed the enrollment:

```csharp
_db.Enrollments.Remove(item);
```

This can result in losing historical enrollment data.

### 13. Business logic was placed inside the controller

Enrollment creation and payment processing contained business rules directly inside the API controller.

### 14. Error responses were inconsistent

The original implementation returned plain strings such as:

```text
not found
missing
deleted
```

instead of using a consistent API error/response structure.

---

# 🟢 After Refactoring

The original implementation was refactored into a cleaner backend design while preserving the same business purpose.

The main changes include:

* Request DTOs
* Response DTOs
* Service Layer
* Async EF Core operations
* Projection
* Pagination
* Business validation
* Duplicate enrollment prevention
* Track capacity validation
* Payment validation
* Soft delete
* Correct HTTP status codes
* Structured error handling

---

# 🔧 Improvements Made

## 1. Request DTOs

API endpoints no longer accept EF Core entities directly.

Dedicated request DTOs are used to define exactly which fields the client is allowed to provide.

This protects the persistence model from direct API input.

---

## 2. Response DTOs

The API returns dedicated response models instead of exposing EF Core entities.

This provides better control over:

* API contracts
* Returned fields
* Navigation data
* Future model changes

---

## 3. Service Layer

Business logic was moved from the controller into a dedicated service layer.

The controller is now responsible mainly for:

1. Receiving the request
2. Calling the service
3. Returning the appropriate HTTP response

This improves separation of concerns and maintainability.

---

## 4. Async EF Core Operations

Database operations were changed to asynchronous EF Core methods.

Examples include:

```csharp
ToListAsync()
FirstOrDefaultAsync()
FindAsync()
SaveChangesAsync()
```

This prevents synchronous database operations from unnecessarily blocking request threads.

---

## 5. Projection

The enrollment list uses projection instead of returning complete EF entities.

Only the fields required by the API response are selected.

This reduces unnecessary data retrieval and keeps the response contract explicit.

---

## 6. Pagination

The enrollment list endpoint supports pagination instead of loading all records at once.

This makes the endpoint more suitable for larger datasets.

Typical pagination parameters include:

```text
pageNumber
pageSize
```

---

## 7. Duplicate Enrollment Validation

Before creating an enrollment, the service checks whether the student already has an active enrollment for the same track.

This prevents duplicate active enrollments.

---

## 8. Track Capacity Validation

Enrollment creation now checks the training track capacity before creating a new enrollment.

This keeps enrollment data consistent with the track's available capacity.

---

## 9. Payment Validation

Payment processing now validates the payment amount.

Invalid values such as zero or negative amounts are rejected instead of creating invalid payment records.

---

## 10. Correct HTTP Status Codes

The refactored API uses HTTP status codes according to the result of the operation.

Examples include:

| Situation                            |                            Status |
| ------------------------------------ | --------------------------------: |
| Successful GET                       |                          `200 OK` |
| Successful creation                  |                     `201 Created` |
| Successful deletion/update operation |        Appropriate success status |
| Resource not found                   |                   `404 Not Found` |
| Invalid request                      |                 `400 Bad Request` |
| Business rule violation              | Appropriate client/business error |

This makes the API behavior clearer for consumers.

---

## 11. Soft Delete

The enrollment is no longer permanently removed from the database.

Instead, the record is marked as deleted.

This preserves historical information while allowing the application to exclude deleted records from normal operations.

---

## 12. Consistent Error Responses

Instead of returning plain text such as:

```text
not found
```

the refactored API uses a structured error response.

This provides a more predictable contract for frontend clients and API consumers.

---

## 13. Better Separation of Responsibilities

The refactored architecture separates responsibilities between:

```text
Controller
    ↓
Service
    ↓
Data Access / EF Core
    ↓
Database
```

This makes each layer easier to understand, test, and maintain.

---

## 14. Preserved Business Purpose

The refactoring did not remove the original enrollment functionality.

The same core operations remain available:

* List enrollments
* Create enrollment
* Process payment
* Delete/deactivate enrollment

The implementation was improved without hiding or removing the original features.

---

# 🔄 Before vs After

| Area                 | Before             | After                |
| -------------------- | ------------------ | -------------------- |
| Database access      | Controller         | Service/Data layer   |
| Request model        | EF Entity          | Request DTO          |
| Response model       | EF Entity          | Response DTO         |
| EF operations        | Synchronous        | Async                |
| List query           | Full entities      | Projection           |
| Pagination           | ❌                  | ✅                    |
| Duplicate validation | ❌                  | ✅                    |
| Track capacity       | ❌                  | ✅                    |
| Payment validation   | ❌                  | ✅                    |
| Delete strategy      | Hard delete        | Soft delete          |
| Error handling       | Plain strings      | Structured responses |
| HTTP status codes    | Incorrect in cases | Correct status codes |
| Business logic       | Controller         | Service Layer        |

---

# 🧪 Main API Operations

The refactored API covers the following enrollment operations:

### Get Enrollments

Returns enrollment data using projection and pagination.

### Create Enrollment

Creates an enrollment after validating:

* Request data
* Duplicate active enrollment
* Training track capacity

### Pay Enrollment

Creates a payment after validating:

* Enrollment existence
* Payment amount

### Delete Enrollment

Uses soft delete instead of permanently removing the enrollment.

---

# 📸 Before / After Evidence

Screenshots were captured to demonstrate the difference between the original implementation and the refactored API.

### Before Refactoring

The original API demonstrated the problems described above, including direct EF Core access, entity exposure, synchronous operations, and hard deletion.

### After Refactoring

The refactored API demonstrates:

* DTO-based API contracts
* Service-layer business logic
* Pagination
* Projection
* Validation
* Correct HTTP responses
* Soft deletion
* Improved API behavior

> Screenshots are included in the repository as evidence of the refactoring process.

---

# 🧱 Refactoring Principles

The implementation follows several practical backend principles:

### Separation of Concerns

Each layer has a clear responsibility.

### Explicit API Contracts

DTOs define what enters and leaves the API.

### Efficient Data Access

Projection, pagination, and async EF Core operations reduce unnecessary work.

### Business Rule Enforcement

Important rules are enforced in the service layer rather than relying on the controller or client.

### Data Preservation

Soft deletion keeps historical enrollment information.

### Maintainability

The refactored structure makes future changes easier without putting all responsibilities into one controller.

---

# 🛠️ Technologies Used

* C#
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* LINQ
* DTOs
* Dependency Injection
* Async/Await
* RESTful API principles

---

# 🚀 Running the Project

### 1. Clone the repository

```bash
git clone https://github.com/Faraga169/techmaster-aspnet-backend-training.git
```

### 2. Navigate to the project

```bash
cd phase-03-real-backend-data-systems/task-07-ef-core-api-refactor-pack/EFCoreRefactoring
```

### 3. Configure the database connection

Update the connection string in the application's configuration according to your local SQL Server environment.

### 4. Apply the database configuration

If the project requires database migrations in your environment, apply the available EF Core migrations.

### 5. Run the API

```bash
dotnet run
```

### 6. Test the endpoints

Use Swagger or another API client such as Postman to test the refactored endpoints.

---

# 📋 Acceptance Criteria

| Requirement                 | Status |
| --------------------------- | ------ |
| Original bad code preserved | ✅      |
| Refactored implementation   | ✅      |
| Async EF Core methods       | ✅      |
| Correct status codes        | ✅      |
| Request DTOs                | ✅      |
| Response DTOs               | ✅      |
| Service layer               | ✅      |
| Duplicate enrollment check  | ✅      |
| Track capacity check        | ✅      |
| Payment validation          | ✅      |
| Soft delete                 | ✅      |
| Projection                  | ✅      |
| Pagination                  | ✅      |
| Improved error responses    | ✅      |
| Problems documented         | ✅      |
| Improvements documented     | ✅      |
| Before/After evidence       | ✅      |

---

# 📚 Learning Outcomes

This task provided practical experience with refactoring existing backend code rather than building a feature from scratch.

The main lessons were:

* How to identify problems in an existing EF Core API
* Why controllers should not contain business logic
* How DTOs protect API contracts
* How projection improves database queries
* Why pagination matters for scalable APIs
* How async EF Core operations improve request handling
* How to enforce business rules in a service layer
* Why soft delete can be useful for historical data
* How HTTP status codes communicate API results
* How to document technical refactoring decisions

---

# 👨‍💻 Training

**TechMaster Academy — ASP.NET Backend Career Training**

**Phase 03 — Real Backend & Data Systems**

**Task 07 — EF Core / API Refactor Pack**

The focus of this task was practical backend refactoring: taking existing bad code, identifying its problems, and transforming it into cleaner, maintainable, and review-ready API code without changing its core business purpose.
