
using task_06_api_standards_refactor_pack.RefactoredAPI.Models;

namespace task_06_api_standards_refactor_pack.RefactoredAPI.Seeding
{
    public static class ProductsSeeding
    {
        public static List<Product> Products { get; } = new List<Product>() {

             new Product
    {
        Id = 1,
        Name = "Laptop",
        Price = 35000m,
        Stock = 10
    },
    new Product
    {
        Id = 2,
        Name = "Wireless Mouse",
        Price = 750m,
        Stock = 25
    },
    new Product
    {
        Id = 3,
        Name = "Mechanical Keyboard",
        Price = 2200m,
        Stock = 15
    },
    new Product
    {
        Id = 4,
        Name = "USB-C Hub",
        Price = 1200m,
        Stock = 8
    },
    new Product
    {
        Id = 5,
        Name = "Monitor",
        Price = 8500m,
        Stock = 5
    },
    new Product
    {
        Id = 6,
        Name = "Webcam",
        Price = 1800m,
        Stock = 12
    },
    new Product
    {
        Id = 7,
        Name = "Headphones",
        Price = 3200m,
        Stock = 20
    },
    new Product
    {
        Id = 8,
        Name = "External SSD",
        Price = 4500m,
        Stock = 7
    },
    new Product
    {
        Id = 9,
        Name = "Gaming Chair",
        Price = 9000m,
        Stock = 3
    },
    new Product
    {
        Id = 10,
        Name = "Laptop Stand",
        Price = 950m,
        Stock = 18
    }

        };
    }
}
