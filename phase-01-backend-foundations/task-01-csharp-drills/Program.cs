using System.Drawing;
using task_01_csharp_drills.Drills;

namespace task_01_csharp_drills
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool flag;
            double result;
            #region Teperature Convertor
            //Console.WriteLine("Enter a Temperature value: ");
            //flag = double.TryParse(Console.ReadLine(), out result);
            //while (!flag)
            //{
            //    Console.WriteLine("Invalid Temperature value, please Enter a valid value: ");
            //    flag = double.TryParse(Console.ReadLine(), out result);
            //}
            //Console.WriteLine($"{result}\u00B0C = {Drill01_TemperatureConverter.ConvertCelsiustoFahrenheit(result):F2}\u00B0F");
            #endregion

            #region Grade Calaculator
            //Console.WriteLine("Enter Your Grade: ");
            //flag = double.TryParse(Console.ReadLine(), out result);
            //while (!flag)
            //{
            //    Console.WriteLine("Invalid Grade value, please Enter a valid value: ");
            //    flag = double.TryParse(Console.ReadLine(), out result);
            //}

            //while (result > 100 || result < 0)
            //{
            //    Console.WriteLine("Score must be between 0 and 100 ");
            //    flag = double.TryParse(Console.ReadLine(), out result);
            //}
            //Drill_02___Grade_Calculator.GradeCalculator(result);
            #endregion

            #region Login

            // Drill_03___Simple_Login_Validator.LoginValidator();
            #endregion


            #region EvenOdd
            //Drill_04___EvenOdd_Analyzer.EvenOddAnalyzer();
            #endregion

            #region Max and Min Finder
            //List<int> numbers = new List<int>();

            //Console.Write("How many numbers will you enter? ");

            //int count;

            //while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
            //{
            //    Console.Write("Please enter a positive number: ");
            //}

            //for (int i = 0; i < count; i++)
            //{
            //    Console.Write($"Enter number {i + 1}: ");

            //    int number;

            //    while (!int.TryParse(Console.ReadLine(), out number))
            //    {
            //        Console.Write("Invalid input. Enter an integer: ");
            //    }

            //    numbers.Add(number);
            //}

            //Drill_05___Maximum_and_Minimum_Finder.MaxandMinFinder(numbers);

            #endregion

            #region Word Counter
            //Console.WriteLine("Enter your word: ");
            //string word = Console.ReadLine() ?? "";
            //Drill_06___Word_Counter.WordCounter(word);
            #endregion

            #region Name Formatter
            //Console.WriteLine("Enter your word: ");
            //string word = Console.ReadLine() ?? "";
            //Drill_07___Name_Formatter.NameFormatter(word);
            #endregion

            #region Password Strength
            //Console.WriteLine("Enter your Password: ");
            //string word = Console.ReadLine() ?? "";
            //Console.WriteLine(Drill_08___Password_Strength_Checker.PasswordStrengthChecker(word));

            #endregion

            #region Shopping Cart
            //  Drill_09___Shopping_Cart_Total.CalculateShoppingCart();
            #endregion

            #region ATM Menu
            //Drill_10___Simple_ATM_Menu.ATMMenu();
            #endregion

            #region Duplicate Number Detector
            //int[] numbers1 = { 1, 2, 3, 4, 5 };
            //int[] numbers2 = { 1, 2, 2, 3, 1 };
            //int[] numbers3 = { 5, 5, 5, 5 };
            //int[] numbers4 = { };
            //int[] numbers5 = { -5, -5, 5, 5 };

            //Drill_11___Duplicate_Number_Detector.DuplicateNumberDetector(numbers1);
            //Drill_11___Duplicate_Number_Detector.DuplicateNumberDetector(numbers2);
            //Drill_11___Duplicate_Number_Detector.DuplicateNumberDetector(numbers3);
            //Drill_11___Duplicate_Number_Detector.DuplicateNumberDetector(numbers4);
            //Drill_11___Duplicate_Number_Detector.DuplicateNumberDetector(numbers5);
            #endregion

            #region Email Validator

            //    Console.WriteLine("Enter a  Email :");
            //   string Email = Console.ReadLine() ?? "";
            //Drill_12___Email_Validator.EmailValidator(Email);


            #endregion

            #region Palindrom
            //Console.WriteLine("Enter a  word :");
            //string word = Console.ReadLine() ?? "";
            //Drill_13___Palindrome_Checker.PalindromChecker(word);
            #endregion

            #region Simple Expense Tracker
            //List<Expense> expenses = new List<Expense>();
            //Drill_14___Simple_Expense_Tracker.ExpenseTracker(expenses);
            #endregion

            #region Array Rotation
            //int size;
            //do
            //{
            //    Console.WriteLine("Enter your size: ");
            //    flag = int.TryParse(Console.ReadLine(), out size);
            //} while (!flag || size <= 0);
            //int[] array=new int[size];
            //Drill_15___Array_Rotation.ArrayRotation(array);
            #endregion

            #region Frequency Counter
            List<int> numbers = new List<int>();

            int count;

            do
            {
                Console.Write("Enter the number of elements: ");
                flag = int.TryParse(Console.ReadLine(), out count);

            } while (!flag || count <= 0);

            for (int i = 0; i < count; i++)
            {
                int number;

                do
                {
                    Console.Write($"Enter number {i + 1}: ");
                    flag = int.TryParse(Console.ReadLine(), out number);

                } while (!flag);

                numbers.Add(number);
            }

            Drill_16___Frequency_Counter.FrequencyCounter(numbers);
            #endregion

            #region Simple Search Engine
            //List<string> names = new List<string>();

            //int count;
            //do
            //{
            //    Console.Write("Enter number of names: ");
            //    flag = int.TryParse(Console.ReadLine(), out count);

            //} while (!flag || count <= 0);

            //for (int i = 0; i < count; i++)
            //{
            //    string name;

            //    do
            //    {
            //        Console.Write($"Enter name {i + 1}: ");
            //        name = Console.ReadLine() ?? "";

            //    } while (string.IsNullOrWhiteSpace(name));

            //    names.Add(name);
            //}
            //Drill_17___Simple_Search_Engine.SearchEngine(names);
            #endregion

            #region Number Statistics
           // List<int> numbers = new List<int>();

            //int count;

            //do
            //{
            //    Console.Write("Enter number of elements: ");
            //    flag = int.TryParse(Console.ReadLine(), out count);

            //} while (!flag || count <= 0);

            //for (int i = 0; i < count; i++)
            //{
            //    int number;

            //    do
            //    {
            //        Console.Write($"Enter number {i + 1}: ");
            //        flag = int.TryParse(Console.ReadLine(), out number);

            //    } while (!flag);

            //    numbers.Add(number);
            //}

            //Drill_18___Number_Statistics.NumberStatistics(numbers);
            #endregion

            #region Simple Ticket Price Calculator
            //int age;
            //string flagStudent;

            //do
            //{
            //    Console.Write("Enter your age: ");
            //} while (!int.TryParse(Console.ReadLine(), out age) || age < 0);

            //do
            //{
            //    Console.Write("Are you a Student? (Yes/No): ");
            //    flagStudent = Console.ReadLine() ?? "";

            //} while (string.IsNullOrWhiteSpace(flagStudent));

            //Drill_19___Simple_Ticket_Price_Calculator.TicketPriceCalculator(age, flagStudent);
            #endregion

            #region Method Refactoring
            #region ATM Menu
            //Drill_20___Method_Refactoring_Challenge.ATMMenu(); 
            #endregion

            #region Grade Calculator

            //flag = double.TryParse(Console.ReadLine(), out result);
            //while (!flag)
            //{
            //    Console.WriteLine("Invalid Grade value, please Enter a valid value: ");
            //    flag = double.TryParse(Console.ReadLine(), out result);
            //}

            //while (result > 100 || result < 0)
            //{
            //    Console.WriteLine("Score must be between 0 and 100 ");
            //    flag = double.TryParse(Console.ReadLine(), out result);
            //}
            //Drill_02___Grade_Calculator.GradeCalculator(result); 
            #endregion

            #region Array Rotation
           // Drill_20___Method_Refactoring_Challenge.ArrayRotation();
            #endregion
            #endregion

        }
    }
}
