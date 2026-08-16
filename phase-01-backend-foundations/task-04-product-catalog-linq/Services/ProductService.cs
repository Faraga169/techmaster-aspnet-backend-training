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
    }
}
