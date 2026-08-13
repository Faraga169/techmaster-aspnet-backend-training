using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace task_01_csharp_drills.Drills
{
    public static class Drill_06___Word_Counter
    {
        public static void WordCounter(string word)
        {
            // Keep asking the user for input while the sentence is empty.
            while (string.IsNullOrEmpty(word))
            {
                Console.WriteLine("Sentence cannot be empty");
                Console.WriteLine("Enter your word: ");

                // Read the user's input.
                // If the input is null, use an empty string instead.
                word = Console.ReadLine() ?? "";
            }

            // Split the sentence into an array of words using space as the separator.
            string[] words = word.Split(' ');

            // Print the number of words.
            Console.WriteLine($"Word count: {words.Length}");
        }
    }
}
