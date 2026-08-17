# Task 05 - Debug & Refactor Pack

## Overview

This project refactors a messy order calculator written by a junior developer.

The original application contained customer input, validation, discount calculation, tax calculation, shipping logic, and receipt printing inside `Program.cs`.

The goal of the refactoring was to keep the original functionality while improving **code organization, readability, validation, maintainability, and separation of responsibilities**.

---

## Business Rules

The application follows these rules:

* Price must be positive.
* Quantity must be positive.
* Customer name cannot be empty.
* Product name cannot be empty.
* Tax is **14%**.
* Shipping is **50** when the amount after discount is below `1000`.
* Shipping is **0** when the amount after discount is `1000` or more.
* Discount is applied before tax.
* Tax is applied after discount.
* Shipping is added after tax.

### Customer Discounts

| Customer Type | Discount |
| ------------- | -------: |
| Regular       |       0% |
| Silver        |       5% |
| Gold          |      10% |
| VIP           |      15% |

---

# Before Refactoring

The original application had almost all of its functionality inside `Program.cs`.

The code was responsible for:

```text
User Input
    ↓
Validation
    ↓
Order Calculation
    ↓
Discount Calculation
    ↓
Tax Calculation
    ↓
Shipping Calculation
    ↓
Receipt Printing
```

This made the code difficult to read, test, maintain, and extend.

### Problems in the Original Code

1. All functionality was inside `Main`.
2. Variable names were unclear, such as `c`, `p`, `pr`, `q`, and `t`.
3. Business logic was mixed with console input.
4. `double` was used for monetary values.
5. `double.Parse()` and `int.Parse()` could crash on invalid input.
6. Customer types were represented as strings.
7. Tax rate was a magic number.
8. Shipping cost was a magic number.
9. Free-shipping threshold was a magic number.
10. Discount percentages were magic numbers.
11. There was no dedicated `Customer` model.
12. There was no dedicated `Order` model.
13. Calculation logic was not separated into methods.
14. Receipt formatting was directly inside `Main`.
15. Validation and business calculations were tightly coupled.

---

# After Refactoring

The application was separated into different responsibilities:

```text
Program
   ↓
ConsoleMenu
   ↓
OrderService
   ↓
Order
Customer
```

### Main Responsibilities

#### `Customer`

Stores customer information and customer type.

```text
Customer Name
Customer Type
```

#### `Order`

Represents the order information.

```text
Product Name
Price
Quantity
Customer
```

#### `OrderService`

Contains the order business rules and calculations.

```text
CalculateSubTotal()
CalculateDiscount()
CalculateTax()
CalculateShipping()
CalculateFinalTotal()
CalculateOrder()
```

#### `ConsoleMenu`

Handles:

* User input
* Input validation
* Customer type selection
* Receipt display

#### `Program`

Only starts the application:

```csharp
ConsoleMenu.Run();
```

---

# Improvements Made

## 1. Created a Customer Class

Instead of keeping customer information inside `Main`, a dedicated `Customer` model was created.

### Why?

This gives the customer its own responsibility and makes the code easier to maintain.

---

## 2. Created an Order Class

Order information was moved into a dedicated `Order` model.

### Why?

The order becomes a clear object that can be passed to the calculation service.

---

## 3. Introduced CustomerType Enum

Instead of comparing strings such as:

```text
Regular
Silver
Gold
VIP
```

the application uses:

```csharp
CustomerType
```

### Why?

Enums provide stronger typing and prevent invalid customer type strings from being passed around.

---

## 4. Extracted Business Logic into OrderService

The calculations were removed from `Main` and moved into `OrderService`.

### Why?

Business logic should not depend on console input or output.

This also makes the calculation methods easier to test independently.

---

## 5. Improved Variable Names

Original:

```csharp
double c
double p
double pr
int q
string t
```

After:

```csharp
customerName
productName
price
quantity
customerType
```

### Why?

Meaningful names make the code easier to understand.

---

## 6. Replaced double with decimal

The original code used:

```csharp
double
```

The refactored version uses:

```csharp
decimal
```

for monetary calculations.

### Why?

`decimal` is more appropriate for financial and currency calculations.

---

## 7. Added Price Validation

The application now checks that:

```text
Price > 0
```

### Why?

Negative or zero prices are invalid according to the business rules.

---

## 8. Added Quantity Validation

The application checks that:

```text
Quantity > 0
```

### Why?

An order cannot contain zero or a negative quantity.

---

## 9. Improved User Input Validation

Instead of directly using:

```csharp
double.Parse()
int.Parse()
```

the application uses methods such as:

```csharp
decimal.TryParse()
int.TryParse()
```

### Why?

Invalid user input no longer causes the application to crash.

The user is asked to enter a valid value again.

---

## 10. Replaced Magic Numbers with Constants

The following values were extracted into constants:

```csharp
TaxRate
Shipping
FreeShippingThreshold
SilverDiscount
GoldDiscount
VipDiscount
```

### Why?

The business rules become easier to understand and modify.

For example:

```csharp
private const decimal TaxRate = 0.14m;
private const decimal Shipping = 50m;
private const decimal FreeShippingThreshold = 1000m;
```

---

## 11. Extracted Subtotal Calculation

Instead of calculating everything inside one large method:

```csharp
CalculateSubTotal()
```

was created.

### Why?

Each method now has a clear and focused responsibility.

---

## 12. Extracted Discount Calculation

Discount calculation was moved into:

```csharp
CalculateDiscount()
```

### Why?

Customer discount rules are isolated from the rest of the order calculation.

---

## 13. Extracted Tax Calculation

Tax calculation was moved into:

```csharp
CalculateTax()
```

### Why?

The 14% tax rule is now isolated and easier to modify or test.

---

## 14. Extracted Shipping Calculation

Shipping calculation was moved into:

```csharp
CalculateShipping()
```

### Why?

The free-shipping rule is now separated from the final total calculation.

---

## 15. Improved Receipt Output

The application now displays a structured receipt containing:

```text
Customer
Product
Price
Quantity
Customer Type
Subtotal
Discount
After Discount
Tax
Shipping
Final Total
```

### Why?

The output is easier for the user to read and understand.

---

# Calculation Flow

The refactored application follows the required calculation order:

```text
Price × Quantity
       ↓
   Subtotal
       ↓
    Discount
       ↓
 After Discount
       ↓
      Tax
       ↓
   Shipping
       ↓
  Final Total
```

The order is important because the business rules specify that:

```text
Discount → Tax → Shipping
```

---

# Example

Suppose:

```text
Customer Type = Gold
Price = 500
Quantity = 3
```

### Subtotal

```text
500 × 3 = 1500
```

### Gold Discount

```text
1500 × 10% = 150
```

### After Discount

```text
1500 - 150 = 1350
```

### Tax

```text
1350 × 14% = 189
```

### Shipping

Since the amount after discount is at least `1000`:

```text
Shipping = 0
```

### Final Total

```text
1350 + 189 + 0 = 1539
```

---

# Final Structure

```text
Refactor
│
├── Models
│   ├── Customer.cs
│   ├── CustomerType.cs
│   └── Order.cs
│
├── Services
│   └── OrderService.cs
│
├── UI
│   └── ConsoleMenu.cs
│
├── Program.cs
│
└── README.md
```

---

# Refactoring Result

The application keeps the same business purpose and calculation rules while providing:

* Better separation of responsibilities
* Better validation
* Better naming
* Better maintainability
* Stronger typing
* Cleaner business logic
* Reusable calculation methods
* Safer user input
* Cleaner receipt output
* Easier future testing and extension

The main goal of the refactoring was **not to change what the application does, but to improve how the application is structured and maintained.**
