using System;
using System.Collections.Generic;
using System.Text;

namespace task_01_csharp_drills.Drills
{
    public static class Drill_12___Email_Validator
    {
        public static void EmailValidator(string Email)
        {

            // Keep asking for the email while the input is empty or null.
            while (string.IsNullOrEmpty(Email))
            {
                Console.WriteLine("Enter a valid Email :");
                Email = Console.ReadLine() ?? "";
            }

            // Check all basic email requirements at once.
            // The email must:
            // - Contain '@'
            // - Contain '.'
            // - Not start with '@'
            // - Not end with '@'
            // - Not contain spaces
            if (Email.Contains('@') &&
                Email.Contains('.') &&
                !Email.StartsWith("@") &&
                !Email.EndsWith('@') &&
                !Email.Contains(" "))
            {
                Console.WriteLine("Valid Email");
            }

            // Check if '@' is missing.
            if (!Email.Contains('@'))
            {
                Console.WriteLine("Invalid: email requires '@'.");
            }

            // Check if '.' is missing.
            if (!Email.Contains('.'))
            {
                Console.WriteLine("Invalid: email requires '.'.");
            }

            // Check if the email starts with '@'.
            if (Email.StartsWith("@"))
            {
                Console.WriteLine("Invalid: email must not start with '@'.");
            }

            // Check if the email ends with '@'.
            if (Email.EndsWith("@"))
            {
                Console.WriteLine("Invalid: email must not end with '@'.");
            }

            // Check if the email contains spaces.
            if (Email.Contains(" "))
            {
                Console.WriteLine("Invalid: email must not contain spaces.");
            }
        }
    }
}
