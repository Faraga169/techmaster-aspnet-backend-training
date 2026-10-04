# \# TrainingCenter API

# 

# A layered, \*\*secured\*\* ASP.NET Core Web API for managing a training center's core operations: \*\*students, instructors, training tracks, sessions, enrollments, and payments\*\*, with JWT authentication, role-based authorization, ownership rules, an audit trail, and a dedicated reporting module for admins.

# 

# Built as part of the \*TechMaster ASP.NET Backend Career Training\*:

# 

# \* \*\*Phase 03 — Real Backend \& Data Systems:\*\* the data-driven API (EF Core, SQL Server, layered architecture).

# \* \*\*Phase 04 — Secure Professional Backend:\*\* authentication, authorization, audit trail, global error handling, logging, and redeployment.

# 

# \## 🚀 Live Demo

# 

# \*\*Swagger UI:\*\*

# http://traningcenter.runasp.net/swagger/index.html

# 

# Use the Swagger interface to explore and test the available endpoints. Most endpoints now require a JWT token (see \[Testing Secured Endpoints](#testing-secured-endpoints)).

# 

# \## Overview

# 

# TrainingCenter API models a realistic training-center domain with three kinds of users:

# 

# \* \*\*Admin\*\* manages students, instructors, tracks, enrollments, and payments, and views reports and the audit log.

# \* \*\*Instructor\*\* manages their own tracks' sessions and sees the students and progress of the tracks assigned to them.

# \* \*\*Student\*\* manages their own profile, requests enrollment in available tracks, and views their own enrollments, payments, and sessions.

# 

# Business operations are tied to the authenticated user, so every sensitive action is attributable and logged.

# 

# \## What's New in Phase 04

# 

# | Area | What was added |

# | ---- | -------------- |

# | \*\*Authentication\*\* | ASP.NET Core Identity + JWT Bearer tokens, register / login / current user / change password |

# | \*\*Refresh tokens\*\* | Persisted refresh tokens (7-day lifetime) with rotation on refresh and revocation on login/logout |

# | \*\*Authorization\*\* | Three roles — `Admin`, `Instructor`, `Student` — enforced with `\[Authorize(Roles = "...")]` |

# | \*\*Ownership rules\*\* | Instructors only access their own tracks/sessions; students only see their own enrollments, payments, and sessions |

# | \*\*Audit trail\*\* | `ActivityLog` records who did what (user, role, action, entity, IP address, timestamp), queryable by admins |

# | \*\*Global error handling\*\* | `ExceptionHandlingMiddleware` + custom `BusinessException` → consistent JSON errors |

# | \*\*Consistent responses\*\* | `ApiResponse<T>`, `PaginatedResult<T>`, and `ValidationErrorResponse` wrappers |

# | \*\*Custom 401 / 403 responses\*\* | JSON bodies instead of empty responses for unauthenticated / unauthorized requests |

# | \*\*Structured logging\*\* | `ILogger` events for registration, login success/failure, inactive-account attempts |

# | \*\*Session management\*\* | Instructors create, update, and complete track sessions |

# | \*\*Extended reports\*\* | Top tracks, instructor workload, students without payments, track level summary |

# | \*\*Identity seeding\*\* | Roles and demo users seeded on startup |

# | \*\*Security config\*\* | Secrets are not stored in the repo (see \[Configuration](#2-configure-settings)) |

# 

# \## Architecture

# 

# The solution follows a clean, 3-layer architecture:

# 

# ```text

# TrainingCenter.Api    → Controllers, middleware, authentication/validation extensions, Swagger, composition root (Program.cs)

# TrainingCenter.BLL    → Business logic: Services, DTOs, AutoMapper profiles, Specifications, common response models, custom exceptions

# TrainingCenter.DAL    → Data access: EF Core DbContext (Identity-enabled), Entity models, Repositories (Unit of Work), Migrations, Seeding

# ```

# 

# \### Key Patterns Used

# 

# \* \*\*Repository + Unit of Work\*\* for data access (`IUnitOfWork`, generic and specialized repositories), including transaction support

# \* \*\*Specification pattern\*\* for composable, reusable query filters (Student, Track, Enrollment, Instructor, Payment, Session, Audit log)

# \* \*\*Service layer\*\* mediating between controllers and repositories (`IAuthenticationService`, `IStudentService`, `IInstrcutorService`, `ITrackService`, `ITrackSession`, `IEnrollmentService`, `IPaymentService`, `IReportService`, `IActivityLogService`)

# \* \*\*AutoMapper\*\* for entity ↔ DTO mapping

# \* \*\*Global exception handling middleware\*\* translating `BusinessException` into consistent JSON error responses

# \* \*\*DTO-per-operation\*\* design (separate `Create` / `Update` DTOs per entity)

# \* \*\*Extension-method composition\*\* (`AddApplicationServices`, `AddAuthenticationServices`, `AddCustomValidation`) to keep `Program.cs` clean

# 

# \## Tech Stack

# 

# | Layer          | Technology                                                  |

# | -------------- | ----------------------------------------------------------- |

# | Framework      | ASP.NET Core Web API (.NET 8)                               |

# | ORM            | Entity Framework Core 8 (SQL Server provider)               |

# | Authentication | ASP.NET Core Identity + JWT Bearer (`Microsoft.AspNetCore.Authentication.JwtBearer`) |

# | Mapping        | AutoMapper                                                  |

# | API Docs       | Swagger / Swashbuckle                                       |

# | Database       | Microsoft SQL Server                                        |

# 

# \## Domain Model

# 

# | Entity              | Key Fields                                                                          |

# | ------------------- | ----------------------------------------------------------------------------------- |

# | \*\*ApplicationUser\*\* | Identity user with `IsActive`, `CreatedAt`, `LastLoginAt`                           |

# | \*\*Student\*\*         | FullName, Email, PhoneNumber, IsActive, UserId                                      |

# | \*\*Instructor\*\*      | FullName, Email, Specialization, Bio, IsActive, UserId                              |

# | \*\*TrainingTrack\*\*   | Title, Code, Description, Level, Capacity, StartDate, EndDate, Status, InstructorId |

# | \*\*TrackSession\*\*    | Title, Description, MeetingLink, SessionDate, IsCompleted, TrackId, CreatedByInstructorId |

# | \*\*Enrollment\*\*      | StudentId, TrainingTrackId, EnrollmentDate, Status, ProgressPercentage, FinalResult |

# | \*\*Payment\*\*         | EnrollId, Amount, PaymentMethod, PaymentDate, Status, ReferenceNumber, Notes        |

# | \*\*RefreshToken\*\*    | Token, UserId, ExpiresAt, IsRevoked                                                 |

# | \*\*ActivityLog\*\*     | UserId, UserRole, Action, EntityName, EntityId, Description, CreatedAt, IpAddress, Metadata |

# 

# \### Enums

# 

# \* `TrackLevel`: Beginner, Intermediate, Advanced

# \* `TrainingStatus`: Upcoming, Active, Completed, Cancelled

# \* `EnrollmentStatus`: Pending, Active, Completed

# \* `PaymentMethod`: Cash, Visa, Mastercard, BankTransfer, InstaPay

# \* `PaymentStatus`: Pending, Paid, Failed, Refunded

# 

# \## Roles \& Permissions

# 

# | Capability | Admin | Instructor | Student |

# | ---------- | :---: | :--------: | :-----: |

# | Register / login / refresh token / change password | ✅ | ✅ | ✅ |

# | Manage students | ✅ | ❌ | ❌ |

# | Manage instructors | ✅ | ❌ | ❌ |

# | Create / delete tracks, assign instructors | ✅ | ❌ | ❌ |

# | View / update a track | ✅ | Own tracks only (limited fields) | ❌ |

# | View students and progress of a track | ✅ | Own tracks only | ❌ |

# | Browse available tracks | ❌ | ❌ | ✅ |

# | Create / update / complete sessions | ❌ | Own tracks only | ❌ |

# | Manage enrollments and payments | ✅ | ❌ | ❌ |

# | Request enrollment, view own enrollments / payments / sessions | ❌ | ❌ | ✅ |

# | Reports and audit log | ✅ | ❌ | ❌ |

# 

# \### Ownership \& Business Rules

# 

# \* An instructor can only see and modify tracks assigned to them, and only add sessions to their own tracks.

# \* An instructor cannot change a track's \*\*code\*\*, \*\*price\*\*, \*\*status\*\*, or \*\*assigned instructor\*\*; those are admin-only changes.

# \* A student can only view their own enrollments, payments, and sessions.

# \* Inactive accounts cannot log in (`403`).

# \* Public registration always creates a \*\*Student\*\* account; Admin and Instructor accounts are not self-service.

# 

# \## API Endpoints

# 

# Every endpoint below requires a valid JWT unless marked \*\*Public\*\*. Role requirements are listed per endpoint.

# 

# \### Authentication — `/api/Authenticate`

# 

# | Method | Route                                | Description                                     | Access        |

# | ------ | ------------------------------------ | ----------------------------------------------- | ------------- |

# | POST   | `/api/Authenticate/register`         | Register a new student account                  | Public        |

# | POST   | `/api/Authenticate/login`            | Login and receive access + refresh tokens       | Public        |

# | POST   | `/api/Authenticate/refresh-token`    | Exchange a refresh token for a new token pair   | Public        |

# | GET    | `/api/Authenticate/me`               | Get the current authenticated user              | Authenticated |

# | POST   | `/api/Authenticate/change-password`  | Change the current user's password              | Authenticated |

# | POST   | `/api/Authenticate/logout`           | Log out (revokes the refresh token)             | Authenticated |

# 

# \### Admin — Students — `/api/admin/students`

# 

# | Method | Route                                  | Description                                  |

# | ------ | -------------------------------------- | -------------------------------------------- |

# | GET    | `/api/admin/students`                  | List students (search, active filter, pagination) |

# | GET    | `/api/admin/students/{id}`             | Get a student by id                          |

# | POST   | `/api/admin/students`                  | Create a student                             |

# | PUT    | `/api/admin/students/{id}`             | Update a student                             |

# | DELETE | `/api/admin/students/{id}`             | Delete a student                             |

# | GET    | `/api/admin/students/{id}/enrollments` | Get a student's enrollments                  |

# 

# \### Admin — Instructors — `/api/admin/instructors`

# 

# | Method | Route                                 | Description                          |

# | ------ | ------------------------------------- | ------------------------------------ |

# | GET    | `/api/admin/instructors`              | List instructors                     |

# | GET    | `/api/admin/instructors/{id}`         | Get an instructor by id              |

# | POST   | `/api/admin/instructors`              | Create an instructor                 |

# | PUT    | `/api/admin/instructors/{id}`         | Update an instructor                 |

# | GET    | `/api/admin/instructors/{id}/tracks`  | Get tracks assigned to an instructor |

# 

# \### Admin — Enrollments — `/api/admin/enrollment`

# 

# | Method | Route                                | Description                                                  |

# | ------ | ------------------------------------ | ------------------------------------------------------------ |

# | GET    | `/api/admin/enrollment`              | List enrollments — filter by status, track, student, payment status |

# | GET    | `/api/admin/enrollment/{id}`         | Get an enrollment by id                                      |

# | POST   | `/api/admin/enrollment`              | Create an enrollment                                         |

# | PUT    | `/api/admin/enrollment/{id}/status`  | Change enrollment status                                     |

# 

# \### Admin — Payments — `/api/admin/payments`

# 

# | Method | Route                               | Description                                      |

# | ------ | ----------------------------------- | ------------------------------------------------ |

# | GET    | `/api/admin/payments`               | List payments — filter by date range and status  |

# | POST   | `/api/admin/payments`               | Create a payment                                 |

# | PUT    | `/api/admin/payments/{id}/status`   | Update payment status                            |

# | GET    | `/api/admin/payments/{enrollid}`    | Get payment history for an enrollment            |

# 

# \### Admin — Reports — `/api/admin/reports`

# 

# | Method | Route                                         | Description                           |

# | ------ | --------------------------------------------- | ------------------------------------- |

# | GET    | `/api/admin/reports/dashboard-summary`        | Overall dashboard summary             |

# | GET    | `/api/admin/reports/unpaid-enrollments`       | Enrollments with outstanding payments |

# | GET    | `/api/admin/reports/track-capacity`           | Track capacity vs. current enrollment |

# | GET    | `/api/admin/reports/revenue-summary`          | Revenue summary                       |

# | GET    | `/api/admin/reports/revenue-by-track`         | Revenue broken down by track          |

# | GET    | `/api/admin/reports/top-tracks`               | Top tracks                            |

# | GET    | `/api/admin/reports/instructor-workload`      | Instructor workload                   |

# | GET    | `/api/admin/reports/students-without-payments`| Students with no payments             |

# 

# \### Admin — Audit Log — `/api/admin/ActivityLogs`

# 

# | Method | Route                     | Description                                                                 |

# | ------ | ------------------------- | --------------------------------------------------------------------------- |

# | GET    | `/api/admin/ActivityLogs` | Browse the audit trail — filter by `userId`, `entityName`, `from`/`to`, with pagination |

# 

# \### Tracks — `/api/Track`

# 

# | Method | Route                              | Description                                      | Access              |

# | ------ | ---------------------------------- | ------------------------------------------------ | ------------------- |

# | GET    | `/api/Track`                       | List tracks — filter by keyword, level, status, instructor | Admin       |

# | GET    | `/api/Track/available`             | List tracks open for enrollment                  | Student             |

# | GET    | `/api/Track/{id}`                  | Get a track by id                                | Admin, Instructor   |

# | POST   | `/api/Track`                       | Create a track                                   | Admin               |

# | PUT    | `/api/Track/{id}`                  | Update a track (instructors: limited fields)     | Admin, Instructor   |

# | PUT    | `/api/Track/{id}/assign-instructor`| Assign an instructor to a track                  | Admin               |

# | DELETE | `/api/Track/{id}`                  | Delete a track                                   | Admin               |

# | GET    | `/api/Track/{id}/students`         | Get students enrolled in a track                 | Admin, Instructor   |

# | GET    | `/api/Track/{id}/progress`         | Get track level / progress summary               | Admin, Instructor   |

# 

# \### Instructor — `/api/instructor`  \*(Instructor role)\*

# 

# | Method | Route                                     | Description                          |

# | ------ | ----------------------------------------- | ------------------------------------ |

# | GET    | `/api/instructor/my-tracks`               | Tracks assigned to the current instructor |

# | POST   | `/api/instructor/tracks/{id}/sessions`    | Create a session in one of my tracks |

# | PUT    | `/api/instructor/sessions/{id}`           | Update a session                     |

# | PUT    | `/api/instructor/sessions/{id}/complete`  | Mark a session as completed          |

# | GET    | `/api/instructor/my-sessions`             | Sessions created by the current instructor |

# 

# \### Student — `/api/student`  \*(Student role)\*

# 

# | Method | Route                                | Description                                |

# | ------ | ------------------------------------ | ------------------------------------------ |

# | GET    | `/api/student/me`                    | Get my profile                             |

# | PUT    | `/api/student/me`                    | Update my profile                          |

# | GET    | `/api/student/my-enrollments`        | My enrollments                             |

# | POST   | `/api/student/enrollment-request`    | Request enrollment in a track              |

# | GET    | `/api/student/my-payments`           | My payments                                |

# | GET    | `/api/student/my-sessions`           | Sessions of the tracks I'm enrolled in     |

# 

# \## Authentication Flow

# 

# 1\. \*\*Register\*\* (`POST /api/Authenticate/register`) creates a Student account and a linked Student profile in a single transaction.

# 2\. \*\*Login\*\* (`POST /api/Authenticate/login`) returns an `accessToken` (JWT) and a `refreshToken`. Any previously active refresh token for the user is revoked.

# 3\. Send the access token on every request: `Authorization: Bearer <accessToken>`.

# 4\. When the access token expires, call \*\*refresh-token\*\* with the refresh token to receive a new pair. The old refresh token is revoked (rotation).

# 5\. \*\*Logout\*\* revokes the refresh token.

# 

# Unauthenticated requests return `401` and requests with the wrong role return `403`, both with a consistent JSON body:

# 

# ```json

# {

# &#x20; "success": false,

# &#x20; "message": "You are not authorized to access this resource.",

# &#x20; "statusCode": 403

# }

# ```

# 

# \## Audit Trail

# 

# Sensitive actions (such as registration and login) write an `ActivityLog` entry containing the acting user, their role, the action, the affected entity, a description, the IP address, and a timestamp. Admins can search the trail through `GET /api/admin/ActivityLogs`.

# 

# \## Error Handling

# 

# All business-rule violations are raised as `BusinessException` (with an HTTP status code) and caught by the global `ExceptionHandlingMiddleware`, which returns a consistent JSON error shape.

# 

# \* \*\*Validation errors\*\* (`400`) return a `ValidationErrorResponse` listing the errors per field.

# \* \*\*Authentication / authorization errors\*\* return `401` / `403` with a JSON body.

# \* \*\*Unhandled exceptions\*\* return `500 Internal Server Error` with a generic message.

# 

# \## Deployment

# 

# The API is deployed using \*\*MonsterASP\*\* and connected to a remote SQL Server database.

# 

# \*\*Swagger UI:\*\*

# http://traningcenter.runasp.net/swagger/index.html

# 

# \### Production Configuration

# 

# The production \*\*database connection string\*\* and the \*\*JWT settings\*\* (`JWT:Key`, `JWT:Issuer`, `JWT:Audience`) are configured as \*\*Environment Variables\*\* in the hosting environment.

# 

# They are not stored in `appsettings.json` and are not committed to the GitHub repository.

# 

# > \*\*Security Note:\*\* No production database credentials, JWT signing keys, or other sensitive configuration values are included in the repository.

# 

# \## Getting Started

# 

# \### Prerequisites

# 

# \* \[.NET 8 SDK](https://dotnet.microsoft.com/download)

# \* SQL Server (local or remote instance)

# \* `dotnet-ef` tool: `dotnet tool install --global dotnet-ef`

# \* (Optional) A REST client such as Postman, or the built-in Swagger UI

# 

# \### 1. Clone the Repository

# 

# ```bash

# git clone https://github.com/Faraga169/techmaster-aspnet-backend-training.git

# cd "techmaster-aspnet-backend-training/Phase-04-secure-professional-backend"

# ```

# 

# \### 2. Configure Settings

# 

# For \*\*local development\*\*, add the connection string and JWT settings under `TrainingCenter.Api` using `appsettings.Development.json` or, preferably, \[User Secrets](https://learn.microsoft.com/aspnet/core/security/app-secrets):

# 

# ```json

# {

# &#x20; "ConnectionStrings": {

# &#x20;   "DefaultConnection": "Server=.;Database=TrainingCenterDb;Trusted\_Connection=True;TrustServerCertificate=True"

# &#x20; },

# &#x20; "JWT": {

# &#x20;   "Issuer": "TrainingCenterApi",

# &#x20;   "Audience": "TrainingCenterClients",

# &#x20;   "Key": "<a-long-random-secret-at-least-32-characters>"

# &#x20; }

# }

# ```

# 

# ```bash

# cd TrainingCenter.Api

# dotnet user-secrets set "JWT:Key" "<a-long-random-secret-at-least-32-characters>"

# ```

# 

# For the \*\*production environment\*\*, use the hosting provider's Environment Variables (`ConnectionStrings\_\_DefaultConnection`, `JWT\_\_Key`, `JWT\_\_Issuer`, `JWT\_\_Audience`).

# 

# \### 3. Apply Migrations

# 

# From the `Phase-04-secure-professional-backend` folder:

# 

# ```bash

# dotnet ef database update --project TrainingCenter.DAL --startup-project TrainingCenter.Api

# ```

# 

# \### 4. Run the API

# 

# ```bash

# dotnet run --project TrainingCenter.Api

# ```

# 

# On startup the API seeds the three roles and demo users (see below). Swagger UI is available at:

# 

# ```text

# https://localhost:{port}/swagger

# ```

# 

# \## Testing Secured Endpoints

# 

# 1\. Call `POST /api/Authenticate/login` with one of the seeded accounts (or register a new student).

# 2\. Copy the `accessToken` from the response.

# 3\. In Swagger UI, click \*\*Authorize\*\* and enter `Bearer <accessToken>`.

# 4\. Call the endpoints allowed for that role.

# 

# \### Seeded Demo Accounts

# 

# | Role       | Email                        |

# | ---------- | ---------------------------- |

# | Admin      | `admin@techmaster.com`       |

# | Instructor | `instructor@techmaster.com`  |

# | Student    | `student@techmaster.com`     |

# 

# > These are demo accounts created by `IdentitySeeder` for development and review. Change or disable them before using the API with real data.

# 

# \## Author

# 

# \*\*Ahmed Farag Fekry Dahy\*\* — ASP.NET Backend Career Training, TechMaster

