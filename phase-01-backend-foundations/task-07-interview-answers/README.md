# Technical Interview Questions & Answers

## 1. What is the difference between a class and an object?

**Answer:**

A class is a blueprint or template that defines the attributes and methods of an object. An object is an instance of a class. We can create multiple objects from the same class, and each object can have its own data or state.

---

## 2. What is encapsulation?

**Answer:**

Encapsulation is one of the main OOP principles. It means hiding the internal data and controlling how other parts of the program can access or modify it. We can use properties, getters, and setters, and we can also make data read-only when needed.

---

## 3. Why should account balance not be public?

**Answer:**

The account balance should not be public because external code could modify it directly and set an invalid value. We should control access to the balance and allow it to be changed only through methods like `Deposit` and `Withdraw`, where we can validate the operation.

---

## 4. What is the difference between a field and a property?

**Answer:**

A field stores data inside a class, while a property provides controlled access to that data.

---

## 5. Why do we use constructors?

**Answer:**

We use constructors to initialize an object when it is created. They can be used to set the initial values of the object's properties and fields.

---

## 6. What is the purpose of a service class?

**Answer:**

A service class is responsible for handling the business logic and business rules of the application. It keeps the business logic separate from the models or UI, which makes the code easier to maintain and test.

---

## 7. Why should we avoid huge Main methods?

**Answer:**

We should avoid huge Main methods because Main is the entry point of the application and should remain simple. Keeping the logic in separate classes improves readability, maintainability, and follows the Separation of Concerns principle.

---

## 8. What is the difference between List and Array?

**Answer:**

An array has a fixed size, which means its size cannot be changed after it is created. A List has a dynamic size, so we can add or remove elements as needed.

---

## 9. When would you use Dictionary?

**Answer:**

I would use a Dictionary when I need to store data as key-value pairs and quickly access a value using a unique key. For example, if I want to search for a student by their ID, a Dictionary can provide fast lookup.

---

## 10. What is LINQ used for?

**Answer:**

LINQ is used to query and manipulate data from collections or databases. It allows us to filter, sort, select, group, and perform other operations on data in a simple and readable way.

---

## 11. What is the difference between Where and Select?

**Answer:**

`Where` is used to filter data based on a condition. `Select` is used for projection, which means selecting or transforming the specific properties or fields we need.

---

## 12. What is GroupBy used for?

**Answer:**

GroupBy is used to group data into groups based on a specific property or value. For example, we can group products by category or students by track.

---

## 13. What are Skip and Take used for?

**Answer:**

Skip is used to skip a specific number of elements from the beginning of a collection, while Take is used to retrieve a specific number of elements. They are commonly used together for pagination.

---

## 14. What is a primary key?

**Answer:**

A primary key is a constraint in a database that uniquely identifies each row in a table. It must contain unique values and cannot contain NULL values.

---

## 15. What is a foreign key?

**Answer:**

A foreign key is a constraint used to create a relationship between two tables. It references the primary key of another table. Foreign key values can be duplicated, and they can allow NULL values if the column is not defined as NOT NULL.

---

## 16. What is a one-to-many relationship?

**Answer:**

A one-to-many relationship means that one record in one entity can be related to many records in another entity, while each record on the many side belongs to only one record on the one side. For example, one customer can have many orders, but each order belongs to one customer.

---

## 17. Why do we use JOIN?

**Answer:**

We use JOIN to retrieve related data from multiple tables based on a related column between them. For example, we can join Orders with Customers to get the customer information for each order.

---

## 18. What is the difference between table and entity?

**Answer:**

An entity represents a real-world object or concept in the business domain, such as a Customer or an Order. A table is the database structure used to store data about that entity.

---

## 19. Why do we use GitHub?

**Answer:**

We use GitHub for version control and collaboration. In a team, each developer can work on different parts of the project at the same time. It keeps the project history organized, allows us to track changes, and helps us go back to a previous version if something goes wrong.

---

## 20. What makes a README useful?

**Answer:**

A good README explains the purpose of the project, its main features, how to run it, and important design decisions. It helps other developers understand the project quickly.

---

## 21. Why are multiple commits better than one final commit?

**Answer:**

Multiple commits are better because they show the development history step by step. Each commit can represent a specific change or feature, which makes the project easier to understand, review, and debug.

---

## 22. Why is professional delivery important?

**Answer:**

Professional delivery is important because it shows that the work meets the requirements and is presented in a clear and organized way. It makes the project easier to review, understand, maintain, and evaluate.