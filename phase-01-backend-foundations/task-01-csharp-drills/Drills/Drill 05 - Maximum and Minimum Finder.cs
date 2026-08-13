using System;
using System.Collections.Generic;
using System.Text;

namespace task_01_csharp_drills.Drills
{
    public static class Drill_05___Maximum_and_Minimum_Finder
    {
        public static void MaxandMinFinder(List<int> numbers)
        {
            // Initialize max with the smallest possible integer value
            // and min with the largest possible integer value.
            double max = int.MinValue;
            double min = int.MaxValue;

            if (numbers is not null && numbers.Count>0) {
                // Loop through all numbers in the list
                foreach (int i in numbers)
                {
                    // If the current number is greater than max,
                    // update max with the current number.
                    if (i > max)
                    {
                        max = i;
                    }

                    // If the current number is smaller than min,
                    // update min with the current number.
                    if (i < min)
                    {
                        min = i;
                    }
                }
            }
           

            // Display the maximum and minimum values.
            Console.WriteLine($"Max: {max} | Min: {min}");
        }
    }
}
