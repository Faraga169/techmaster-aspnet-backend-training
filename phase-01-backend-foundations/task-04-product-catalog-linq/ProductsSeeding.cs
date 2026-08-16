using System;
using System.Collections.Generic;
using System.Text;

namespace task_04_product_catalog_linq
{
    public static class ProductsSeeding
    {
        public static List<Products> Seeding()
        {
            return new List<Products>
    {
        new Products(1, "Laptop Pro 15", "Electronics", 45000m, 12,
            new DateTime(2026, 1, 10), true, "TechWorld", 4.8, 10),

        new Products(2, "Wireless Mouse", "Electronics", 850m, 50,
            new DateTime(2026, 1, 15), true, "TechWorld", 4.4, 5),

        new Products(3, "Mechanical Keyboard", "Electronics", 3200m, 25,
            new DateTime(2026, 2, 5), true, "TechGear", 4.7, 15),

        new Products(4, "Gaming Monitor 27", "Electronics", 12500m, 8,
            new DateTime(2026, 2, 18), true, "TechGear", 4.6, 20),

        new Products(5, "USB-C Hub", "Electronics", 1800m, 0,
            new DateTime(2026, 3, 1), false, "DigitalStore", 4.1, 10),

        new Products(6, "Office Chair", "Furniture", 7500m, 14,
            new DateTime(2026, 1, 20), true, "HomePlus", 4.3, 12),

        new Products(7, "Standing Desk", "Furniture", 11500m, 6,
            new DateTime(2026, 2, 12), true, "HomePlus", 4.7, 8),

        new Products(8, "Bookshelf", "Furniture", 4200m, 20,
            new DateTime(2026, 2, 25), true, "FurnitureHub", 4.0, 5),

        new Products(9, "Coffee Table", "Furniture", 3500m, 0,
            new DateTime(2026, 3, 5), false, "FurnitureHub", 3.9, 15),

        new Products(10, "Sofa 3 Seater", "Furniture", 18000m, 4,
            new DateTime(2026, 1, 5), true, "HomePlus", 4.8, 10),

        new Products(11, "Running Shoes", "Sports", 2800m, 30,
            new DateTime(2026, 1, 25), true, "SportZone", 4.5, 10),

        new Products(12, "Football", "Sports", 900m, 45,
            new DateTime(2026, 2, 2), true, "SportZone", 4.2, 5),

        new Products(13, "Tennis Racket", "Sports", 3600m, 10,
            new DateTime(2026, 2, 15), true, "ProSports", 4.6, 15),

        new Products(14, "Yoga Mat", "Sports", 750m, 0,
            new DateTime(2026, 3, 10), false, "ProSports", 4.0, 20),

        new Products(15, "Dumbbell Set", "Sports", 4200m, 18,
            new DateTime(2026, 1, 30), true, "FitnessStore", 4.7, 10),

        new Products(16, "Programming in C#", "Books", 1200m, 35,
            new DateTime(2026, 1, 8), true, "BookWorld", 4.9, 5),

        new Products(17, "Clean Code", "Books", 950m, 22,
            new DateTime(2026, 1, 18), true, "BookWorld", 4.8, 10),

        new Products(18, "System Design Guide", "Books", 1500m, 15,
            new DateTime(2026, 2, 20), true, "TechBooks", 4.7, 15),

        new Products(19, "Database Internals", "Books", 1800m, 7,
            new DateTime(2026, 3, 2), true, "TechBooks", 4.9, 20),

        new Products(20, "Old Java Book", "Books", 500m, 0,
            new DateTime(2025, 12, 15), false, "BookWorld", 3.5, 30),

        new Products(21, "Backpack", "Accessories", 1400m, 40,
            new DateTime(2026, 1, 12), true, "StyleStore", 4.3, 10),

        new Products(22, "Leather Wallet", "Accessories", 1100m, 28,
            new DateTime(2026, 2, 8), true, "StyleStore", 4.5, 5),

        new Products(23, "Smart Watch", "Accessories", 6500m, 9,
            new DateTime(2026, 2, 28), true, "TechWorld", 4.6, 15),

        new Products(24, "Sunglasses", "Accessories", 2200m, 0,
            new DateTime(2026, 3, 12), false, "FashionHub", 3.8, 25),

        new Products(25, "Bluetooth Speaker", "Electronics", 2400m, 16,
            new DateTime(2026, 3, 15), true, "DigitalStore", 4.4, 10)
    };
        }

    }
}
