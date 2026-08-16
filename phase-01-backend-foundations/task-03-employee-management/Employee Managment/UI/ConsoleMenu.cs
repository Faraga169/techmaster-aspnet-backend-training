using System;
using System.Collections.Generic;
using System.Text;

namespace task_03_employee_management
{
    public static class ConsoleMenu
    {
        public static void ShowMenu()
        {
            Console.WriteLine("====== Employee Management System ======");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Update Employee");
            Console.WriteLine("3. Deactivate Employee");
            Console.WriteLine("4. Search Employee");
            Console.WriteLine("5. Filter by Department");
            Console.WriteLine("6. Sort Employees");
            Console.WriteLine("7. Show Salary Reports");
            Console.WriteLine("8. View All Employees");
            Console.WriteLine("9. Exit");
            Console.Write("   Choose an option: ");
        }
    }
}
