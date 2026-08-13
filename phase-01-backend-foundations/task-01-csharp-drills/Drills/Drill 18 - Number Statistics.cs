using System;
using System.Collections.Generic;
using System.Text;

namespace task_01_csharp_drills.Drills
{
    public static class Drill_18___Number_Statistics
    {
        public static void NumberStatistics(List<int> Numbers)
        {
            int PositiveCount = 0;
            int NegativeCount = 0;
            decimal Sum = 0;
            decimal Average;
            decimal Max = decimal.MinValue;
            decimal Min = decimal.MaxValue;

            if (Numbers is not null && Numbers.Count>0) {

                for (int i = 0; i < Numbers.Count; i++)
                {

                    if (Numbers[i] > 0)
                    {

                        PositiveCount++;
                    }

                    if (Numbers[i] < 0)
                    {

                        NegativeCount++;
                    }

                    if (Max < Numbers[i])
                    {
                        Max = Numbers[i];
                    }

                    if (Min > Numbers[i])
                    {
                        Min = Numbers[i];
                    }

                    if (Numbers[i] == 0) {

                        continue;
                    }

                    Sum += Numbers[i];
                }
            }
          

            Average = Sum / Numbers.Count;
            Console.WriteLine($"PositiveCount {PositiveCount}, NegativeCount {NegativeCount},Count {Numbers.Count}, Sum {Sum}, Average {Average}, Max {Max}, Min {Min}");
        }
    }
}
