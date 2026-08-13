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

            //flag = double.TryParse(Console.ReadLine(), out result);
            //while (!flag)
            //{
            //    Console.WriteLine("Invalid Temperature value, please Enter a valid value: ");
            //    flag = double.TryParse(Console.ReadLine(), out result);
            //}
            //Console.WriteLine($"{result}\u00B0C = {Drill01_TemperatureConverter.ConvertCelsiustoFahrenheit(result):F2}\u00B0F");
            #endregion

            #region Grade Calaculator
            //flag = double.TryParse(Console.ReadLine(), out result);
            //while (!flag)
            //{
            //    Console.WriteLine("Invalid Grade value, please Enter a valid value: ");
            //    flag = double.TryParse(Console.ReadLine(), out result);
            //}

            //while (result > 100 || result < 0) {
            //    Console.WriteLine("Score must be between 0 and 100 ");
            //    flag = double.TryParse(Console.ReadLine(), out result);
            //}
            //Drill_02___Grade_Calculator.GradeCalculator(result);
            #endregion

            #region Login
            // Console.WriteLine("Enter Your UserName :");
            // string Username = Console.ReadLine() ?? "";
            // Console.WriteLine("Enter Your Password: ");
            //string Password = Console.ReadLine() ?? "";
            // Drill_03___Simple_Login_Validator.LoginValidator(Username, Password);
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
            // Drill_10___Simple_ATM_Menu.ATMMenu();
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
        }
    }
}
