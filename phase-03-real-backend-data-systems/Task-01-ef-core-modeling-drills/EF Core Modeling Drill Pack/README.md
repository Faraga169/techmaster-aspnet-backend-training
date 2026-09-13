# Task 01 - EF Core Modeling Drills

## TechMaster Academy | ASP.NET Backend Career Training

**Phase:** Phase 03 - Real Backend Data Systems
**Task:** Task 01 - EF Core Modeling Drill Pack
**Focus:** EF Core Modeling, Relationships, Migrations, Seed Data, Soft Delete, Auditing, Projection, and Pagination

---

## 📌 Task Overview

This task contains **10 focused EF Core drills**, each designed to practice one important production database concept before building the main **Training Center API**.

The drills progress from basic EF Core setup to more advanced database patterns used in real backend applications.

### Main Goals

* Understand `DbContext` and `DbSet`.
* Create and apply EF Core migrations.
* Understand and implement database relationships.
* Work with Foreign Keys and Navigation Properties.
* Model One-to-One, One-to-Many, and Many-to-Many relationships.
* Understand join entities and business data.
* Seed realistic development data.
* Implement Soft Delete.
* Implement audit fields.
* Use DTO projection with `Select`.
* Implement server-side pagination.
* Verify database schema and API behavior.

---

# 📁 Project Structure

```text
task-01-ef-core-modeling-drills/
│
├── README.md
│
├── Drill01_DbContextFirstMigration/
│
├── Drill02_OneToOneStudentProfile/
│
├── Drill03_OneToManyInstructorTracks/
│
├── Drill04_ManyToManyEnrollment/
│
├── Drill05_PaymentSummary/
│
├── Drill06_SeedData/
│
├── Drill07_SoftDelete/
│
├── Drill08_AuditFields/
│
├── Drill09_ProjectionDTO/
│
└── Drill10_Pagination/
```

Each drill contains its own implementation and the required migration/schema evidence.

---

# 🧰 Technologies Used

* C#
* ASP.NET Core
* Entity Framework Core
* SQL Server
* LINQ
* REST API
* Swagger / OpenAPI
* EF Core Migrations
* DTOs
* Dependency Injection

### Main EF Core Packages

```text
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
```

---

# 🧩 Drills Overview

| Drill | Topic                       | Main Concept                  |
| ----- | --------------------------- | ----------------------------- |
| 01    | DbContext & First Migration | DbContext / DbSet / Migration |
| 02    | Student Profile             | One-to-One                    |
| 03    | Instructor & Tracks         | One-to-Many                   |
| 04    | Enrollment                  | Many-to-Many via Join Entity  |
| 05    | Payment Summary             | One-to-One                    |
| 06    | Seed Data                   | HasData / Development Seeding |
| 07    | Soft Delete                 | IsDeleted / DeletedAt         |
| 08    | Audit Fields                | CreatedAt / UpdatedAt         |
| 09    | Projection DTO              | Select Projection             |
| 10    | Pagination                  | Skip / Take / Total Count     |

---

# 🥇 Drill 01 - DbContext & First Migration

### Concept

`DbContext` / `DbSet` / EF Core Migration

### Objective

Create the first EF Core workspace and prove that an entity can generate a real SQL Server table.

### Requirements

* Create a `Student` entity.
* Add:

  * `Id`
  * `FullName`
  * `Email`
  * `CreatedAt`
  * `IsActive`
* Create `AppDbContext`.
* Add `DbSet<Student>`.
* Configure SQL Server connection.
* Register `AppDbContext` in `Program.cs`.
* Create migration:

```text
InitialStudentSchema
```

* Apply the migration.
* Verify the `Students` table in SQL Server.

### Expected Result

```text
Migrations/
    InitialStudentSchema/
```

And SQL Server contains:

```text
Students
```

### Key Learning

`DbContext` represents the session between the application and database.

`DbSet<Student>` represents the collection/table that EF Core uses to query and persist `Student` entities.

### Evidence

* Migration files.
* SQL Server `Students` table.
* Screenshot showing successful migration.
* README explanation of `DbContext` and `DbSet`.

---

# 🥈 Drill 02 - One-to-One Student Profile

### Concept

One-to-One Relationship

### Scenario

Each student can have one student profile.

```text
Student
   │
   │ 1 : 1
   ▼
StudentProfile
```

### Requirements

Create:

```text
Student
StudentProfile
```

`StudentProfile` contains:

* `NationalId`
* `Address`
* `EmergencyPhone`
* `DateOfBirth`

The relationship must support:

```text
Student → StudentProfile
StudentProfile → Student
```

### Database Design

`StudentProfiles` should contain:

```text
StudentId FK
```

with a unique relationship.

### Migration

```text
AddStudentProfile
```

### Expected Behavior

A student can be queried with its profile:

```csharp
.Include(s => s.StudentProfile)
```

A missing profile should not cause the application to crash.

### Evidence

* ERD or database relationship screenshot.
* StudentProfiles table.
* Foreign Key evidence.

---

# 🥉 Drill 03 - One-to-Many Instructor Tracks

### Concept

One-to-Many Relationship

### Scenario

One instructor can teach many training tracks.

```text
Instructor
     │
     │ 1 : Many
     ▼
TrainingTrack
```

### Requirements

Create:

```text
Instructor
TrainingTrack
```

`TrainingTrack` must contain:

```text
InstructorId
```

as a Foreign Key.

`Instructor` contains:

```csharp
ICollection<TrainingTrack>
```

### Business Rule

A training track cannot exist without a valid instructor.

### Migration

```text
AddInstructorsAndTracks
```

### Required Endpoint

```http
GET /instructor/{id}/tracks
```

### Expected Result

The endpoint returns all tracks belonging to the instructor.

### Evidence

* Swagger endpoint screenshot.
* Database relationship screenshot.
* TrainingTracks table showing `InstructorId`.

---

# 4️⃣ Drill 04 - Many-to-Many Enrollment

### Concept

Many-to-Many Relationship through a Join Entity

### Scenario

A student can enroll in many tracks, and a track can contain many students.

```text
Student
   │
   │
   ▼
Enrollment
   ▲
   │
   │
TrainingTrack
```

### Why a Join Entity?

We do **not** use automatic EF Core many-to-many because `Enrollment` contains business data.

### Enrollment Fields

```text
StudentId
TrainingTrackId
Status
EnrollmentDate
FinalGrade
```

`FinalGrade` is optional.

### Requirements

Create:

```text
Enrollment
```

with:

```text
StudentId FK
TrainingTrackId FK
```

Add navigation collections to `Student` and `TrainingTrack`.

### Migration

```text
AddEnrollments
```

### Querying

Practice:

```csharp
Include()
ThenInclude()
```

to retrieve related enrollment information.

### Expected Behavior

Student:

```text
Student
   └── Enrollments
          └── TrainingTrack
```

Track:

```text
TrainingTrack
   └── Enrollments
          └── Student
```

### Future Business Rule

Prevent duplicate active enrollment for the same student and track.

### Evidence

* ERD.
* Enrollment table.
* Foreign Keys.
* Sample GET response.

---

# 5️⃣ Drill 05 - Payment Summary

### Concept

One-to-One Relationship

### Scenario

Each enrollment has one payment summary.

```text
Enrollment
     │
     │ 1 : 1
     ▼
PaymentSummary
```

### Requirements

Create:

```text
PaymentSummary
```

Fields:

```text
TotalRequired
TotalPaid
RemainingAmount
PaymentStatus
```

Money values must use:

```csharp
decimal
```

### Relationship

`PaymentSummary` must contain a unique:

```text
EnrollmentId FK
```

### Payment Status

Possible values:

```text
Pending
PartiallyPaid
Paid
```

### Migration

```text
AddPaymentSummary
```

### Design Consideration

The model should be extendable later to support a payment history:

```text
Enrollment
   │
   ├── PaymentSummary
   │
   └── Payments
```

### Evidence

* Database relationship.
* PaymentSummary table.
* Enrollment → PaymentSummary result.

---

# 6️⃣ Drill 06 - Seed Data

### Concept

EF Core Data Seeding

### Objective

Provide realistic initial data so the API can be tested without manually creating every record.

### Required Seed Data

At least:

```text
5 Students
2 Instructors
3 Training Tracks
5 Enrollments
```

### Possible Approaches

#### Option 1 - HasData

```csharp
modelBuilder.Entity<Student>()
    .HasData(...);
```

#### Option 2 - Development Seed Service

A development-only service can insert the initial data.

### Requirements

Seed data must be:

* Realistic.
* Repeatable.
* Documented.
* Free from duplicates.

### Expected Behavior

Restarting the application must not create duplicate records.

### Evidence

* Swagger screenshot showing seeded records.
* SQL Server screenshot showing seed rows.
* Sample IDs documented in README.

---

# 7️⃣ Drill 07 - Soft Delete

### Concept

Soft Delete

### Objective

Delete records logically instead of physically removing them from the database.

### Required Fields

```text
IsDeleted
DeletedAt
```

### Expected Delete Behavior

Instead of:

```sql
DELETE FROM Students
```

the application performs something equivalent to:

```text
IsDeleted = true
DeletedAt = current UTC time
```

### GET Behavior

Normal GET requests should exclude deleted records.

Example:

```text
GET /students
```

returns only active records.

### Optional Admin Query

Provide a way to retrieve deleted records when required.

### Migration

```text
AddSoftDeleteFields
```

### Evidence

Before deletion:

```text
IsDeleted = false
DeletedAt = null
```

After deletion:

```text
IsDeleted = true
DeletedAt = <UTC date>
```

The database row must remain.

---

# 8️⃣ Drill 08 - Audit Fields

### Concept

CreatedAt / UpdatedAt

### Objective

Track when records are created and modified.

### Required Fields

```text
CreatedAt
UpdatedAt
```

### Rules

When creating:

```text
CreatedAt = UTC now
```

When updating:

```text
UpdatedAt = UTC now
```

The client should **not** provide these values manually.

### Implementation Options

#### Service-Level

Set values inside create/update service methods.

#### SaveChanges Override

Centralize audit logic inside:

```csharp
SaveChangesAsync()
```

### Time Standard

Use:

```csharp
DateTime.UtcNow
```

rather than local server time.

### Expected Behavior

Create:

```text
CreatedAt → populated
```

Update:

```text
UpdatedAt → changed
```

### Evidence

* API response.
* Database screenshot.
* Before/after update evidence.

---

# 9️⃣ Drill 09 - Projection DTO

### Concept

LINQ `Select` Projection

### Objective

Return DTOs instead of exposing EF Core entities directly.

### Required DTOs

```text
StudentListItemDto
TrackDetailsDto
```

### Example

Instead of returning the entire entity:

```csharp
_context.Students.ToList();
```

use projection:

```csharp
_context.Students
    .Select(s => new StudentListItemDto
    {
        Id = s.Id,
        FullName = s.FullName,
        Email = s.Email
    });
```

### Important Rule

Return only the fields required by the use case.

### Avoid

Large navigation-heavy entity graphs.

### Projection Advantage

Projection allows EF Core to generate a query that selects only the required columns.

### Expected Behavior

List endpoint:

```text
Small DTO response
```

Details endpoint:

```text
Only required related information
```

Internal entity fields must not accidentally appear in API responses.

### Evidence

* Swagger response.
* DTO code.
* Projection code.

---

# 🔟 Drill 10 - Pagination

### Concept

`Skip` / `Take` / `Count`

### Objective

Implement proper server-side pagination for a listing endpoint.

### Query Parameters

```http
?pageNumber=1&pageSize=5
```

### Validation

`pageNumber` must be:

```text
>= 1
```

`pageSize` must be:

```text
1 - 50
```

### Pagination Formula

```text
skip = (pageNumber - 1) × pageSize
```

Example:

```text
pageNumber = 3
pageSize = 5

skip = (3 - 1) × 5
     = 10
```

### Required Response

The response must contain:

```text
items
totalCount
pageNumber
pageSize
totalPages
```

### Recommended DTO

```text
PaginationResult<T>
```

### Recommended EF Core Flow

```csharp
var totalCount = await query.CountAsync();

var items = await query
    .Skip((pageNumber - 1) * pageSize)
    .Take(pageSize)
    .ToListAsync();
```

### Important Performance Rule

Do not load all records before calling `Skip()` and `Take()`.

❌ Avoid:

```csharp
var data = await query.ToListAsync();

var result = data
    .Skip(...)
    .Take(...);
```

✅ Prefer:

```csharp
var result = await query
    .Skip(...)
    .Take(...)
    .ToListAsync();
```

This allows SQL Server to perform the pagination.

### Expected Test Cases

```text
?pageNumber=1&pageSize=5
```

→ `200 OK`

```text
?pageNumber=0&pageSize=5
```

→ `400 Bad Request`

```text
?pageNumber=1&pageSize=100
```

→ `400 Bad Request`

### Evidence

* Swagger request.
* Swagger response.
* Pagination metadata.
* README formula explanation.

---

# 🔗 Relationship Summary

The complete model developed throughout the drills can be visualized as:

```text
Student
   │
   ├─────────────── 1 : 1 ──────────────── StudentProfile
   │
   │
   └─────────────── 1 : Many
                         │
                         ▼
                    Enrollment
                         │
                         │ Many : 1
                         ▼
                   TrainingTrack
                         │
                         │ Many : 1
                         ▼
                     Instructor


Enrollment
    │
    │ 1 : 1
    ▼
PaymentSummary
```

A simplified relationship view:

```text
Student
  │
  ├── StudentProfile
  │
  └── Enrollment
          │
          ├── TrainingTrack
          │       └── Instructor
          │
          └── PaymentSummary
```

---

# 🗃️ Database Concepts Covered

By completing this task, the following EF Core concepts are practiced:

### Core EF Core

* `DbContext`
* `DbSet`
* Entity Configuration
* Connection Strings
* Dependency Injection
* Migrations
* Database Updates

### Relationships

* One-to-One
* One-to-Many
* Many-to-Many
* Join Entities
* Foreign Keys
* Navigation Properties
* Collection Navigation Properties

### Querying

* `Include`
* `ThenInclude`
* `Select`
* `Skip`
* `Take`
* `Count`
* LINQ

### Production Patterns

* DTOs
* Data Seeding
* Soft Delete
* Audit Fields
* UTC timestamps
* Pagination
* Business Validation

---

# 🧪 Evidence Checklist

Each drill should provide evidence proving that the required behavior works.

| Drill | Required Evidence                        | Status |
| ----- | ---------------------------------------- | ------ |
| 01    | Migration + Students table               | ⬜      |
| 02    | One-to-One database relationship         | ⬜      |
| 03    | Instructor/Track relationship + endpoint | ⬜      |
| 04    | Enrollment ERD + table + GET response    | ⬜      |
| 05    | PaymentSummary relationship              | ⬜      |
| 06    | Seeded database records                  | ⬜      |
| 07    | Soft-delete before/after evidence        | ⬜      |
| 08    | CreatedAt/UpdatedAt evidence             | ⬜      |
| 09    | DTO response + projection code           | ⬜      |
| 10    | Swagger pagination + metadata            | ⬜      |

---

# 🧱 Recommended Development Order

The drills should be completed in the following order:

```text
Drill 01
   ↓
Drill 02
   ↓
Drill 03
   ↓
Drill 04
   ↓
Drill 05
   ↓
Drill 06
   ↓
Drill 07
   ↓
Drill 08
   ↓
Drill 09
   ↓
Drill 10
```

Each group builds on concepts introduced earlier.

---

# 🔄 Migration Strategy

Each database schema change should be represented by an EF Core migration.

Example:

```bash
dotnet ef migrations add InitialStudentSchema
dotnet ef database update
```

Then later:

```bash
dotnet ef migrations add AddStudentProfile
dotnet ef database update
```

And similarly for the remaining schema changes.

### Migration Naming

Recommended names:

```text
InitialStudentSchema
AddStudentProfile
AddInstructorsAndTracks
AddEnrollments
AddPaymentSummary
AddSeedData
AddSoftDeleteFields
AddAuditFields
```

---

# 📸 Documentation & Evidence

Database screenshots are stored separately in the project documentation/Drive as required.

Evidence should demonstrate:

1. Database tables exist.
2. Foreign Keys are correctly configured.
3. Relationships match the intended model.
4. Seed data exists.
5. Soft Delete keeps records in the database.
6. Audit fields are populated.
7. DTO projection returns the intended shape.
8. Pagination returns correct metadata.

---

# 📦 Commit Strategy

Commits should be made after every **2–3 drills** to keep the development history clear.

Example:

```text
feat: complete EF Core drills 01-03
feat: complete EF Core drills 04-06
feat: complete EF Core drills 07-08
feat: complete EF Core drills 09-10
```

---

# 🎯 Final Learning Outcomes

After completing this task, I should be able to:

* Create an EF Core `DbContext`.
* Configure SQL Server.
* Create and apply migrations.
* Design database relationships.
* Configure Foreign Keys.
* Use Navigation Properties.
* Understand One-to-One relationships.
* Understand One-to-Many relationships.
* Implement Many-to-Many relationships using a Join Entity.
* Query related data using `Include` and `ThenInclude`.
* Seed development data safely.
* Implement Soft Delete.
* Track entity creation and modification times.
* Use DTO projection with `Select`.
* Build server-side pagination.
* Validate pagination parameters.
* Understand the difference between database-side and memory-side operations.
* Verify database changes using SQL Server and API responses.

---

# 🚀 Preparation for the Training Center API

These drills form the database foundation for the upcoming **Training Center API**.

The final project will build on the same concepts:

```text
Students
   │
   ├── Profiles
   │
   └── Enrollments
          │
          ├── Tracks
          │      └── Instructors
          │
          └── Payment Summaries
```

The purpose of this drill pack is not only to make the API work, but to understand **why the database is modeled this way and how EF Core translates that model into a real SQL Server database**.

---

## ✅ Task Completion

```text
[ ] Drill 01 - DbContext & First Migration
[ ] Drill 02 - One-to-One Student Profile
[ ] Drill 03 - One-to-Many Instructor Tracks
[ ] Drill 04 - Many-to-Many Enrollment
[ ] Drill 05 - Payment Summary
[ ] Drill 06 - Seed Data
[ ] Drill 07 - Soft Delete
[ ] Drill 08 - Audit Fields
[ ] Drill 09 - Projection DTO
[ ] Drill 10 - Pagination
```

### Task Status

**10 / 10 Drills Required**

**Phase 03 - Real Backend Data Systems**
