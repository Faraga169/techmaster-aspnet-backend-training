using Products_CategoriesAPI.Models;

namespace Products_CategoriesAPI.Seeding
{
    public static class ProductsSeeding
    {

        static ProductsSeeding()
        {
            foreach (var product in Products)
            {
                var category = Categories.Find(c => c.Id == product.CategoryId);

                if (category is not null)
                {
                    category.Products.Add(product);
                }
            }
        }
        // Categories
        public static List<Category> Categories { get; } = new List<Category>
        {
            new Category
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Name = "Electronics",
                Description = "Electronic devices and accessories",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },

            new Category
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Name = "Laptops",
                Description = "Laptops and portable computers",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },

            new Category
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Name = "Accessories",
                Description = "Computer and mobile accessories",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },

            new Category
            {
                Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                Name = "Home Appliances",
                Description = "Home and kitchen appliances",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },

            new Category
            {
                Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                Name = "Gaming",
                Description = "Gaming devices and equipment",
                IsActive = false,
                CreatedAt = DateTime.UtcNow
            }
        };


        // Products
        public static List<Product> Products { get; } = new List<Product>
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "iPhone 15",
                Price = 45000,
                StockQuantity = 15,
                IsAvailable = true,
                SupplierName = "Apple Egypt",
                CreatedAt = DateTime.UtcNow,
                CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },

            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Samsung Galaxy S24",
                Price = 38000,
                StockQuantity = 20,
                IsAvailable = true,
                SupplierName = "Samsung Egypt",
                CreatedAt = DateTime.UtcNow,
                CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },

            new Product
            {
                Id = Guid.NewGuid(),
                Name = "MacBook Air M3",
                Price = 75000,
                StockQuantity = 8,
                IsAvailable = true,
                SupplierName = "Apple Egypt",
                CreatedAt = DateTime.UtcNow,
                CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222")
            },

            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Dell XPS 15",
                Price = 68000,
                StockQuantity = 6,
                IsAvailable = true,
                SupplierName = "Dell Egypt",
                CreatedAt = DateTime.UtcNow,
                CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222")
            },

            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Logitech MX Master 3S",
                Price = 4500,
                StockQuantity = 25,
                IsAvailable = true,
                SupplierName = "Logitech",
                CreatedAt = DateTime.UtcNow,
                CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333")
            },

            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Mechanical Keyboard",
                Price = 3200,
                StockQuantity = 30,
                IsAvailable = true,
                SupplierName = "Keychron",
                CreatedAt = DateTime.UtcNow,
                CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333")
            },

            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Air Fryer",
                Price = 5500,
                StockQuantity = 10,
                IsAvailable = true,
                SupplierName = "Philips",
                CreatedAt = DateTime.UtcNow,
                CategoryId = Guid.Parse("44444444-4444-4444-4444-444444444444")
            },

            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Samsung Microwave",
                Price = 7000,
                StockQuantity = 12,
                IsAvailable = true,
                SupplierName = "Samsung Egypt",
                CreatedAt = DateTime.UtcNow,
                CategoryId = Guid.Parse("44444444-4444-4444-4444-444444444444")
            },

            new Product
            {
                Id = Guid.NewGuid(),
                Name = "PlayStation 5",
                Price = 32000,
                StockQuantity = 5,
                IsAvailable = true,
                SupplierName = "Sony Egypt",
                CreatedAt = DateTime.UtcNow,
                CategoryId = Guid.Parse("55555555-5555-5555-5555-555555555555")
            },

            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Gaming Headset",
                Price = 2800,
                StockQuantity = 18,
                IsAvailable = false,
                SupplierName = "HyperX",
                CreatedAt = DateTime.UtcNow,
                CategoryId = Guid.Parse("55555555-5555-5555-5555-555555555555")
            },
            new Product
{
    Id = Guid.NewGuid(),
    Name = "Google Pixel 9",
    Price = 42000,
    StockQuantity = 7,
    IsAvailable = true,
    SupplierName = "Google Egypt",
    CreatedAt = DateTime.UtcNow,
    CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111")
},

new Product
{
    Id = Guid.NewGuid(),
    Name = "HP Pavilion 15",
    Price = 35000,
    StockQuantity = 4,
    IsAvailable = true,
    SupplierName = "HP Egypt",
    CreatedAt = DateTime.UtcNow,
    CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222")
},

new Product
{
    Id = Guid.NewGuid(),
    Name = "USB-C Hub",
    Price = 1800,
    StockQuantity = 3,
    IsAvailable = true,
    SupplierName = "Anker",
    CreatedAt = DateTime.UtcNow,
    CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333")
},

new Product
{
    Id = Guid.NewGuid(),
    Name = "Wireless Charger",
    Price = 1500,
    StockQuantity = 0,
    IsAvailable = false,
    SupplierName = "Anker",
    CreatedAt = DateTime.UtcNow,
    CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333")
},

new Product
{
    Id = Guid.NewGuid(),
    Name = "Electric Kettle",
    Price = 2200,
    StockQuantity = 2,
    IsAvailable = true,
    SupplierName = "Tefal",
    CreatedAt = DateTime.UtcNow,
    CategoryId = Guid.Parse("44444444-4444-4444-4444-444444444444")
}
        };
    }
}
using Products_CategoriesAPI.Models;

namespace Products_CategoriesAPI.Seeding
{
    public static class ProductsSeeding
    {

        static ProductsSeeding()
        {
            foreach (var product in Products)
            {
                var category = Categories.Find(c => c.Id == product.CategoryId);

                if (category is not null)
                {
                    category.Products.Add(product);
                }
            }
        }
        // Categories
        public static List<Category> Categories { get; } = new List<Category>
        {
            new Category
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Name = "Electronics",
                Description = "Electronic devices and accessories",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },

            new Category
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Name = "Laptops",
                Description = "Laptops and portable computers",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },

            new Category
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Name = "Accessories",
                Description = "Computer and mobile accessories",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },

            new Category
            {
                Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                Name = "Home Appliances",
                Description = "Home and kitchen appliances",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },

            new Category
            {
                Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                Name = "Gaming",
                Description = "Gaming devices and equipment",
                IsActive = false,
                CreatedAt = DateTime.UtcNow
            }
        };


        // Products
        public static List<Product> Products { get; } = new List<Product>
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "iPhone 15",
                Price = 45000,
                StockQuantity = 15,
                IsAvailable = true,
                SupplierName = "Apple Egypt",
                CreatedAt = DateTime.UtcNow,
                CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },

            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Samsung Galaxy S24",
                Price = 38000,
                StockQuantity = 20,
                IsAvailable = true,
                SupplierName = "Samsung Egypt",
                CreatedAt = DateTime.UtcNow,
                CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },

            new Product
            {
                Id = Guid.NewGuid(),
                Name = "MacBook Air M3",
                Price = 75000,
                StockQuantity = 8,
                IsAvailable = true,
                SupplierName = "Apple Egypt",
                CreatedAt = DateTime.UtcNow,
                CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222")
            },

            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Dell XPS 15",
                Price = 68000,
                StockQuantity = 6,
                IsAvailable = true,
                SupplierName = "Dell Egypt",
                CreatedAt = DateTime.UtcNow,
                CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222")
            },

            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Logitech MX Master 3S",
                Price = 4500,
                StockQuantity = 25,
                IsAvailable = true,
                SupplierName = "Logitech",
                CreatedAt = DateTime.UtcNow,
                CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333")
            },

            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Mechanical Keyboard",
                Price = 3200,
                StockQuantity = 30,
                IsAvailable = true,
                SupplierName = "Keychron",
                CreatedAt = DateTime.UtcNow,
                CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333")
            },

            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Air Fryer",
                Price = 5500,
                StockQuantity = 10,
                IsAvailable = true,
                SupplierName = "Philips",
                CreatedAt = DateTime.UtcNow,
                CategoryId = Guid.Parse("44444444-4444-4444-4444-444444444444")
            },

            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Samsung Microwave",
                Price = 7000,
                StockQuantity = 12,
                IsAvailable = true,
                SupplierName = "Samsung Egypt",
                CreatedAt = DateTime.UtcNow,
                CategoryId = Guid.Parse("44444444-4444-4444-4444-444444444444")
            },

            new Product
            {
                Id = Guid.NewGuid(),
                Name = "PlayStation 5",
                Price = 32000,
                StockQuantity = 5,
                IsAvailable = true,
                SupplierName = "Sony Egypt",
                CreatedAt = DateTime.UtcNow,
                CategoryId = Guid.Parse("55555555-5555-5555-5555-555555555555")
            },

            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Gaming Headset",
                Price = 2800,
                StockQuantity = 18,
                IsAvailable = false,
                SupplierName = "HyperX",
                CreatedAt = DateTime.UtcNow,
                CategoryId = Guid.Parse("55555555-5555-5555-5555-555555555555")
            },
            new Product
{
    Id = Guid.NewGuid(),
    Name = "Google Pixel 9",
    Price = 42000,
    StockQuantity = 7,
    IsAvailable = true,
    SupplierName = "Google Egypt",
    CreatedAt = DateTime.UtcNow,
    CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111")
},

new Product
{
    Id = Guid.NewGuid(),
    Name = "HP Pavilion 15",
    Price = 35000,
    StockQuantity = 4,
    IsAvailable = true,
    SupplierName = "HP Egypt",
    CreatedAt = DateTime.UtcNow,
    CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222")
},

new Product
{
    Id = Guid.NewGuid(),
    Name = "USB-C Hub",
    Price = 1800,
    StockQuantity = 3,
    IsAvailable = true,
    SupplierName = "Anker",
    CreatedAt = DateTime.UtcNow,
    CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333")
},

new Product
{
    Id = Guid.NewGuid(),
    Name = "Wireless Charger",
    Price = 1500,
    StockQuantity = 0,
    IsAvailable = false,
    SupplierName = "Anker",
    CreatedAt = DateTime.UtcNow,
    CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333")
},

new Product
{
    Id = Guid.NewGuid(),
    Name = "Electric Kettle",
    Price = 2200,
    StockQuantity = 2,
    IsAvailable = true,
    SupplierName = "Tefal",
    CreatedAt = DateTime.UtcNow,
    CategoryId = Guid.Parse("44444444-4444-4444-4444-444444444444")
}
        };
    }
}