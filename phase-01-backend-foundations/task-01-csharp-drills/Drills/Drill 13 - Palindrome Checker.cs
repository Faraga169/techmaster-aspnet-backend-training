using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace task_01_csharp_drills.Drills
{
    public static class Drill_13___Palindrome_Checker
    {
        public static void PalindromChecker(string word)
        {
            while (string.IsNullOrEmpty(word)||word.Length<2)
            {
                Console.WriteLine("Enter a valid word :");
                word = Console.ReadLine() ?? "";
            }

            string checker = word.Trim().ToLower();
            if (checker.Contains(" "))
            {

                checker = checker.Replace(" ", "");

            }
          

            if (CheckPalindrom(checker))
            {
                Console.WriteLine("Not Palindrom");
            }
            else {
                Console.WriteLine("Palindrom");
            }

        }

        public static bool CheckPalindrom(string word) {

            for (int i = 0; i < word.Length; i++)
            {

                if (word[i] != word[word.Length - 1 - i])
                {

                    return true;
                   

                }
            }
            return false;
        }
    }
}
