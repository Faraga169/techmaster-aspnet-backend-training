using System;
using System.Collections.Generic;
using System.Text;

namespace task_04_product_catalog_linq.UI
{
    public static class ConsoleMenu
    {
        public static void ShowMenu() {
            Console.WriteLine("====== Product Catalog LINQ System ======");
            Console.WriteLine("1. View Available Products");
            Console.WriteLine("2. Filter by Category");
            Console.WriteLine("3. Filter by Price Range");
            Console.WriteLine("4. Search by Name");
            Console.WriteLine("5. Sort by Price");
            Console.WriteLine("6. Group by Category");
            Console.WriteLine("7. Stock Value Reports");
            Console.WriteLine("8. Low Stock Products");
            Console.WriteLine("9. Supplier Report");
            Console.WriteLine("10. Pagination Demo");
            Console.WriteLine("11. Exit");
            Console.Write("Please select an option: ");
        }
    }
}
