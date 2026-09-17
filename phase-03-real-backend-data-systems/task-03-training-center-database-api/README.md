# TrainingCenter API

A layered ASP.NET Core Web API for managing a training center's core operations: **students, instructors, training tracks, enrollments, and payments**, with a dedicated reporting endpoint for business insights.

Built as part of **Phase 03 — Real Backend & Data Systems** (Task 03) of the *TechMaster ASP.NET Backend Career Training*.

## 🚀 Live Demo

The API is deployed and publicly accessible.

**Swagger UI:**
http://traningcenter.runasp.net/swagger/index.html

You can use the Swagger interface to explore and test the available API endpoints.

## Overview

TrainingCenter API models a realistic training-center domain:

* **Students** enroll in **Training Tracks**.
* Each **Training Track** is led by an **Instructor** and has a capacity, level, schedule, and status.
* **Enrollments** link a student to a track and track progress/status over time.
* **Payments** are recorded against enrollments, with method, status, and reference tracking.
* A **Reports** module exposes aggregated data for dashboards (revenue, unpaid enrollments, track capacity, etc.).

## Architecture

The solution follows a clean, 3-layer architecture:

```text
TrainingCenter.Api    → Controllers, middleware, Swagger, composition root (Program.cs)
TrainingCenter.BLL    → Business logic: Services, DTOs, AutoMapper profiles, Specifications, custom exceptions
TrainingCenter.DAL    → Data access: EF Core DbContext, Entity models, Repositories (Unit of Work), Migrations, Seeding
```

### Key Patterns Used

* **Repository + Unit of Work** for data access (`IUnitOfWork`, generic repositories)
* **Specification pattern** for composable, reusable query filters (per entity: Student, Track, Enrollment, Instructor, Payment)
* **Service layer** (`IStudentService`, `ITrackService`, `IEnrollmentService`, `IInstrcutorService`, `IPaymentService`) mediating between controllers and repositories
* **AutoMapper** for entity ↔ DTO mapping
* **Global exception handling middleware** translating `BusinessException` into consistent JSON error responses
* **DTO-per-operation** design (separate `Create`/`Update` DTOs per entity)

## Tech Stack

| Layer     | Technology                                    |
| --------- | --------------------------------------------- |
| Framework | ASP.NET Core Web API (.NET 8)                 |
| ORM       | Entity Framework Core 8 (SQL Server provider) |
| Mapping   | AutoMapper                                    |
| API Docs  | Swagger / Swashbuckle                         |
| Database  | Microsoft SQL Server                          |

## Domain Model

| Entity            | Key Fields                                                                          |
| ----------------- | ----------------------------------------------------------------------------------- |
| **Student**       | FullName, Email, PhoneNumber, IsActive                                              |
| **Instructor**    | FullName, Email, Specialization, Bio, IsActive                                      |
| **TrainingTrack** | Title, Code, Description, Level, Capacity, StartDate, EndDate, Status, InstructorId |
| **Enrollment**    | StudentId, TrainingTrackId, EnrollmentDate, Status, ProgressPercentage, FinalResult |
| **Payment**       | EnrollId, Amount, PaymentMethod, PaymentDate, Status, ReferenceNumber, Notes        |

### Enums

* `TrackLevel`: Beginner, Intermediate, Advanced
* `TrainingStatus`: Upcoming, Active, Completed, Cancelled
* `EnrollmentStatus`: Pending, Active, Completed
* `PaymentMethod`: Cash, Visa, Mastercard, BankTransfer, InstaPay
* `PaymentStatus`: Pending, Paid, Failed, Refunded

## API Endpoints

### Students — `/api/Student`

| Method | Route                           | Description                                                                                       |
| ------ | ------------------------------- | ------------------------------------------------------------------------------------------------- |
| GET    | `/api/Student`                  | List students — supports search by name, `IsActive` filter, pagination (`pagenumber`, `pagesize`) |
| GET    | `/api/Student/{id}`             | Get a student by id                                                                               |
| POST   | `/api/Student`                  | Create a student                                                                                  |
| PUT    | `/api/Student/{id}`             | Update a student                                                                                  |
| DELETE | `/api/Student/{id}`             | Delete a student                                                                                  |
| GET    | `/api/Student/{id}/enrollments` | Get a student's enrollments                                                                       |

### Instructors — `/api/Instructor`

| Method | Route                         | Description                          |
| ------ | ----------------------------- | ------------------------------------ |
| GET    | `/api/Instructor`             | List instructors                     |
| GET    | `/api/Instructor/{id}`        | Get an instructor by id              |
| POST   | `/api/Instructor`             | Create an instructor                 |
| PUT    | `/api/Instructor/{id}`        | Update an instructor                 |
| GET    | `/api/Instructor/{id}/tracks` | Get tracks assigned to an instructor |

### Training Tracks — `/api/Track`

| Method | Route                      | Description                                                |
| ------ | -------------------------- | ---------------------------------------------------------- |
| GET    | `/api/Track`               | List tracks — filter by keyword, level, status, instructor |
| GET    | `/api/Track/{id}`          | Get a track by id                                          |
| POST   | `/api/Track`               | Create a track                                             |
| PUT    | `/api/Track/{id}`          | Update a track                                             |
| DELETE | `/api/Track/{id}`          | Delete a track                                             |
| GET    | `/api/Track/{id}/students` | Get students enrolled in a track                           |

### Enrollments — `/api/Enrollment`

| Method | Route                           | Description                                                         |
| ------ | ------------------------------- | ------------------------------------------------------------------- |
| GET    | `/api/Enrollment`               | List enrollments — filter by status, track, student, payment status |
| GET    | `/api/Enrollment/{id}`          | Get an enrollment by id                                             |
| POST   | `/api/Enrollment`               | Create an enrollment                                                |
| PUT    | `/api/Enrollment/{id}/status`   | Change enrollment status                                            |
| GET    | `/api/Enrollment/{id}/payments` | Get payment history for an enrollment                               |

### Payments — `/api/Payment`

| Method | Route                      | Description                                                   |
| ------ | -------------------------- | ------------------------------------------------------------- |
| GET    | `/api/Payment`             | List payments — filter by date range (`from`/`to`) and status |
| POST   | `/api/Payment`             | Create a payment                                              |
| PUT    | `/api/Payment/{id}/status` | Update payment status                                         |

### Reports — `/api/Report`

| Method | Route                            | Description                           |
| ------ | -------------------------------- | ------------------------------------- |
| GET    | `/api/Report/dashboard-summary`  | Overall dashboard summary             |
| GET    | `/api/Report/unpaid-enrollments` | Enrollments with outstanding payments |
| GET    | `/api/Report/track-capacity`     | Track capacity vs. current enrollment |
| GET    | `/api/Report/revenue-summary`    | Revenue summary                       |
| GET    | `/api/Report/revenue-by-track`   | Revenue broken down by track          |

## Deployment

The API is deployed using **MonsterASP** and connected to a remote SQL Server database.

### Live Environment

**Swagger UI:**
http://traningcenter.runasp.net/swagger/index.html

The deployed Swagger UI provides access to the available API endpoints and can be used to test the live API.

### Production Configuration

The production database connection string is configured as an **Environment Variable** in the MonsterASP hosting environment.

It is not stored in `appsettings.json` and is not committed to the GitHub repository.

> **Security Note:** No production database credentials, passwords, or other sensitive configuration values are included in the repository.

## Getting Started

### Prerequisites

* [.NET 8 SDK](https://dotnet.microsoft.com/download)
* SQL Server (local or remote instance)
* (Optional) A REST client such as Postman or the built-in Swagger UI

### 1. Clone the Repository

```bash
git clone https://github.com/Faraga169/techmaster-aspnet-backend-training.git
cd "techmaster-aspnet-backend-training/phase-03-real-backend-data-systems/task-03-training-center-database-api"
```

### 2. Configure the Connection String

For **local development**, add an `appsettings.json` or `appsettings.Development.json` entry under `TrainingCenter.Api` with your local SQL Server connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=TrainingCenterDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

For the **production environment**, configure the connection string through the hosting provider's Environment Variables instead of storing it in the application settings file.

### 3. Apply Migrations

```bash
cd TrainingCenter.Api
dotnet ef database update
```

### 4. Run the API

```bash
dotnet run --project TrainingCenter.Api
```

The API will be available with Swagger UI enabled in the Development environment at:

```text
https://localhost:{port}/swagger
```

## Error Handling

All business-rule violations are raised as `BusinessException` and caught by a global `ExceptionHandlingMiddleware`, which returns a consistent JSON error shape with the appropriate HTTP status code.

Unhandled exceptions return `500 Internal Server Error` with a generic message.

## Author

**Ahmed Farag Fekry Dahy** — ASP.NET Backend Career Training, TechMaster
