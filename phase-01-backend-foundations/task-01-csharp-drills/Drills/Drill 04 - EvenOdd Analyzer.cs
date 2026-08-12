using System;
using System.Collections.Generic;
using System.Text;

namespace task_01_csharp_drills.Drills
{
    public static class Drill_04___EvenOdd_Analyzer
    {
        public static void EvenOddAnalyzer() {

            Console.Write("How many numbers will you enter? ");

            int count;

            while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
            {
                Console.Write("Please enter a positive number: ");
            }

            List<int> evenNumbers = new List<int>();
            List<int> oddNumbers = new List<int>();

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter number {i + 1}: ");

                int number;

                while (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.Write("Invalid input. Please enter an integer: ");
                }

                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
                else
                {
                    oddNumbers.Add(number);
                }
            }

            Console.WriteLine($"Even numbers: {(evenNumbers.Count > 0 ? string.Join(", ", evenNumbers) : "Empty")}");
            Console.WriteLine($"Even count: {evenNumbers.Count}");

            Console.WriteLine($"Odd numbers: {(oddNumbers.Count > 0 ? string.Join(", ", oddNumbers) : "Empty")}");
            Console.WriteLine($"Odd count: {oddNumbers.Count>0}");
        }
    }
}
