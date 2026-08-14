using System;
using System.Collections.Generic;
using System.Text;

namespace task_01_csharp_drills.Drills
{
    public static class Drill_03___Simple_Login_Validator
    {
        public static void LoginValidator() {

            const string UserNameAnswer = "Ahmed";
            const string PasswordAnswer = "Ahmed169";

            int i = 0;

            while (i < 3) {
                string username;
                string password;
                do
                {
                    Console.Write("Enter Your UserName: ");
                    username = Console.ReadLine() ?? "";
                }
                while (string.IsNullOrWhiteSpace(username));

                do
                {
                    Console.Write("Enter Your Password: ");
                    password = Console.ReadLine() ?? "";
                }
                while (string.IsNullOrWhiteSpace(password));

                if (String.Equals(username, UserNameAnswer, StringComparison.OrdinalIgnoreCase) && String.Equals(PasswordAnswer, password))
                {
                    Console.WriteLine("Login successful.");
                    return;
                }
               
                i++;

                if (i <3)
                {
                    Console.WriteLine("Invalid UserName or Password");
                    
                }
            }


            Console.WriteLine("Account locked. Too many failed attempts.");






        }
    }
}
