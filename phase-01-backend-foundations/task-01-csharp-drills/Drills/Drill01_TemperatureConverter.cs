using System;
using System.Collections.Generic;
using System.Text;

namespace task_01_csharp_drills.Drills
{
    public static class Drill01_TemperatureConverter
    {



        public static double ConvertCelsiustoFahrenheit(double temperature) 
        {

            double result = temperature * 9 / 5 + 32;
            return result;


        }
           
          
    }
}
