using System;
using System.Collections.Generic;
using System.Text;

namespace task_01_csharp_drills.Drills
{
    public static class Drill_08___Password_Strength_Checker
    {
        public static string PasswordStrengthChecker(string password)
        {
            // Assume that the password is strong initially.
            // If any requirement is not satisfied, flag will be set to false.
            bool flag = true;

            // These flags track whether the password contains
            // at least one lowercase letter, uppercase letter,
            // digit, and special character.
            bool hasLower = false;
            bool hasUpper = false;
            bool hasDigit = false;
            bool hasSpecial = false;

            // Store all missing password requirements.
            List<string> result = new List<string>();

            // Keep asking for a password while the input is empty.
            while (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Password cannot be empty");
                Console.WriteLine("Enter your Password: ");

                // Read the user's input.
                // If the input is null, use an empty string instead.
                password = Console.ReadLine() ?? "";
            }

            // Check if the password contains at least 8 characters.
            if (password.Length < 8)
            {
                flag = false;
                result.Add("length must be greater than 7");
            }

            // Check every character in the password
            // to determine which character types are present.
            for (int i = 0; i < password.Length; i++)
            {
                // Check for at least one lowercase letter.
                if (char.IsLower(password[i]))
                {
                    hasLower = true;
                }

                // Check for at least one uppercase letter.
                if (char.IsUpper(password[i]))
                {
                    hasUpper = true;
                }

                // Check for at least one digit.
                if (char.IsDigit(password[i]))
                {
                    hasDigit = true;
                }

                // If the character is neither a letter nor a digit,
                // consider it a special character.
                if (!char.IsLetterOrDigit(password[i]))
                {
                    hasSpecial = true;
                }
            }

            // Check which required character types are missing.
            if (!hasLower)
            {
                flag = false;
                result.Add("lowercase");
            }

            if (!hasUpper)
            {
                flag = false;
                result.Add("uppercase");
            }

            if (!hasDigit)
            {
                flag = false;
                result.Add("digit");
            }

            if (!hasSpecial)
            {
                flag = false;
                result.Add("special character");
            }

            // If all requirements are satisfied, return Strong.
            if (flag)
            {
                return "Strong";
            }
            else
            {
                // Otherwise, return Weak and show the missing requirements.
                return "Weak - missing " + string.Join(',', result);
            }
        }
    }
}
