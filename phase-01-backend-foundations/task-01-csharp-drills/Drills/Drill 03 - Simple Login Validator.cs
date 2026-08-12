using System;
using System.Collections.Generic;
using System.Text;

namespace task_01_csharp_drills.Drills
{
    public static class Drill_03___Simple_Login_Validator
    {
        public static void LoginValidator(string Username,string Password) {

            const string UserNameAnswer = "Ahmed";
            const string PasswordAnswer = "Ahmed169";

            int i = 0;

            while (i < 2) {
                if (String.Equals(Username, UserNameAnswer, StringComparison.OrdinalIgnoreCase) && String.Equals(PasswordAnswer, Password))
                {
                    Console.WriteLine("Login successful.");
                    break;
                }

                Console.WriteLine("Invalid UserName or Password");
                Console.WriteLine("Enter Your UserName :");
                Username = Console.ReadLine() ?? "";
                Console.WriteLine("Enter Your Password: ");
                Password = Console.ReadLine() ?? "";

                i++;
            }

            if (i == 2) {
                Console.WriteLine("Account locked. Too many failed attempts.");
            }
           

             
            

        }
    }
}
