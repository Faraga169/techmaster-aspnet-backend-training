# Task 06 - SQL & ERD Starter

## Selected Scenario

Library Management System

## Main Entities

* Books
* Authors
* Categories
* Members
* BorrowRecords

## Relationships

* Author has many Books
* Category has many Books
* Member has many BorrowRecords
* Book has many BorrowRecords

## Why I Designed It This Way

The database is divided into separate tables to represent the main entities of the library system.
Books are connected to Authors and Categories using foreign keys.
Members can borrow books, so BorrowRecords stores the borrowing transactions.
A member can have many borrowing records over time.
A book can also appear in many borrowing records.
Primary keys uniquely identify each record, while foreign keys maintain the relationships between tables.

## SQL Queries

### 1. Select all books

```sql
SELECT *
FROM Books;
```

### 2. Select all active members

```sql
SELECT *
FROM Members
WHERE IsActive = 1;
```

### 3. Select books by category

```sql
SELECT *
FROM Books
WHERE CategoryId = 2;
```

### 4. Count books per category

```sql
SELECT CategoryId,COUNT(*) AS CountOfBooks
FROM Books
GROUP BY CategoryId;
```

### 5. Select borrow records with member name and book title

```sql
SELECT M.FullName,B.Title
FROM BorrowRecords BR INNER JOIN Books B
    ON BR.BookId = B.BookId INNER JOIN Members M
    ON BR.MemberId = M.MemberId;
```

### 6. Select overdue books

```sql
SELECT *
FROM BorrowRecords
WHERE DueDate < GETDATE() AND ReturnDate IS NULL;
```

### 7. Select borrowing history for one member

```sql
SELECT *
FROM BorrowRecords
WHERE MemberId = 1;
```

### 8. Select available books

```sql
SELECT *
FROM Books
WHERE AvailableCopies > 0;
```

### 9. Count how many books each author has

```sql
SELECT AuthorId, COUNT(*) AS [Number of Books]
FROM Books
GROUP BY AuthorId;
```

### 10. Select top 5 most borrowed books

```sql
SELECT TOP 5 BookId,COUNT(*) AS BorrowCount
FROM Loans
GROUP BY BookId
ORDER BY BorrowCount DESC;
```

## ERD

The Entity Relationship Diagram is included in the LibrarySystemPDF.

## Design Decisions

The database separates books, authors, categories, members, and borrowing records into different tables to avoid unnecessary data duplication. Foreign keys connect related tables and maintain referential integrity. BorrowRecords connects members with books and stores information about each borrowing operation. This design makes it easier to track borrowing history, overdue books, available books, and the most borrowed books.
