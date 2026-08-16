using System;
using System.Collections.Generic;
using System.Text;
using task_04_product_catalog_linq.Model;
using task_04_product_catalog_linq.Seeding;

namespace task_04_product_catalog_linq.Services
{
    public static class ProductService
    {
        public static List<Products> Products { get; private set; } = ProductsSeeding.Seeding();

        #region Get All Available Products
        public static List<Products> GetAllAvailableProducts() {

           var availableProducts= Products.Where(p => p.IsAvailable).ToList();
            if (availableProducts.Count == 0)
                throw new InvalidOperationException("No Products Available");

            return availableProducts;

        }
        #endregion

        #region Filter by Category
        public static List<Products> FilterByCategory(string category)
        {
            if (category is null)
                throw new ArgumentNullException("Category is null");

            var products = Products.Where(p => p.Category.Equals(category,StringComparison.OrdinalIgnoreCase)).ToList();
            if (products.Count == 0)
                throw new InvalidOperationException($"No Products in {category} category");

            return products;

        }
        #endregion

        #region Filter by Price Range
        public static List<Products> FilterByPrice(decimal minPrice,decimal maxPrice)
        {
            if (minPrice <= 0)
                throw new ArgumentOutOfRangeException("min price must be greater than 0");
            if(maxPrice < minPrice ||maxPrice<=0)
                throw new ArgumentOutOfRangeException("max price must be greater than min price and greater than 0");

            var products = Products.Where(p => p.Price>=minPrice &&p.Price<=maxPrice).ToList();
            if (products.Count == 0)
                throw new InvalidOperationException($"No Products in Range between {minPrice} and {maxPrice}");

            return products;

        }
        #endregion

        #region Search by Product Name
        public static Products SearchByproductName(string name)
        {
            if (name is null)
                throw new ArgumentNullException("ProductName is null");
         

            var product = Products.Find(p => p.Name.Contains(name,StringComparison.OrdinalIgnoreCase));
            if (product is null)
                throw new InvalidOperationException($"No Product Found by Name {name}");

            return product;

        }
        #endregion

        #region Sort by Price Ascending
        public static List<Products> SearchBypriceAscending()
        {
           
            var product = Products.OrderBy(p => p.Price).ToList();
            if (product.Count==0)
                throw new InvalidOperationException($"No Product Found");

            return product;

        }
        #endregion

        #region Sort by Price Descending
        public static List<Products> SearchBypriceDescending()
        {

            var product = Products.OrderByDescending(p => p.Price).ToList();
            if (product.Count == 0)
                throw new InvalidOperationException($"No Product Found");

            return product;

        }
        #endregion

        #region Group Products by Category
        public static void GroupProductsByCategory()
        {

            var products = Products.GroupBy(p => p.Category).Select(p=>new { Category=p.Key,Products=p}).ToList();
            if (products.Count == 0)
                throw new InvalidOperationException($"No Product Found");
            foreach (var i in products) {

                Console.WriteLine($"Category {i.Category}");

                foreach (var j in i.Products) {

                    Console.WriteLine($"Product Name = {j.Name}");
                }
            }

            

        }
        #endregion

        #region Count Products per Category
        public static void CountProductsByCategory()
        {

            var products = Products.GroupBy(p => p.Category).Select(p => new { Category = p.Key, Count = p.Count() }).ToList();
            if (products.Count == 0)
                throw new InvalidOperationException($"No Product Found");
            foreach (var i in products)
            {

                Console.WriteLine($"Category {i.Category} has {i.Count} products");

              
            }



        }
        #endregion

        #region Calculate Total Stock Value
        public static decimal CalculateTotalStock()
        {

            var sum = Products.Sum(p => p.Price*p.StockQuantity);

            return sum;

        }
        #endregion

        #region Stock Value per Category
        public static void CalaculateStockPerCategory()
        {

            var products = Products.GroupBy(p => p.Category).Select(p => new { Category = p.Key, Total = p.Sum(p=>p.StockQuantity*p.Price) }).ToList();
            if (products.Count == 0)
                throw new InvalidOperationException($"No Product Found");
            foreach (var i in products)
            {

                Console.WriteLine($"Category {i.Category} has {i.Total} Stock");


            }



        }
        #endregion

        #region Top 5 Most Expensive Products
        public static List<Products> TopFiveExpensiveProducts()
        {

            var products = Products.OrderByDescending(p => p.Price).Take(5).ToList();

            return products;



        }
        #endregion
    }
}
