# Products & Categories Management API

A RESTful Web API built with ASP.NET Core for managing products and categories.

This mini project focuses on practicing ASP.NET Core Web API fundamentals, including CRUD operations, DTOs, service-layer business logic, validation, searching, filtering, pagination, stock reporting, exception handling, and in-memory data seeding.

---

## Technologies

- C#
- ASP.NET Core Web API
- LINQ
- RESTful APIs
- DTOs
- Dependency Injection
- Custom Middleware
- Data Annotations
- In-Memory Data Storage
- Swagger / OpenAPI
- Postman

---

## Features

### Categories

- Get all categories
- Get category by ID
- Create a category
- Update a category
- Delete a category
- Prevent deleting categories that contain products
- Unique category names
- Return products belonging to each category

### Products

- Get all products
- Get product by ID
- Create a product
- Update a product
- Delete a product
- Unique product names
- Search products by name
- Filter products
- Filter by category
- Filter by availability
- Filter by price range
- Filter by low stock

### Stock Report

The API provides:

- Total stock quantity
- Total stock per category
- Low-stock products
- Out-of-stock products
- Number of products per category

---

## Project Structure

```text
Products&CategoriesAPI
│
├── Controllers
│   ├── CategoriesController.cs
│   └── ProductsController.cs
│
├── DTOs
│   ├── CategoryResponse.cs
│   ├── CreateCategoryRequest.cs
│   ├── UpdateCategoryRequest.cs
│   ├── ProductResponse.cs
│   ├── CreateProductRequest.cs
│   ├── UpdateProductRequest.cs
│   ├── StockReportResponse.cs
│   └── ...
│
├── Exceptions
│   └── BusinessException.cs
│
├── Middleware
│   └── ExceptionHandlingMiddleware.cs
│
├── Models
│   ├── Category.cs
│   └── Product.cs
│
├── Seeding
│   └── ProductsSeeding.cs
│
├── Services
│   ├── ICategoryService.cs
│   ├── IProductService.cs
│   ├── CategoryService.cs
│   └── ProductService.cs
│
└── Program.cs



## Data Storage
The project uses in-memory static lists instead of a database.
The application is seeded with:

5 Categories

15 Products

Products are automatically associated with their categories during application initialization.

## API Endpoints
Categories
Get All Categories

GET /api/Categories
Returns all categories with their related products.

Get Category By ID
HTTP
GET /api/Categories/{id}
Example: GET /api/Categories/11111111-1111-1111-1111-111111111111


Create Category
HTTP
POST /api/Categories
**Example Request:**

```JSON
{
  "name": "Smart Home",
  "description": "Smart home devices",
  "isActive": true
}


Update Category
HTTP
PUT /api/Categories/{id}

**Example Request:**

```JSON
{
  "name": "Smart Home Devices",
  "description": "Smart home and IoT devices",
  "isActive": true
}


Delete Category
HTTP
DELETE /api/Categories/{id}
Note: A category cannot be deleted if it contains products.


Products
Get All Products
HTTP
GET /api/Products
Get Product By ID
HTTP
GET /api/Products/{id}

Create Product
HTTP
POST /api/Products
**Example Request:**

```JSON
{
  "name": "Wireless Mouse",
  "price": 1500,
  "stockQuantity": 10,
  "isAvailable": true,
  "supplierName": "Logitech",
  "categoryId": "33333333-3333-3333-3333-333333333333"
}

Update Product
HTTP
PUT /api/Products/{id}
**Example Request:**

```JSON
{
  "name": "Wireless Mouse Pro",
  "price": 2000,
  "stockQuantity": 15,
  "isAvailable": true,
  "supplierName": "Logitech",
  "categoryId": "33333333-3333-3333-3333-333333333333"
}


Delete Product
HTTP
DELETE /api/Products/{id}
Search Products
Search products by name (case-insensitive).

HTTP
GET /api/Products/search?name=Samsung
GET /api/Products/search?name=iPhone


Product Filtering
The API supports filtering products by: Category, Availability, Minimum price, Maximum price, and Low-stock threshold.

Filter by Category: GET /api/Products/filter?categoryName=Electronics

Filter by Price Range: GET /api/Products/filter?minPrice=1000&maxPrice=5000

Filter by Availability: GET /api/Products/filter?availability=true

Filter by Low Stock: GET /api/Products/filter?lowStock=5

Combine Multiple Filters: GET /api/Products/filter?categoryName=Accessories&availability=true&minPrice=1000&maxPrice=5000&lowStock=5


Stock Report
HTTP
GET /api/Products/stock-report
Provides total stock quantity, total stock per category, number of products per category, low-stock products, and out-of-stock products.


Business & Validation Rules
Low Stock & Out of Stock Rules
Low Stock Rule: A product is considered low stock when StockQuantity <= 5

Out of Stock Rule: A product is considered out of stock when StockQuantity == 0

Category Rules
Category name is required and must be unique (case-insensitive).

Category description cannot exceed 100 characters.

A category cannot be deleted if it contains products.

Requesting a non-existing category returns 404 Not Found.

Product Rules
Product name is required and must be unique (case-insensitive).

Supplier name is required.

Product price and stock quantity cannot be negative.

Every product must belong to an existing category.

Requesting a non-existing product returns 404 Not Found.

Search & Filtering Rules
Product search is case-insensitive. Returns 404 Not Found if no matches are found.

minPrice and maxPrice cannot be negative.

maxPrice must be greater than or equal to minPrice.

lowStock threshold must be greater than zero.



Error Handling
The project uses a custom BusinessException together with a global ExceptionHandlingMiddleware. This keeps business logic inside the service layer and provides consistent error responses.

400 Bad Request (Invalid business input):

```JSON
{
  "message": "Product Price must be positive"
}
404 Not Found (Resource does not exist):

```JSON
{
  "message": "Product is not found"
}
500 Internal Server Error (Unexpected exceptions):

```JSON
{
  "message": "An unexpected error occurred."
}


Architecture
The project follows a simple layered architecture:

Plaintext
Client  ──►  Controller  ──►  Service  ──►  In-Memory Data
Controllers: Responsible for receiving HTTP requests, calling the appropriate service, and returning HTTP responses.

Services: Responsible for business logic, validation, searching, filtering, mapping, and stock calculations.

DTOs: Separate API contracts from domain models.

Middleware: Catches application exceptions globally and formats consistent HTTP error responses.


esting Steps
The API can be tested using Swagger or Postman.

1. Run the Application
From the project directory:

Bash
dotnet run
Open Swagger: https://localhost:<port>/swagger

2. Test Categories
GET All Categories: GET /api/Categories (Verify categories & embedded products).

GET Category By ID: Test with valid ID (200 OK) and invalid ID (404 Not Found).

Create Category: Test valid payload (201 Created), empty name (400 Bad Request), and duplicate name (400 Bad Request).

Update Category: Test valid payload (200 OK), non-existing ID (404 Not Found), and invalid input (400 Bad Request).

Delete Category: Test empty category (204 No Content) vs category containing products (400 Bad Request).

3. Test Products
GET All Products: GET /api/Products (Verify seeded products with category names).

GET Product By ID: Existing (200 OK), Non-existing (404 Not Found).

Create Product: Test valid payload (201 Created) and invalid scenarios (400 Bad Request / 404 Not Found for invalid category).

Update & Delete Product: Test valid/invalid updates and deletions.

4. Search & Filtering
Test search case-insensitivity (GET /api/Products/search?name=sAmSuNg).

Test filters individually and combined.

Test invalid filter ranges (minPrice < 0, maxPrice < minPrice, lowStock <= 0) for expected 400 Bad Request.

5. Stock Report
Execute GET /api/Products/stock-report and verify calculations against the business rules (StockQuantity <= 5 and StockQuantity == 0).


Requirements Checklist
[x] Category CRUD

[x] Product CRUD

[x] DTOs for requests and responses

[x] Service layer architecture

[x] Dependency Injection

[x] Business validation

[x] Custom BusinessException

[x] Global exception-handling middleware

[x] Product search

[x] Product filtering (Category, Availability, Price range, Low-stock)

[x] Stock report

[x] Category/Product relationship

[x] In-memory seeding (15+ products, 4+ categories)

[x] Swagger & Postman testing ready


Author
Ahmed Farag

ASP.NET Core / .NET Developer