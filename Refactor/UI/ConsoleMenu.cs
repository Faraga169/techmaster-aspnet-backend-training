using System.Xml.Linq;
using Refactor.Models;
using Refactor.Services;

namespace Refactor.UI
{
    public static class ConsoleMenu
    {
        public static void Run()
        {
            Console.WriteLine("====== Order Calculator ======\n");

            string customerName = ReadCustomerName();
            string productName = ReadProductName();
            decimal price = ReadPrice();
            int quantity = ReadQuantity();
            CustomerType customerType = ReadCustomerType();

            Customer customer = new Customer(customerName, customerType);

            Order order = new Order(productName,price,quantity,customer);

            decimal finalTotal = OrderService.CalculateOrder(order);

            PrintReceipt(order, finalTotal);
        }

        private static string ReadCustomerName()
        {
            Console.Write("Enter customer name: ");
            string? name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Enter customer name: ");
                name = Console.ReadLine();

            }
            return name;
        }

        private static string ReadProductName()
        {
            Console.Write("Enter product name: ");
            string? productName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(productName))
            {
                Console.Write("Enter product name: ");
               productName = Console.ReadLine();
              
            }

            return productName;
        }

        private static decimal ReadPrice()
        {
            decimal price;
            Console.Write("Enter product price: ");

            while (!decimal.TryParse(Console.ReadLine(), out  price) || price <= 0)
            {
                Console.Write("Enter product price: ");

            }

            return price;
        }

        private static int ReadQuantity()
        {
            int quantity;
            while (!int.TryParse(Console.ReadLine(), out quantity)||quantity<=0)
            {
                Console.Write("Enter quantity: ");

            }

            return quantity;
        }

        private static CustomerType ReadCustomerType()
        {
            int option;
            Console.WriteLine("\nCustomer Type:");
            Console.WriteLine("1. Regular");
            Console.WriteLine("2. Silver");
            Console.WriteLine("3. Gold");
            Console.WriteLine("4. VIP");

            Console.Write("Choose customer type: ");
            while (!int.TryParse(Console.ReadLine(), out  option)|| option < 1 || option > 4)
            {
                Console.WriteLine("\nCustomer Type:");
                Console.WriteLine("1. Regular");
                Console.WriteLine("2. Silver");
                Console.WriteLine("3. Gold");
                Console.WriteLine("4. VIP");

                Console.Write("Choose customer type: ");

               
            }

            return (CustomerType)option;
        }

        private static void PrintReceipt(Order order, decimal finalTotal)
        {
            Console.WriteLine("\n================================");
            Console.WriteLine("          ORDER RECEIPT");
            Console.WriteLine("================================");

            Console.WriteLine($"Customer    : {order.Customer.Name}");
            Console.WriteLine($"Product     : {order.ProductName}");
            Console.WriteLine($"Price       : {order.Price:C}");
            Console.WriteLine($"Quantity    : {order.Quantity}");
            Console.WriteLine($"Customer Type: {order.Customer.CustomerType}");

            Console.WriteLine("--------------------------------");

            decimal subtotal =OrderService.CalculateSubTotal(order.Price,order.Quantity);

            decimal discount =OrderService.CalculateDiscount(order.Customer.CustomerType,subtotal);

            decimal afterDiscount = subtotal - discount;

            decimal tax =OrderService.CalculateTax(afterDiscount);

            decimal shipping = OrderService.CalculateShipping(afterDiscount);

            Console.WriteLine($"Subtotal    : {subtotal:C}");
            Console.WriteLine($"Discount    : {discount:C}");
            Console.WriteLine($"After Discount: {afterDiscount:C}");
            Console.WriteLine($"Tax         : {tax:C}");
            Console.WriteLine($"Shipping    : {shipping:C}");
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Final Total : {finalTotal:C}");

            Console.WriteLine("================================");
        }
    }
}