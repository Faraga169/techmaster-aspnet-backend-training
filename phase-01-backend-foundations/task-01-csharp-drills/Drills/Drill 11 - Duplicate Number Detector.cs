using System;
using System.Collections.Generic;
using System.Text;

namespace task_01_csharp_drills.Drills
{
     public class Drill_11___Duplicate_Number_Detector
    {
        public static void DuplicateNumberDetector(int[] list)
        {
            // Check if the list is null or empty before processing it.
            if (list == null || list.Length == 0)
            {
                Console.WriteLine("List is empty");
                return;
            }

            // Store numbers that have been encountered for the first time.
            HashSet<int> seen = new HashSet<int>();

            // Store numbers that appear more than once.
            // HashSet prevents the same duplicate from being added multiple times.
            HashSet<int> duplicates = new HashSet<int>();

            // Loop through all numbers in the list.
            for (int i = 0; i < list.Length; i++)
            {
                // Add the current number to 'seen'.
                // Add() returns false if the number already exists in the HashSet,
                // which means that the number is duplicated.
                if (!seen.Add(list[i]))
                {
                    duplicates.Add(list[i]);
                }
            }

            // Check whether any duplicate numbers were found.
            if (duplicates.Count == 0)
            {
                Console.WriteLine("No Duplicates Found");
            }
            else
            {
                // Print all unique duplicate numbers.
                Console.WriteLine($"Duplicates: {string.Join(", ", duplicates)}");
            }
        }
    }
}
