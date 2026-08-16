using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using task_03_employee_management.Employee_Managment.Models;

namespace task_03_employee_management
{
    public static class EmployeeReportService
    {
       
        //        Average salary.
        //Highest salary employee.
        //Lowest salary employee.
        //Total payroll.
        //Employees count by department.
        //Active/inactive counts.

        public static decimal AverageSalary() {
            var SumSalaryofEmployees = EmployeeService.Employees.Sum(e => e.Salary);
            var EmployeesCount= EmployeeService.Employees.Count();
            var AverageSalary = SumSalaryofEmployees / EmployeesCount;
            return AverageSalary;
        }


        public static Employee HighestSalary()
        {
            var HighestSalaryofEmployees = EmployeeService.Employees.MaxBy(e => e.Salary);
            if (HighestSalaryofEmployees is null)
                throw new InvalidOperationException("No Employee Has max salary");
            return HighestSalaryofEmployees;
        }


        public static Employee MinSalary()
        {
            var LowestSalaryofEmployees = EmployeeService.Employees.MinBy(e => e.Salary);
            if (LowestSalaryofEmployees is null)
                throw new InvalidOperationException("No Employee Has min salary");
            return LowestSalaryofEmployees;
        }


        public static decimal TotalPayroll() {

            var totalPayroll = EmployeeService.Employees.Sum(e => e.Salary);
            return totalPayroll;
        }

        public static void EmployeeCountperDepartment() {

            var Employee = EmployeeService.Employees.GroupBy(e => e.Department).Select(e=>new { Department=e.Key,Count=e.Count()});
            foreach (var i in Employee) {

                Console.WriteLine(
            $"  {i.Department,-12}: {i.Count} Employees"
        );
            }
        }


        public static void CountActiveAndInactiveEmployees() {
            var ActiveEmployee = EmployeeService.Employees.Where(e => e.IsActive).Count();
            var InActiveEmployee= EmployeeService.Employees.Where(e => e.IsActive==false).Count();

            Console.WriteLine($"Active Accounts = {ActiveEmployee}");
            Console.WriteLine($"InActive Accounts = {InActiveEmployee}");
        }


        public static void SalaryReports()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("           EMPLOYEE SALARY REPORT");
            Console.WriteLine("==========================================");

            // Average Salary
            Console.WriteLine($"Average Salary    : {AverageSalary():C}");

            // Highest Salary Employee
            var highestSalary = HighestSalary();
            Console.WriteLine(
                $"Highest Salary    : {highestSalary.FullName} - {highestSalary.Salary:C}"
            );

            // Lowest Salary Employee
            var lowestSalary = MinSalary();
            Console.WriteLine(
                $"Lowest Salary     : {lowestSalary.FullName} - {lowestSalary.Salary:C}"
            );

            // Total Payroll
            Console.WriteLine($"Total Payroll     : {TotalPayroll():C}");

            Console.WriteLine("------------------------------------------");

            // Employees Count By Department
            Console.WriteLine("Employees By Department:");
            EmployeeCountperDepartment();

            Console.WriteLine("------------------------------------------");

            // Active / Inactive
            CountActiveAndInactiveEmployees();

            Console.WriteLine("==========================================");
        }
    }
}
