using System;
using System.Collections.Generic;
using System.Text;

namespace task_01_csharp_drills.Drills
{
    public static class Drill_15___Array_Rotation
    {
        public static void ArrayRotation(int[] array) {
            int temp;
            bool flag=false;
            int size;
            int j = 0;
            
           

            while (!flag||j<array.Length) 
            {
                Console.WriteLine("Enter your numbers :");
                flag = int.TryParse(Console.ReadLine(), out array[j]);
                j++;
              
            }

          
            if (array is not null) {

                temp = array[array.Length - 1];

                for (int i = array.Length - 1; i > 0; i--)
                {
                    array[i] = array[i - 1];
                }

                array[0] = temp;
            }


                Console.WriteLine(string.Join(',',array));

        }
    }
}
