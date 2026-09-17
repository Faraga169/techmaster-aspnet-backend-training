# 🎯 EF Core API Refactor — Interview Questions & Answers

This document contains the main technical interview questions and answers related to the **EF Core API Refactor Pack** project.

---

## 1. What is DbContext and what does it do in your project?

**Answer:**

> DbContext is a class provided by Entity Framework Core. It represents a session between my application and the database. I use it to configure my entities and define their relationships, and also to query and save data in the database. In my project, the DbContext contains DbSet properties for entities like Students, TrainingTracks, Enrollments, and Payments.

---

## 2. What is DbSet and how does it map to database tables?

**Answer:**

> DbSet is a property in the DbContext that represents a collection of a specific entity. It allows me to query and manipulate that entity using EF Core. For example, DbSet<Student> represents the Students entity set, which is usually mapped to the Students table in the database.

---

## 3. What is a migration and why do we use it?

**Answer:**

> A migration is a way that Entity Framework Core uses to track changes in the database schema. When I change my entities or database configuration, I create a new migration that contains the changes. Then I can apply these changes to the database using Update-Database. Migrations also keep a history of schema changes, but they are not a database backup.

---

## 4. What is the difference between entity and DTO?

**Answer:**

> An entity represents the data model that is mapped to the database, and it can contain properties and navigation properties. A DTO is used to define the data that we want to receive from or return to the client. We use DTOs to control the API contract and avoid exposing the entity directly.

---

## 5. Why should APIs not return EF entities directly?

**Answer:**

> We should not return EF entities directly because they may contain data or navigation properties that we don't want to expose to the client. It can also cause circular references and tightly couple the API response to the database model. So we use response DTOs to control exactly what data the API returns.

---

## 6. What is a foreign key?

**Answer:**

> A foreign key is a database constraint used to create a relationship between two tables. It references the primary key of another table and helps maintain referential integrity. For example, Enrollment has a StudentId foreign key that references the Id of the Student table. A foreign key can be nullable or non-nullable depending on the relationship configuration.

---

## 7. Explain the relationship between Student, TrainingTrack and Enrollment.

**Answer:**

> The relationship between Student and TrainingTrack is many-to-many because a student can enroll in many training tracks, and a training track can have many students. We use Enrollment as a join entity. So Student has a one-to-many relationship with Enrollment, and TrainingTrack also has a one-to-many relationship with Enrollment.

### Relationship

```text
Student 1 ─────── * Enrollment * ─────── 1 TrainingTrack
```

---

## 8. Why is Enrollment a join entity instead of a simple many-to-many?

**Answer:**

> Because the relationship itself has its own data. For example, Enrollment has properties like EnrollmentDate and Status, which belong to the enrollment relationship, not to the Student or the TrainingTrack. So we need Enrollment as a separate join entity.

---

## 9. What is Include and when did you use it?

**Answer:**

> Include is an Entity Framework Core extension method used for eager loading. It allows me to load related entities along with the main entity. In my project, the original code used Include to load Student, TrainingTrack, and Payments with Enrollment. In the refactored list endpoint, I used projection instead, because I only needed specific fields.

---

## 10. What is Select projection and why is it useful?

**Answer:**

> Select is a LINQ method that I use for projection. It allows me to select only the fields I need and shape the result into a DTO instead of returning the whole entity. In my project, I used projection in the enrollment list to return only the required data, which reduces unnecessary data retrieval and keeps the API response clean.

---

## 11. What is pagination and why does an API need it?

**Answer:**

> Pagination means dividing a large dataset into smaller pages instead of returning all records at once. It's useful when we have a large amount of data because it reduces the amount of data retrieved from the database and sent over the network, which improves API performance and reduces resource usage.

---

## 12. How did you prevent duplicate active enrollments?

**Answer:**

> Before creating a new enrollment, I check if the student already has an active enrollment for the same training track. I use an AnyAsync query with the StudentId, TrainingTrackId, and Active status. If an active enrollment already exists, I reject the request; otherwise, I create the new enrollment.

---

## 13. How did you protect track capacity?

**Answer:**

> Before creating an enrollment, I check the training track capacity. I count the current active enrollments for that track and compare the count with the track capacity. If the capacity is already full, I reject the enrollment. Otherwise, I allow the student to enroll.

---

## 14. How did you handle payment validation?

**Answer:**

> When creating a payment, I validate that the amount is greater than zero and does not exceed the remaining amount. The payment starts with a Pending status. When the payment is updated to Paid, I check if the total paid amount has reached the required amount. If the payment is fully completed, I update the enrollment status to Active.

---

## 15. What is soft delete and why did you use it?

**Answer:**

> Soft delete means that we don't physically remove the record from the database. Instead, we mark it as deleted using a flag like IsDeleted. The record remains in the database, so we can restore it later if needed. We also filter out deleted records from normal queries.

---

## 16. What is the difference between a local database and a remote database?

**Answer:**

> A local database runs on my local machine or local environment, so it's mainly used during development. A remote database runs on a separate server or cloud hosting environment, and my deployed application connects to it over the network. Access to the remote database should be secured with authentication and proper permissions.

---

## 17. How did you configure the production connection string?

**Answer:**

> For production, I configured the connection string as an environment variable in MonsterASP instead of storing the real connection string in the source code. The application reads the connection string from the production environment configuration.

---

## 18. Why should connection strings not be pushed to GitHub?

**Answer:**

> We should not push connection strings to GitHub because they may contain sensitive credentials such as database usernames and passwords. If they are exposed, unauthorized users could potentially access the database. That's why I store production connection strings in environment variables or secure configuration.

---

## 19. What is the hardest bug you faced in deployment?

**Answer:**

> One of the hardest deployment issues I faced was handling the production connection string securely. At first, I wasn't sure how to keep the credentials out of the application code. I solved it by storing the connection string as an environment variable in MonsterASP, so the application could read it from the production environment without exposing it in GitHub.

---

## 20. If you had one more week, how would you improve the system?

**Answer:**

> If I had one more week, I would add authentication and authorization to secure the API, and I would also add unit and integration tests to make sure the business logic works correctly.

---

# 🔥 Quick Revision

| Topic              | Key Point                                       |
| ------------------ | ----------------------------------------------- |
| DbContext          | Session/bridge between application and database |
| DbSet              | Entity set inside DbContext                     |
| Migration          | Tracks database schema changes                  |
| Entity             | Database/domain model                           |
| DTO                | API contract                                    |
| Foreign Key        | Relationship + referential integrity            |
| Enrollment         | Join entity with relationship data              |
| Include            | Eager loading                                   |
| Select             | Projection                                      |
| Pagination         | Return data in smaller pages                    |
| AnyAsync           | Check if at least one record exists             |
| Capacity           | Active enrollments vs track capacity            |
| Payment            | Validate amount and completion                  |
| Soft Delete        | Mark deleted instead of physical deletion       |
| Local DB           | Development/local environment                   |
| Remote DB          | Database on separate server                     |
| Production Secrets | Environment variables                           |
| Authentication     | Verify who the user is                          |
| Authorization      | Verify what the user can access                 |
| Testing            | Verify business logic and system behavior       |
