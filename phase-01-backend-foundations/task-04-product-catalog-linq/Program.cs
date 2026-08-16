using task_04_product_catalog_linq.Model;
using task_04_product_catalog_linq.Services;
using task_04_product_catalog_linq.UI;

internal class Program
{
    static void Main(string[] args)
    {
        bool exit = false;
        bool flag;
        int option;

        while (!exit)
        {
            Console.Clear();

            do
            {
                ConsoleMenu.ShowMenu();

                flag = int.TryParse(Console.ReadLine(), out option);

                if (!flag || option < 1 || option > 11)
                {
                    Console.WriteLine("Choose an option from 1 to 11.");
                }

            } while (!flag || option < 1 || option > 11);

            try
            {
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("===== Available Products =====");

                        var availableProducts =ProductService.GetAllAvailableProducts();

                        foreach (var product in availableProducts)
                        {
                            Console.WriteLine(
                                $"ID: {product.ProductId} | " +
                                $"Name: {product.Name} | " +
                                $"Category: {product.Category} | " +
                                $"Price: {product.Price} | " +
                                $"Stock: {product.StockQuantity}");
                        }

                        break;


                    case 2:
                        Console.Clear();
                        Console.WriteLine("===== Filter By Category =====");

                        string category;

                        do
                        {
                            Console.Write("Enter Category: ");
                            category = Console.ReadLine() ?? "";

                        } while (string.IsNullOrWhiteSpace(category));

                        var categoryProducts =
                            ProductService.FilterByCategory(category);

                        foreach (var product in categoryProducts)
                        {
                            Console.WriteLine(
                                $"{product.ProductId} | " +
                                $"{product.Name} | " +
                                $"{product.Category} | " +
                                $"{product.Price}");
                        }

                        break;


                    case 3:
                        Console.Clear();
                        Console.WriteLine("===== Filter By Price Range =====");

                        decimal minPrice;
                        decimal maxPrice;

                        do
                        {
                            Console.Write("Minimum Price: ");
                            flag = decimal.TryParse(Console.ReadLine(),out minPrice);

                            if (!flag || minPrice < 0)
                            {
                                Console.WriteLine("Minimum price must be a valid positive number.");
                            }

                        } while (!flag || minPrice < 0);


                        do
                        {
                            Console.Write("Maximum Price: ");
                            flag = decimal.TryParse(
                                Console.ReadLine(),
                                out maxPrice);

                            if (!flag || maxPrice < minPrice)
                            {
                                Console.WriteLine("Maximum price must be greater than or equal to minimum price.");
                            }

                        } while (!flag || maxPrice < minPrice);


                        var priceProducts =ProductService.FilterByPrice(minPrice, maxPrice);

                        foreach (var product in priceProducts)
                        {
                            Console.WriteLine(
                                $"{product.Name,-25} | " +
                                $"{product.Price}");
                        }

                        break;


                    case 4:
                        Console.Clear();
                        Console.WriteLine("===== Search By Name =====");

                        string productName;

                        do
                        {
                            Console.Write("Product Name: ");
                            productName = Console.ReadLine() ?? "";

                        } while (string.IsNullOrWhiteSpace(productName));


                        var searchedProduct =ProductService.SearchByproductName(productName);

                        Console.WriteLine($"ID: {searchedProduct.ProductId}");

                        Console.WriteLine($"Name: {searchedProduct.Name}");

                        Console.WriteLine($"Category: {searchedProduct.Category}");

                        Console.WriteLine(
                            $"Price: {searchedProduct.Price}");

                        Console.WriteLine($"Stock: {searchedProduct.StockQuantity}");

                        Console.WriteLine($"Available: {searchedProduct.IsAvailable}");

                        break;


                    case 5:
                        Console.Clear();
                        Console.WriteLine("===== Sort By Price =====");

                        int sortOption;

                        do
                        {
                            Console.WriteLine("1. Price Ascending");
                            Console.WriteLine("2. Price Descending");
                            Console.Write("Choose: ");

                            flag = int.TryParse(Console.ReadLine(),out sortOption);

                        } while (!flag ||sortOption < 1 ||sortOption > 2);


                        List<Products> sortedProducts;

                        if (sortOption == 1)
                        {
                            sortedProducts =ProductService.SearchBypriceAscending();
                        }
                        else
                        {
                            sortedProducts = ProductService.SearchBypriceDescending();
                        }


                        foreach (var product in sortedProducts)
                        {
                            Console.WriteLine(
                                $"{product.Name,-25} | " +
                                $"{product.Price}");
                        }

                        break;


                    case 6:
                        Console.Clear();
                        Console.WriteLine("===== Group By Category =====");

                        ProductService.GroupProductsByCategory();

                        break;


                    case 7:
                        Console.Clear();
                        Console.WriteLine("===== Stock Value Reports =====");

                        ProductService.CalaculateStockPerCategory();

                        break;


                    case 8:
                        Console.Clear();
                        Console.WriteLine("===== Low Stock Products =====");

                        var lowStockProducts =
                            ProductService.LowStockProducts();

                        foreach (var product in lowStockProducts)
                        {
                            Console.WriteLine(
                                $"{product.Name,-25} | " +
                                $"Stock: {product.StockQuantity}");
                        }

                        break;


                    case 9:
                        Console.Clear();
                        Console.WriteLine("===== Supplier Report =====");

                        ProductService.SupplierReport();

                        break;


                    case 10:
                        Console.Clear();
                        Console.WriteLine("===== Pagination =====");

                        int pageNumber;
                        int pageSize;

                        do
                        {
                            Console.Write("Page Number: ");

                            flag = int.TryParse(Console.ReadLine(),out pageNumber);

                        } while (!flag || pageNumber <= 0);


                        do
                        {
                            Console.Write("Page Size: ");

                            flag = int.TryParse(Console.ReadLine(), out pageSize);

                        } while (!flag || pageSize <= 0);


                        var products =ProductService.Pagination(pageNumber,pageSize);

                        Console.WriteLine();
                        Console.WriteLine(
                            $"===== Page {pageNumber} =====");

                        foreach (var product in products)
                        {
                            Console.WriteLine(
                                $"{product.ProductId} | " +
                                $"{product.Name} | " +
                                $"{product.Price} | " +
                                $"Stock: {product.StockQuantity}");
                        }

                        break;


                    case 11:
                        exit = true;
                        Console.WriteLine("Goodbye!");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine($"Error: {ex.Message}");
            }

            if (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}