using System;
using System.Collections.Generic;
using System.Text;

namespace task_01_csharp_drills.Drills
{
    public static class Drill_17___Simple_Search_Engine
    {
        public static void SearchEngine(List<string> Names) {

            string SearchWord="";
            bool flag=false;
            while (string.IsNullOrEmpty(SearchWord)) {
                Console.WriteLine("Enter a valid Search word: ");
                SearchWord = Console.ReadLine() ?? "";
            }


            for (int i = 0; i < Names.Count; i++) {

                if (Names[i].ToLower().Contains(SearchWord.ToLower())) {
                    flag = true;
                    Console.WriteLine($"{string.Join(',', Names[i])}");
                    
                  
                }
              
            }

            if (!flag) {
                Console.WriteLine("Not found");
            }


            

        }
    }
}
