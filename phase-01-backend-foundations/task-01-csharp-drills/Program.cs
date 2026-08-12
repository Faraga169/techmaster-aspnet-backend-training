using task_01_csharp_drills.Drills;

namespace task_01_csharp_drills
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool flag;
            double result;
            flag = double.TryParse(Console.ReadLine(), out result);
            while (!flag) {
                Console.WriteLine("Invalid Temperature value, please Enter a valid value: ");
                flag = double.TryParse(Console.ReadLine(), out result);
            }
            Console.WriteLine($"{result}\u00B0C = {Drill01_TemperatureConverter.ConvertCelsiustoFahrenheit(result):F2}\u00B0F");
            
        }
    }
}
