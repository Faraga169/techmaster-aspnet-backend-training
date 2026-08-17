# Task 06 - SQL & ERD Starter

## Selected Scenario

Simple Store & Orders System

## Main Entities

* Customers
* Categories
* Suppliers
* Products
* Orders
* OrderItems

## Relationships

* Customer has many Orders
* Category has many Products
* Supplier has many Products
* Order has many OrderItems
* Product has many OrderItems

## Why I Designed It This Way

The database is divided into separate tables to represent the main entities of the store system.
Products are connected to Categories and Suppliers using foreign keys.
Customers can place orders, so Orders stores customer order information.
An order can contain many OrderItems, and each OrderItem represents a product included in an order.
A product can appear in many OrderItems across different orders.
Primary keys uniquely identify each record, while foreign keys maintain relationships between related tables.

## SQL Queries

### 1. Select all products

```sql
SELECT *
FROM Products;
```

### 2. Select available products

```sql
SELECT *
FROM Products
WHERE IsAvailable = 1;
```

### 3. Select products by category

```sql
SELECT *
FROM Products
WHERE CategoryId = 2;
```

### 4. Select products with low stock

```sql
SELECT *
FROM Products
WHERE StockQuantity <= 5;
```

### 5. Select orders for one customer

```sql
SELECT *
FROM Orders
WHERE CustomerId = 1;
```

### 6. Select order details using JOIN

```sql
SELECT *
FROM Orders O
INNER JOIN Customers C
    ON O.CustomerId = C.CustomerId;
```

### 7. Calculate total sales

```sql
SELECT SUM(TotalAmount)
FROM Orders;
```

### 8. Count products per category

```sql
SELECT
    CategoryId,
    COUNT(*) AS "No of products"
FROM Products
GROUP BY CategoryId;
```

### 9. Select best-selling products

```sql
SELECT
    P.ProductId,
    P.Name AS ProductName,
    SUM(OI.Quantity) AS TotalRevenue
FROM Products P
INNER JOIN OrderItems OI
    ON P.ProductId = OI.ProductId
INNER JOIN Orders O
    ON OI.OrderId = O.OrderId
WHERE O.Status = 'Completed'
GROUP BY P.ProductId, P.Name
ORDER BY TotalRevenue DESC;
```

### 10. Select suppliers with their products

```sql
SELECT *
FROM Suppliers S
INNER JOIN Products P
    ON S.SupplierId = P.SupplierId;
```

## ERD

The Entity Relationship Diagram is included in the StoreSystempdf.

## Design Decisions

The database separates customers, categories, suppliers, products, orders, and order items into different tables to avoid unnecessary data duplication. Foreign keys connect related tables and maintain referential integrity. Products are linked to categories and suppliers to organize product information. Orders are connected to customers, while OrderItems connects orders with products and stores the products included in each order. This design makes it easier to manage products, customers, orders, inventory, suppliers, and sales information.
