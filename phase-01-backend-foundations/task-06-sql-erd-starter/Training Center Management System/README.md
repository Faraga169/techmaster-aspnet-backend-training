# Task 06 - SQL & ERD Starter

## Selected Scenario

Training Center Management System

## Main Entities

* Students
* Instructors
* Tracks
* Registrations
* Payments

## Relationships

* Instructor has many Tracks
* Student has many Registrations
* Track has many Registrations
* Registration has one Payment

## Why I Designed It This Way

The database is divided into separate tables to represent the main entities of the training center system.
Instructors are connected to Tracks because an instructor can teach many tracks.
Students can register in multiple tracks, so Registrations is used to manage student registrations.
Each Track can have many Registrations, allowing multiple students to register in the same track.
Payments are connected to Registrations to store payment information for each registration.
Primary keys uniquely identify each record, while foreign keys maintain relationships between related tables.

## SQL Queries

### 1. Select all students

```sql 
Select * 
From Students
```

### 2. Select all tracks

```sql 
Select *
From Tracks
```

### 3. Select students registered in a specific track

```sql 
SELECT *
FROM Registrations R inner join Tracks T
on R.TrackId=T.TrackId inner join Students S
on S.StudentId=R.StudentId
WHERE T.Title = "G1";
```

### 4. Count students per track

```sql 
SELECT TrackId,COUNT(*) as "Number of Students"
From Track T inner join Registrations R
on T.TrackId=R.TrackId
GROUP BY TrackId
```

### 5. Select unpaid registrations

```sql 
Select *
From Regestrations 
Where Status="unpaid"
```

### 6. Select tracks by instructor

```sql 
Select *
 From Tracks
 Where InstructorId=1
```

### 7. Select registrations with payment status using JOIN

```sql 
Select *
From Registrations R inner join Payments P
on R.RegistrationId=P.RegistrationId
```

### 8. Select tracks starting after a specific date

```sql 
Select *
From Tracks
where StartDate>="2026-08-16"
```

### 9. Count tracks per instructor

```sql 
SELECT InstructorId,COUNT(*) as "Number of Tracks"
From Track
GROUP BY InstructorId
```

### 10. Select student registration history

```sql 
SELECT *
From Student S inner join Registrations R
on S.StudentId=R.StudentId
```

## ERD

The Entity Relationship Diagram is included in the TrainingCenterSystempdf.

## Design Decisions

The database separates students, instructors, tracks, registrations, and payments into different tables to avoid unnecessary data duplication. Foreign keys connect the related entities and maintain referential integrity. Registrations connects students with tracks and represents the registration process. Payments are separated from registrations to store payment details independently. This design makes it easier to manage students, instructors, training tracks, registrations, and payments.
