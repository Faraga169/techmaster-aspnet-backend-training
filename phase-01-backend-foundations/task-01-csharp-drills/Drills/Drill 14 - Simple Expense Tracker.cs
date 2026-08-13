using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace task_01_csharp_drills.Drills
{
    public class Expense {

       
        public Expense(string name, decimal amount)
        {
            Name = name;
            this.Amount = amount;
        }

        public decimal Amount { get; set; }

        public string Name { get; set; }

    }
    public static class Drill_14___Simple_Expense_Tracker
    {
        public static void ExpenseTracker(List<Expense> expenses) {

          
            int noofexpenses;
            decimal expenseAmount;
            bool flag;
            decimal Total=0;
            decimal Average;
            decimal HighestExpenseAmount = decimal.MinValue;
            List<string> highestExpenseNames = new List<string>();


            do
            {
                Console.WriteLine("Enter a number of expenses: ");
                flag = int.TryParse(Console.ReadLine(), out noofexpenses);

            } while (!flag || noofexpenses <= 0);

            for (int i = 0; i < noofexpenses; i++)
            {
                string expenseName = "";
                while (string.IsNullOrEmpty(expenseName))
                {
                    Console.WriteLine("Enter a valid expense Name :");
                    expenseName = Console.ReadLine() ?? "";
                }

                do
                {
                    Console.WriteLine("Enter a valid expense amount: ");
                    flag = decimal.TryParse(Console.ReadLine(), out expenseAmount);

                } while (!flag||expenseAmount<=0);

                expenses.Add(new Expense(expenseName, expenseAmount));

            }

            for (int i = 0; i < expenses.Count; i++) {
                if (expenses[i].Amount > HighestExpenseAmount) { 
                
                    HighestExpenseAmount=expenses[i].Amount;
                    highestExpenseNames.Add(expenses[i].Name);

                }
                else if (expenses[i].Amount == HighestExpenseAmount)
                {
                    highestExpenseNames.Add(expenses[i].Name);
                }

                Total += expenses[i].Amount;

            }

            Average=Total/expenses.Count;
            Console.WriteLine($"Total {Total}, Average {Average}, Highest {string.Join(',',highestExpenseNames)}");
        }
    }
}
