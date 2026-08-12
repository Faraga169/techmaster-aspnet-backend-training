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
            flag = double.TryParse(Console.ReadLine(), out result);
            while (!flag)
            {
                Console.WriteLine("Invalid Grade value, please Enter a valid value: ");
                flag = double.TryParse(Console.ReadLine(), out result);
            }

            while (result > 100 || result < 0) {
                Console.WriteLine("Score must be between 0 and 100 ");
                flag = double.TryParse(Console.ReadLine(), out result);
            }
            Drill_02___Grade_Calculator.GradeCalculator(result);
            #endregion

        }
    }
}
