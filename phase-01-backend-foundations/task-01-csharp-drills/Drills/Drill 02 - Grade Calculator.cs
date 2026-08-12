using System;
using System.Collections.Generic;
using System.Text;

namespace task_01_csharp_drills.Drills
{
    public static class Drill_02___Grade_Calculator
    {
        public static void GradeCalculator(double Grade) {


            if (Grade <= 100 && Grade >= 90)
            {

                Console.WriteLine("Grade A");
            }

            else if (Grade <= 89 && Grade >= 80)
            {

                Console.WriteLine("Grade B");
            }

            else if (Grade <= 79 && Grade >= 70)
            {

                Console.WriteLine("Grade C");
            }

            else if (Grade <= 69 && Grade >= 60)
            {

                Console.WriteLine("Grade D");
            }

            else  
            {

                Console.WriteLine("Grade F");
            }

         

        }
        }
    }

