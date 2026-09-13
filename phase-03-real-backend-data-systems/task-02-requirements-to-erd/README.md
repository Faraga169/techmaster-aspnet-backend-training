# Task 02 - Requirements to ERD

## TechMaster ASP.NET Backend Career Training

### Phase 03 - Real Backend Data Systems

---

## Task Overview

This task focuses on converting a real-world backend system requirement into a clear and structured database design.

The goal is to analyze the business requirements, identify the required entities and relationships, define primary and foreign keys, establish business rules, and produce an Entity Relationship Diagram (ERD) before starting the actual EF Core implementation.

The system is designed for **TechMaster Academy**, an internal backend system used to manage:

* Students
* Instructors
* Training Tracks
* Enrollments
* Payments

---

## Business Story

TechMaster Academy needs an internal backend system to manage its students, instructors, training tracks, enrollments, and payments.

A student can enroll in multiple training tracks, and each training track can contain multiple students.

Each enrollment stores important business information such as:

* Enrollment date
* Enrollment status
* Progress percentage
* Final result

Each training track has one main instructor, while an instructor can teach multiple training tracks.

Training tracks also contain information such as:

* Capacity
* Level
* Start date
* End date
* Status

Payments are linked to enrollments. A student may make multiple payments for an enrollment.

Each payment stores:

* Amount
* Payment method
* Payment date
* Payment status
* Reference number
* Notes

The database should also support business reporting such as active students, unpaid enrollments, track capacity, revenue by track, and instructor workload.

---

# Objectives

The main objectives of this task are:

1. Analyze the business requirements.
2. Identify the required database entities.
3. Define entity attributes.
4. Identify primary keys and foreign keys.
5. Identify relationships between entities.
6. Resolve the Student ↔ TrainingTrack many-to-many relationship.
7. Define important business rules and constraints.
8. Design a readable ERD.
9. Identify the business questions that the database must answer.
10. Prepare the database design before implementing it with EF Core.

---

# System Entities

The system contains five main entities:

1. `Student`
2. `Instructor`
3. `TrainingTrack`
4. `Enrollment`
5. `Payment`

---

# 1. Student

Represents a student registered in the academy.

### Fields

| Field       | Type      | Key / Constraint | Description                             |
| ----------- | --------- | ---------------- | --------------------------------------- |
| StudentId   | int       | PK               | Unique student identifier               |
| FullName    | string    | Required         | Student full name                       |
| Email       | string    | Required, Unique | Student email                           |
| PhoneNumber | string    | Optional         | Student phone number                    |
| CreatedAt   | DateTime  | Required         | Creation date in UTC                    |
| UpdatedAt   | DateTime? | Optional         | Last update date                        |
| IsActive    | bool      | Required         | Indicates whether the student is active |
| IsDeleted   | bool      | Required         | Soft-delete flag                        |
| DeletedAt   | DateTime? | Optional         | Soft deletion date                      |

### Relationship

A student can have many enrollments.

```text
Student 1 ───────< Enrollment
```

---

# 2. Instructor

Represents an instructor who teaches training tracks.

### Fields

| Field          | Type     | Key / Constraint | Description                  |
| -------------- | -------- | ---------------- | ---------------------------- |
| InstructorId   | int      | PK               | Unique instructor identifier |
| FullName       | string   | Required         | Instructor full name         |
| Email          | string   | Required, Unique | Instructor email             |
| Specialization | string   | Required         | Instructor specialization    |
| Bio            | string   | Optional         | Instructor biography         |
| IsActive       | bool     | Required         | Instructor active status     |
| CreatedAt      | DateTime | Required         | Creation date in UTC         |

### Relationship

One instructor can teach many training tracks.

```text
Instructor 1 ───────< TrainingTrack
```

---

# 3. TrainingTrack

Represents a training program offered by TechMaster Academy.

### Fields

| Field           | Type     | Key / Constraint | Description                |
| --------------- | -------- | ---------------- | -------------------------- |
| TrainingTrackId | int      | PK               | Unique track identifier    |
| Title           | string   | Required         | Track title                |
| Code            | string   | Required, Unique | Unique track code          |
| Description     | string   | Optional         | Track description          |
| Level           | string   | Required         | Track level                |
| Capacity        | int      | Required         | Maximum number of students |
| StartDate       | DateTime | Required         | Track start date           |
| EndDate         | DateTime | Required         | Track end date             |
| Status          | string   | Required         | Track status               |
| InstructorId    | int      | FK               | Main instructor            |
| CreatedAt       | DateTime | Required         | Creation date in UTC       |
| IsDeleted       | bool     | Required         | Soft-delete flag           |

### Relationships

A training track:

* Belongs to one instructor.
* Can have many enrollments.

```text
Instructor 1 ───────< TrainingTrack

TrainingTrack 1 ───────< Enrollment
```

---

# 4. Enrollment

`Enrollment` represents the relationship between a student and a training track.

This entity is required because the Student ↔ TrainingTrack relationship is **many-to-many** and the relationship itself contains business data.

### Fields

| Field              | Type      | Key / Constraint | Description                  |
| ------------------ | --------- | ---------------- | ---------------------------- |
| EnrollmentId       | int       | PK               | Unique enrollment identifier |
| StudentId          | int       | FK               | Enrolled student             |
| TrainingTrackId    | int       | FK               | Selected training track      |
| EnrollmentDate     | DateTime  | Required         | Enrollment date              |
| Status             | string    | Required         | Enrollment status            |
| ProgressPercentage | decimal   | Required         | Student progress             |
| FinalResult        | string    | Optional         | Final result                 |
| CreatedAt          | DateTime  | Required         | Creation date in UTC         |
| UpdatedAt          | DateTime? | Optional         | Last update date             |

### Relationships

An enrollment:

* Belongs to one student.
* Belongs to one training track.
* Can have many payments.

```text
Student 1 ───────< Enrollment >─────── 1 TrainingTrack

Enrollment 1 ───────< Payment
```

---

# 5. Payment

Represents a payment made for an enrollment.

A student does not have a direct relationship with `Payment`.

The payment belongs to an `Enrollment`, which already belongs to a student.

### Fields

| Field           | Type     | Key / Constraint | Description                    |
| --------------- | -------- | ---------------- | ------------------------------ |
| PaymentId       | int      | PK               | Unique payment identifier      |
| EnrollmentId    | int      | FK               | Related enrollment             |
| Amount          | decimal  | Required         | Payment amount                 |
| PaymentMethod   | string   | Required         | Payment method                 |
| PaymentDate     | DateTime | Required         | Payment date                   |
| PaymentStatus   | string   | Required         | Payment status                 |
| ReferenceNumber | string   | Required         | Payment reference              |
| Notes           | string   | Optional         | Additional payment information |

### Relationship

One enrollment can have many payments.

```text
Enrollment 1 ───────< Payment
```

---

# Entity Relationship Diagram

The core database relationships are:

```text
                     ┌─────────────────┐
                     │    Instructor   │
                     │-----------------│
                     │ InstructorId PK │
                     └────────┬────────┘
                              │
                              │ 1 : Many
                              ▼
                     ┌─────────────────┐
                     │ TrainingTrack   │
                     │-----------------│
                     │ TrainingTrackId │
                     │ InstructorId FK │
                     └────────┬────────┘
                              │
                              │ 1 : Many
                              ▼
┌─────────────────┐    ┌─────────────────┐
│     Student     │    │    Enrollment   │
│-----------------│    │-----------------│
│ StudentId PK    │───<│ EnrollmentId PK │
│ FullName        │ 1:M│ StudentId FK    │
│ Email           │    │ TrainingTrackFK │
└─────────────────┘    └────────┬────────┘
                                │
                                │ 1 : Many
                                ▼
                       ┌─────────────────┐
                       │     Payment     │
                       │-----------------│
                       │ PaymentId PK    │
                       │ EnrollmentId FK │
                       │ Amount          │
                       │ PaymentStatus   │
                       └─────────────────┘
```

### Simplified Relationship Model

```text
Student 1 ───────< Enrollment >─────── 1 TrainingTrack
                                          │
                                          │
                                          │ Many : 1
                                          ▼
                                      Instructor

Enrollment 1 ───────< Payment
```

---

# Relationship Explanation

## Student → Enrollment

**One-to-Many**

One student can have multiple enrollments.

Each enrollment belongs to exactly one student.

```text
Student 1 ───────< Enrollment
```

---

## TrainingTrack → Enrollment

**One-to-Many**

One training track can have multiple enrollments.

Each enrollment belongs to exactly one training track.

```text
TrainingTrack 1 ───────< Enrollment
```

---

## Student ↔ TrainingTrack

**Many-to-Many through Enrollment**

A student can enroll in many training tracks.

A training track can contain many students.

Instead of creating a direct many-to-many relationship, `Enrollment` is used as a junction entity because it contains important business data.

```text
Student
   │
   │ 1
   ▼
Enrollment
   ▲
   │ 1
   │
TrainingTrack
```

Enrollment stores information such as:

* EnrollmentDate
* Status
* ProgressPercentage
* FinalResult

Therefore, `Enrollment` is not just a linking table. It is a real business entity.

---

## Instructor → TrainingTrack

**One-to-Many**

One instructor can teach multiple training tracks.

Each training track has one main instructor.

```text
Instructor 1 ───────< TrainingTrack
```

---

## Enrollment → Payment

**One-to-Many**

One enrollment can have multiple payments.

This supports scenarios such as:

```text
Enrollment
   │
   ├── Payment 1
   ├── Payment 2
   └── Payment 3
```

This allows students to pay in installments.

---

# Primary Keys

| Entity        | Primary Key     |
| ------------- | --------------- |
| Student       | StudentId       |
| Instructor    | InstructorId    |
| TrainingTrack | TrainingTrackId |
| Enrollment    | EnrollmentId    |
| Payment       | PaymentId       |

---

# Foreign Keys

| Entity        | Foreign Key     | References                    |
| ------------- | --------------- | ----------------------------- |
| TrainingTrack | InstructorId    | Instructor.InstructorId       |
| Enrollment    | StudentId       | Student.StudentId             |
| Enrollment    | TrainingTrackId | TrainingTrack.TrainingTrackId |
| Payment       | EnrollmentId    | Enrollment.EnrollmentId       |

---

# Business Rules

The database design follows the following business rules.

### Student Rules

* Student email must be unique.
* A student can have multiple enrollments.
* Deleted students should be handled using soft delete.
* `CreatedAt` should be stored in UTC.

### Instructor Rules

* Instructor email must be unique.
* An instructor can teach multiple tracks.
* An instructor can be inactive without being deleted.

### Training Track Rules

* Track code must be unique.
* Every track must have one main instructor.
* Capacity must be greater than zero.
* End date should be after the start date.
* A track can have many enrollments.
* Deleted tracks should use soft delete.

### Enrollment Rules

* Every enrollment belongs to exactly one student.
* Every enrollment belongs to exactly one training track.
* Progress percentage should be between `0` and `100`.
* An enrollment can have multiple payments.
* A student should not have duplicate active enrollments for the same track.

### Payment Rules

* Every payment belongs to one enrollment.
* Payment amount must be greater than zero.
* Payment reference should identify the transaction.
* Multiple payments can belong to the same enrollment.

---

# Important Design Decision: Payments and Unpaid Enrollments

Payments are modeled as a separate entity instead of storing one payment amount directly inside `Enrollment`.

This allows the system to support multiple payments:

```text
Enrollment
    │
    ├── Payment 1
    ├── Payment 2
    └── Payment 3
```

However, if the system needs to calculate an exact **remaining amount**, the database also needs to know the total required amount for the enrollment or track.

For example:

```text
Total Required = 10,000
Total Paid     = 6,000
Remaining      = 4,000
```

Therefore, during the implementation phase, a field such as:

```text
Enrollment.TotalRequired
```

or

```text
TrainingTrack.Price
```

can be introduced if the business requires exact outstanding-balance calculations.

This is intentionally identified as a design consideration before EF Core implementation.

---

# Business Questions

The database design should be able to answer the following questions.

### 1. Which students are enrolled in a specific training track?

Using:

```text
Student → Enrollment → TrainingTrack
```

### 2. Which training tracks have available seats?

Using:

```text
Capacity - Active Enrollments
```

### 3. Which enrollments are unpaid?

Using enrollment and payment information.

### 4. How much revenue did each training track generate?

Using:

```text
TrainingTrack
    ↓
Enrollment
    ↓
Payment
```

and aggregating payment amounts.

### 5. Which instructor has the highest workload?

Using:

```text
Instructor → TrainingTrack → Enrollment
```

### 6. Which students have active enrollments?

Filter enrollments by their active status.

### 7. Which training tracks start this month?

Filter tracks using `StartDate`.

### 8. What is the payment history for a specific enrollment?

Using:

```text
Enrollment → Payment
```

### 9. Which training tracks are full?

Compare:

```text
Active Enrollment Count >= Capacity
```

### 10. How many enrollments exist by status?

Group enrollments by their `Status`.

---

# Suggested Database Structure

```text
Student
   │
   │ 1 : Many
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
```

And:

```text
Enrollment
   │
   │ 1 : Many
   ▼
Payment
```

---

# ERD Tool

The ERD can be created using an ERD/database modeling tool such as **dbdiagram.io**.

The purpose of the ERD is to provide a visual representation of:

* Tables
* Columns
* Primary keys
* Foreign keys
* Relationships
* Cardinality

The final ERD should be readable and clearly show all five core entities.

---

# DBML Schema

The following schema can be imported into a DBML-compatible ERD tool to generate the diagram:

```text
Table Student {
  StudentId int [pk]
  FullName varchar
  Email varchar [unique]
  PhoneNumber varchar
  CreatedAt datetime
  UpdatedAt datetime
  IsActive bool
  IsDeleted bool
  DeletedAt datetime
}

Table Instructor {
  InstructorId int [pk]
  FullName varchar
  Email varchar [unique]
  Specialization varchar
  Bio varchar
  IsActive bool
  CreatedAt datetime
}

Table TrainingTrack {
  TrainingTrackId int [pk]
  Title varchar
  Code varchar [unique]
  Description varchar
  Level varchar
  Capacity int
  StartDate datetime
  EndDate datetime
  Status varchar
  InstructorId int [ref: > Instructor.InstructorId]
  CreatedAt datetime
  IsDeleted bool
}

Table Enrollment {
  EnrollmentId int [pk]
  StudentId int [ref: > Student.StudentId]
  TrainingTrackId int [ref: > TrainingTrack.TrainingTrackId]
  EnrollmentDate datetime
  Status varchar
  ProgressPercentage decimal
  FinalResult varchar
  CreatedAt datetime
  UpdatedAt datetime
}

Table Payment {
  PaymentId int [pk]
  EnrollmentId int [ref: > Enrollment.EnrollmentId]
  Amount decimal
  PaymentMethod varchar
  PaymentDate datetime
  PaymentStatus varchar
  ReferenceNumber varchar
  Notes varchar
}
```

---

# Design Decisions

## 1. Enrollment as a Junction Entity

The relationship between students and training tracks is many-to-many.

Instead of using EF Core's automatic many-to-many relationship, `Enrollment` is explicitly modeled as an entity because the relationship contains business information.

---

## 2. Payments as a Separate Entity

Payments are separated from enrollments because one enrollment can contain multiple payments.

This supports installment-based payments and payment history.

---

## 3. Soft Delete

Students and training tracks use soft delete fields:

```text
IsDeleted
DeletedAt
```

This prevents important historical data from being physically removed from the database.

---

## 4. UTC Dates

System-generated timestamps such as:

```text
CreatedAt
UpdatedAt
DeletedAt
```

should use UTC.

This avoids problems caused by different time zones.

---

## 5. Decimal for Money

Payment amounts should use a decimal numeric type rather than floating-point values.

Example:

```text
decimal
```

This is important for financial calculations.

---

## 6. Unique Business Identifiers

The following fields should be unique:

```text
Student.Email
Instructor.Email
TrainingTrack.Code
```

This prevents duplicate business identifiers.

---

# Project Structure

```text
phase-03-real-backend-data-systems/
│
├── task-01-ef-core-modeling-drills/
│
└── task-02-requirements-to-erd/
    │
    ├── README.md
    │
    ├── ERD/
    │   └── TechMaster-Academy-ERD.png
    │
    └── Documentation/
        └── Business-Rules.md
```

The exact file structure can be adjusted depending on the final project submission requirements.

---


# Learning Outcomes

After completing this task, I should be able to:

* Read backend business requirements and extract database requirements.
* Identify entities from a real-world scenario.
* Identify relationships between entities.
* Understand one-to-one, one-to-many, and many-to-many relationships.
* Understand why some many-to-many relationships require an explicit junction entity.
* Identify primary keys and foreign keys.
* Define database constraints and business rules.
* Design an ERD before writing EF Core code.
* Translate business requirements into a relational database structure.
* Prepare a clean database model for the next implementation phase.

---

# Final Architecture

The final conceptual model is:

```text
                    Instructor
                         │
                         │ 1 : Many
                         ▼
                  TrainingTrack
                         │
                         │ 1 : Many
                         ▼
Student ───────────> Enrollment
  1                    │
                       │ 1 : Many
                       ▼
                    Payment
```

More precisely:

```text
Student 1 ───────< Enrollment >─────── 1 TrainingTrack
                                          │
                                          │
                                          ▼
                                      Instructor

Enrollment 1 ───────< Payment
```

This design provides a normalized relational structure that can later be implemented using **ASP.NET Core + EF Core + SQL Server**.
