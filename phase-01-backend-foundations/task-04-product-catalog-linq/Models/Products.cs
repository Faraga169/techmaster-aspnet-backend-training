using System;
using System.Collections.Generic;
using System.Text;

namespace task_04_product_catalog_linq.Model
{
    public class Products
    {
        public Products(int productId,string name,string category,decimal price,int stockQuantity,DateTime createdAt,bool isAvailable,string supplierName,double? rating = null,decimal? discountPercentage = null)
        {
            ProductId = productId;
            Name = name;
            Category = category;
            Price = price;
            StockQuantity = stockQuantity;
            IsAvailable = isAvailable;
            SupplierName = supplierName;
            Rating = rating;
            DiscountPercentage = discountPercentage;
        }
        public int ProductId { get; private set; }

        public string Name { get; private set; } = null!;

        public string Category { get; private set; } = null!;

        public decimal Price { get; private set; }

        public int StockQuantity { get; private set; }

        public DateTime CreatedAt { get; private set; }= DateTime.Now;

        public bool IsAvailable { get; private set; }

        public string SupplierName { get; private set; } = null!;

        public double? Rating { get; private set; }

        public decimal? DiscountPercentage { get; private set; }



    }
}
