# Drill 01 — DbContext & First Migration

## Objective

Create the first EF Core workspace and generate a real SQL Server database table using a simple `Student` entity.

## What Was Done

- Created the `Student` entity.
- Created `AppDbContext`.
- Added `DbSet<Student>`.
- Configured SQL Server connection.
- Registered `AppDbContext` in `Program.cs`.
- Created the `InitialStudentSchema` migration.
- Applied the migration to the database.
- Verified that the `Students` table exists in SQL Server.

## Student Properties

- `Id`
- `FullName`
- `Email`
- `CreatedAt`
- `IsActive`

## EF Core Commands

```bash
dotnet ef migrations add InitialStudentSchema
dotnet ef database update