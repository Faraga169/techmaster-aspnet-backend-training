# Employee Management Console App

A simple **C# Console Application** that simulates an internal HR Employee Management System.

The project is designed to practice **Collections, LINQ, Search, Filtering, Sorting, CRUD operations, Validation, and Reporting** in a clean service-based structure.

## Features

* Add Employee
* Update Employee
* Deactivate Employee
* Search Employee

  * By Employee ID
  * By Full Name
  * By Partial Name
* Filter Employees by Department
* Sort Employees

  * Salary Ascending
  * Salary Descending
  * Hire Date Ascending
  * Hire Date Descending
  * Name Ascending
* Salary Reports

  * Average Salary
  * Highest Salary Employee
  * Lowest Salary Employee
  * Total Payroll
  * Employees Count by Department
  * Active / Inactive Employees
* View All Employees

## Employee Information

Each employee contains:

* Employee ID
* Full Name
* Email
* Department
* Position
* Salary
* Hire Date
* Phone Number
* Manager Name
* Active / Inactive Status
* Creation Date

## Departments

The application currently supports:

```text
IT
Marketing
Software
Sales
```

## Project Structure

```text
Employee Management
│
├── Models
│   ├── Employee.cs
│   └── Department.cs
│
├── Services
│   ├── EmployeeService.cs
│   ├── EmployeeReportService.cs
│   └── EmployeeSeeding.cs
│
├── UI
│   └── ConsoleMenu.cs
│
└── Program.cs
```

## Main Menu

```text
====== Employee Management System ======
1. Add Employee
2. Update Employee
3. Deactivate Employee
4. Search Employee
5. Filter by Department
6. Sort Employees
7. Show Salary Reports
8. View All Employees
9. Exit
   Choose an option:
```

## Validation

The application validates important business rules, including:

* Employee ID must be unique.
* Employee cannot be null.
* Salary cannot be negative.
* Hire date cannot be in the future.
* Department must be valid.
* Employee must exist before updating or deactivating.
* Search must return an existing employee.
* Invalid menu options are rejected.

## LINQ Concepts Used

The project uses LINQ extensively for searching, filtering, sorting, grouping, and reporting.

### Search

```csharp
Employees.Find(e => e.EmployeeId == employeeId);
```

### Filtering

```csharp
Employees
    .Where(e => e.Department == department && e.IsActive)
    .ToList();
```

### Sorting

```csharp
Employees.OrderBy(e => e.Salary).ToList();

Employees.OrderByDescending(e => e.Salary).ToList();
```

### Grouping

```csharp
Employees
    .GroupBy(e => e.Department)
    .Select(g => new
    {
        Department = g.Key,
        Count = g.Count()
    });
```

### Salary Calculations

```csharp
Employees.Average(e => e.Salary);

Employees.Sum(e => e.Salary);

Employees.MaxBy(e => e.Salary);

Employees.MinBy(e => e.Salary);
```

## Exception Handling

The project uses different exception types according to the situation:

* `ArgumentNullException` for null arguments.
* `ArgumentException` for invalid argument values.
* `ArgumentOutOfRangeException` for values outside an allowed range.
* `InvalidOperationException` when an operation cannot be performed because of the current application state.

## Design Approach

The application separates responsibilities between different layers:

```text
Console / UI
     ↓
EmployeeService
     ↓
Employee Model
     ↓
Employee Data
```

The `Program` and `ConsoleMenu` handle user input and display.

`EmployeeService` handles employee-related business operations.

`EmployeeReportService` handles salary and employee reports.

`Employee` contains its own update and validation behavior.

## Technologies

* C#
* .NET
* Console Application
* LINQ
* Generic Collections
* OOP
* Enums
* Exception Handling

## How to Run

From the project directory:

```bash
dotnet run
```

Or run the project directly:

```bash
dotnet run --project "task-03-employee-management.csproj"
```

## Learning Goals

This project was built to practice:

* Object-Oriented Programming
* Encapsulation
* Collections
* `List<T>`
* LINQ
* `Find`
* `Where`
* `OrderBy`
* `OrderByDescending`
* `GroupBy`
* `Select`
* `Sum`
* `Average`
* `MaxBy`
* `MinBy`
* Exception Handling
* Separation of Concerns
* Basic Service Layer Architecture
