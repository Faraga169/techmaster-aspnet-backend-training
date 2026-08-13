using System;
using System.Collections.Generic;
using System.Text;

namespace task_01_csharp_drills.Drills
{
    public static class Drill_09___Shopping_Cart_Total
    {
        public static void CalculateShoppingCart()
        {
            // Store the validation status of the user's input.
            bool flag;

            // Store the subtotal for each item.
            decimal subtotal;

            // Store the total price of all items.
            decimal total = 0;

            // Store the number of different items in the cart.
            int itemsCount;

            // Store the price and quantity of each item.
            decimal price;
            int quantity;

            // Store the discount amount and the final price after discount.
            decimal discount;
            decimal final;

            // Keep asking for the number of items until a valid integer is entered.
            do
            {
                Console.WriteLine("Enter valid items count: ");
                flag = int.TryParse(Console.ReadLine(), out itemsCount);

            } while (!flag|| itemsCount <= 0);

            // Process each item in the shopping cart.
            for (int i = 0; i < itemsCount; i++)
            {
                // Keep asking for the price until a valid decimal value is entered.
                do
                {
                    Console.WriteLine("Enter a valid price per item: ");
                    flag = decimal.TryParse(Console.ReadLine(), out price);

                } while (!flag || price <= 0);

                // Keep asking for the quantity until a valid positive integer is entered.
                do
                {
                    Console.WriteLine("Enter a valid quantity per item: ");
                    flag = int.TryParse(Console.ReadLine(), out quantity);

                } while (!flag || quantity <= 0);

                // Calculate the subtotal for the current item.
                subtotal = price * quantity;

                // Add the current item's subtotal to the total.
                total += subtotal;
            }

            // Apply a 10% discount if the total is greater than 1000.
            if (total > 1000)
            {
                discount = total * 0.10m;
                final = total - discount;

                Console.WriteLine($"discount {discount}, Final {final}");
            }
            else
            {
                // No discount is applied when the total is 1000 or less.
                Console.WriteLine("No discount");
            }
        }
    }
}
