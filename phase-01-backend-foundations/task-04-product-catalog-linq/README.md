# Product Catalog (Task 04) - Service Reference

# 
This document explains the responsibilities and behaviour of the ProductService class implemented in the Product Catalog LINQ task. Each public method from Services/ProductService.cs is paraphrased below with its purpose, inputs, outputs and notable validation or side-effects. The descriptions are based strictly on the current source code.


## Overview

# 
ProductService is a static in-memory service that operates on an application-wide Products collection (seeded at startup). It provides query, aggregation and reporting utilities implemented with LINQ. Several methods return lists or single products; others print reports to the console.

Important: all behaviour described here reflects the current implementation and its validations.

# 
---

## Members

# 
- Products (List<Products>)
  - In-memory list of product entities. It is populated by ProductsSeeding.Seeding() and exposed as a read-only static property.
---

# 
## Methods (paraphrased)

1. GetAllAvailableProducts()
   - Returns a list of all products whose IsAvailable flag is true.
   - Throws InvalidOperationException if no available products exist.

# 
2. FilterByCategory(string category)
   - Returns all products that match the specified category (case-insensitive comparison).
   - Throws ArgumentNullException if the category parameter is null.
   - Throws InvalidOperationException when no products are found for the category.

# 
3. FilterByPrice(decimal minPrice, decimal maxPrice)
   - Returns products with Price between minPrice and maxPrice inclusive.
   - Validates arguments: minPrice must be > 0; maxPrice must be > 0 and >= minPrice.
   - Throws ArgumentOutOfRangeException on invalid price range; throws InvalidOperationException if no products fall in the range.

# 
4. SearchByproductName(string name)
   - Locates and returns the first product whose Name contains the provided name substring (case-insensitive).
   - Throws ArgumentNullException if the name parameter is null.
   - Throws InvalidOperationException if no product matches the search.

# 
5. SearchBypriceAscending()
   - Returns all products sorted by Price in ascending order.
   - Throws InvalidOperationException if the product list is empty.

# 
6. SearchBypriceDescending()
   - Returns all products sorted by Price in descending order.
   - Throws InvalidOperationException if the product list is empty.

# 
7. GroupProductsByCategory()
   - Groups products by Category and writes a simple console report listing category names and product names in each group.
   - Throws InvalidOperationException if no products exist.
   - Note: this method writes directly to the console and returns void.

# 
8. CountProductsByCategory()
   - Groups products by Category and prints the number of products in each category to the console.
   - Throws InvalidOperationException if no products exist.

# 
9. CalculateTotalStock()
   - Calculates and returns total stock value across all products using Price * StockQuantity for each product.
   - Returns decimal sum (zero if no products exist in the seeded list; method does not throw in that case).

# 
10. CalaculateStockPerCategory()
    - For each category, computes the total stock value (sum of Price * StockQuantity) and prints a console report.
    - Throws InvalidOperationException if no products exist.

# 
11. TopFiveExpensiveProducts()
    - Returns the top five products ordered by Price descending (or fewer if less than five products exist).

# 
12. LowStockProducts()
    - Returns products whose StockQuantity is less than or equal to 5.
    - Throws InvalidOperationException if no such products are found.

# 
13. OutOfStock()
    - Returns products that are either out of stock (StockQuantity == 0) or marked as not available (IsAvailable == false).
    - Throws InvalidOperationException if none match.

# 
14. ProjectSummaryDTO()
    - Projects products into a lightweight ProjectSummaryDTO list containing Name, Price, StockQuantity and a Status string.
    - The Status is "Out of Stock" when StockQuantity == 0, "Low Stock" when StockQuantity <= 5, otherwise "In Stock".
    - Throws InvalidOperationException if no products are present.

# 
15. SupplierReport()
    - Groups products by SupplierName and prints a supplier-oriented report to the console showing supplier name, product count, total stock value and average stock value.
    - Throws InvalidOperationException if no products exist.
    - Note: method writes formatted output directly to the console and returns void.

# 
16. CalaculateCountofproductsLast60Days()
    - Returns a list of products whose CreatedAt date is within the last 60 days (CreatedAt >= DateTime.Now.AddDays(-60)).
    - Throws InvalidOperationException when no recent products are found.

# 
17. CategoryStatistics()
    - Computes per-category statistics (count, total stock value, average stock value, max, min) based on Price * StockQuantity and prints a formatted console report.
    - Throws InvalidOperationException if the product list is empty.

# 
18. GetProductsAboveAverage()
    - Calculates the average product Price and returns products whose Price is greater than that average.
    - Throws InvalidOperationException if no products are found above the average (or if product list is empty).
#
19. ApplySearchAndFilter(string category, decimal minprice, decimal maxprice, bool Available)
    - Returns products that match the provided category (case-insensitive), whose Price is between minprice and maxprice inclusive, and that are available (IsAvailable is true).
    - Throws InvalidOperationException if no products match the combined filter.
    - Note: although the method signature includes an Available parameter, the current implementation ignores that parameter and always requires Products' IsAvailable to be true. This may be an implementation oversight.

# 
20. Pagination(int pageno, int pagesize)
    - Simulates pagination by skipping (pageno - 1) * pagesize items and taking pagesize items from the Products list.
    - Validates pageno and pagesize must be greater than zero; throws ArgumentOutOfRangeException otherwise.
    - Throws InvalidOperationException if the requested page yields no products.

---

# 
## Usage notes & considerations

# 
- Many methods throw InvalidOperationException when no products match a query. Callers should be prepared to catch these exceptions when presenting results to users.
- Several methods write output directly to the console (GroupProductsByCategory, CountProductsByCategory, SupplierReport, CategoryStatistics). If you prefer pure data operations, consider adding non-interactive overloads that return DTOs instead of printing.
- The ApplySearchAndFilter method accepts an Available boolean parameter but does not use it; it instead filters by product.IsAvailable. Review this if you expect the method to honor the caller's Available argument.
- All methods operate on the static in-memory Products list. For persistent storage or testability, consider replacing the static collection with an injected repository abstraction.

# 
---
This README is intended as a technical reference for the ProductService implementation. For model definitions and seeded data, see the Model and Seeding folders in the same project.



