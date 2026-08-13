using System;
using System.Collections.Generic;
using System.Text;

namespace task_01_csharp_drills.Drills
{
    public class Drill_07___Name_Formatter
    {
        public static void NameFormatter(string word)
        {
            // Keep asking for the full name while the input is empty or null.
            while (string.IsNullOrEmpty(word))
            {
                Console.WriteLine("Sentence cannot be empty");
                Console.WriteLine("Enter your full Name: ");

                // Read the user's input.
                // If the input is null, use an empty string instead.
                word = Console.ReadLine() ?? "";
            }

            // Remove spaces from the beginning and end,
            // then split the name into separate parts.
            // RemoveEmptyEntries prevents empty elements caused by extra spaces.
            string[] words = word.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            // Process each part of the name separately.
            for (int i = 0; i < words.Length; i++)
            {
                // Convert the whole name part to lowercase first.
                words[i] = words[i].ToLower();

                // Convert the first character to uppercase
                // and combine it with the rest of the word.
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
            }

            // Join all formatted name parts with a single space
            // and print the final formatted name.
            Console.WriteLine(string.Join(' ', words));
        }
    }
}
