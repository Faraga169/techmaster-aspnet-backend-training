using System;
using System.Collections.Generic;
using System.Text;

namespace task_02_bank_account_system.Bank_Account_System.UI
{
    public static class ConsoleMenu
    {
        public static void ShowMenu() {

            Console.WriteLine("====== TechMaster Bank System ======");
            Console.WriteLine();
            Console.WriteLine("1. Create Customer Account");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. Transfer Money");
            Console.WriteLine("5. View Account Details");
            Console.WriteLine("6. View Transaction History");
            Console.WriteLine("7. View All Accounts");
            Console.WriteLine("8. Exit");
            Console.Write("Choose an option: ");
        }
    }
}
