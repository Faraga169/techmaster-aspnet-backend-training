using System;
using System.Collections.Generic;
using System.Text;

namespace task_01_csharp_drills.Drills
{
    public static class Drill_10___Simple_ATM_Menu
    {
        public static void ATMMenu() {

            int option;
            bool flag = false;
            bool optionflag;
            bool depositflag;
            bool withdrawflag;
            decimal amount;
            decimal result;
            decimal Balance = 1000;



            ShowMenu();
            while (!flag) {
              
                do
                {
                    optionflag = int.TryParse(Console.ReadLine(), out option);
                } while (!optionflag);

                switch (option) {

                    case 1:
                        Console.WriteLine($"Balance {Balance}");
                        break;
                    case 2:
                       
                        do {
                            Console.WriteLine("Enter a valid Amount");
                            depositflag = decimal.TryParse(Console.ReadLine(),out amount);
                        }
                        while (!depositflag || amount <= 0) ;
                        Deposit(amount, ref Balance);
                        Console.WriteLine($"Balance {Balance}");
                        break;

                    case 3:

                        do
                        {
                            Console.WriteLine("Enter a valid Amount");
                            withdrawflag = decimal.TryParse(Console.ReadLine(), out amount);
                        }
                        while (!withdrawflag|| amount <= 0);
                        WithDraw(amount,ref Balance);
                        Console.WriteLine($"Balance {Balance}");
                        break;

                    case 4:
                        flag = true;
                        Console.WriteLine("Goodbye!");
                        return;
                       

                    default:
                        Console.WriteLine("Invalid option. Please choose from 1 to 4.");
                        break;

                }
                ShowMenu();
            }

        }


        public static decimal WithDraw(decimal amount,ref decimal Balance) {

            if (amount <= 0) {

                Console.WriteLine("Invalid amount must be positive");
                return Balance;

            }

            if (amount > Balance) {
                Console.WriteLine("Amount exceed Balance Please Try Again");
                return Balance;

            }
            Balance-=amount;
            return Balance;
        }

        public static decimal Deposit(decimal amount, ref decimal Balance)
        {

            if (amount <= 0)
            {

                Console.WriteLine("Invalid amount must be positive");
                return Balance;
            }

          
            Balance += amount;
            return Balance;
        }

        public static void ShowMenu() {

            Console.WriteLine("\n===== Bank Account =====");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
        }
    }
}
