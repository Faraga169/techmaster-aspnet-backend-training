using System;
using System.Collections.Generic;
using System.Text;

namespace task_01_csharp_drills.Drills
{
    public static class Drill_20___Method_Refactoring_Challenge
    {
        #region Simple ATM Menu
        public static decimal ReadAmount()
        {
            decimal amount;

            do
            {
                Console.Write("Enter a valid Amount: ");
            }
            while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0);

            return amount;
        }
        public static int ReadOption()
        {
            int option;

            do
            {
                Console.Write("Choose an option: ");
            }
            while (!int.TryParse(Console.ReadLine(), out option));

            return option;
        }
        public static void ATMMenu()
        {

            bool flag = false;
            decimal Balance = 1000;



            ShowMenu();
            while (!flag)
            {



                switch (ReadOption())
                {

                    case 1:
                        PrintBalance(Balance);
                        break;
                    case 2:


                        Deposit(ReadAmount(), ref Balance);
                        PrintBalance(Balance);
                        break;

                    case 3:


                        WithDraw(ReadAmount(), ref Balance);
                        PrintBalance(Balance);
                        break;

                    case 4:
                        flag = true;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose from 1 to 4.");
                        break;

                }
                ShowMenu();
            }

        }

        public static void PrintBalance(decimal balance)
        {
            Console.WriteLine($"Balance: {balance}");
        }
        public static decimal WithDraw(decimal amount, ref decimal Balance)
        {

            if (amount <= 0)
            {

                Console.WriteLine("Invalid amount must be positive");
                return Balance;

            }

            if (amount > Balance)
            {
                Console.WriteLine("Amount exceed Balance Please Try Again");
                return Balance;

            }
            Balance -= amount;
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

        public static void ShowMenu()
        {

            Console.WriteLine("\n===== Bank Account =====");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
        } 
        #endregion



        #region Calaculate Grade
        public static string CalculateGrade(double grade)
        {
            if (grade >= 90)
                return "A";

            if (grade >= 80)
                return "B";

            if (grade >= 70)
                return "C";

            if (grade >= 60)
                return "D";

            return "F";
        }
        #endregion

        #region Array Rotation
        public static void ArrayRotation()
        {
            int[] array = ReadArray();

            RotateRight(array);

            PrintArray(array);
        }

        public static int[] ReadArray()
        {
            int size;

            do
            {
                Console.Write("Enter array size: ");
            }
            while (!int.TryParse(Console.ReadLine(), out size) || size <= 0);

            int[] array = new int[size];

            for (int i = 0; i < array.Length; i++)
            {
                bool flag;

                do
                {
                    Console.Write($"Enter number {i + 1}: ");
                    flag = int.TryParse(Console.ReadLine(), out array[i]);

                } while (!flag);
            }

            return array;
        }

        public static void RotateRight(int[] array)
        {
            if (array is null || array.Length <= 1)
                return;

            int temp = array[array.Length - 1];

            for (int i = array.Length - 1; i > 0; i--)
            {
                array[i] = array[i - 1];
            }

            array[0] = temp;
        }

        public static void PrintArray(int[] array)
        {
            Console.WriteLine($"Rotated Array: {string.Join(", ", array)}");
        }
        #endregion
    }


}

