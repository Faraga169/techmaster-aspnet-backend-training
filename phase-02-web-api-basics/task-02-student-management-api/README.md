# Student Management API

A simple ASP.NET Core Web API for managing students.

This project was developed as part of **Phase 02 — ASP.NET Core Web API Basics**.

The main goal of this phase is to practice building RESTful APIs using ASP.NET Core, DTOs, Services, LINQ, filtering, pagination, custom exceptions, and middleware.

---

## Features

- Create a student
- Get student by ID
- Get all students
- Search students by name
- Filter students by email
- Filter students by track
- Filter students by active status
- Pagination
- Update student information
- Update student active status
- Get student statistics
- Custom exception handling middleware
- Business exception handling
- DTO-based requests and responses
- In-memory data storage

---

## Technologies

- C#
- ASP.NET Core Web API
- .NET
- LINQ
- REST API
- Postman

---

## Project Structure

```text
StudentManagementAPI
│
├── Controllers
│   └── StudentController.cs
│
├── DTOS
│   ├── CreateStudentRequest.cs
│   ├── UpdateStudentRequest.cs
│   ├── UpdateStudentStatusRequest.cs
│   ├── StudentResponse.cs
│   ├── PagedResultResponse.cs
│   ├── StudentStatsResponse.cs
│   └── TrackStatsResponse.cs
│
├── Exceptions
│   └── BusinessException.cs
│
├── Middleware
│   └── ExceptionHandlingMiddleware.cs
│
├── Models
│   └── Student.cs
│
├── Seeding
│   └── StudentSeeding.cs
│
├── Services
│   ├── IStudentService.cs
│   └── StudentService.cs
│
└── Program.cs