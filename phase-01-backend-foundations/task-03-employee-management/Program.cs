using Microsoft.VisualBasic.FileIO;
using task_03_employee_management.Employee_Managment.Models;

namespace task_03_employee_management
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            bool flag;
            int option;
            int employeeId;
            string fullName;
            string email;
            string position;
            decimal salary;
            DateOnly hireDate;
            int phoneNumber;
            Department department;
            string managerName;
            while (!exit)
            {
                Console.Clear();

                do
                {
                    ConsoleMenu.ShowMenu();
                    flag = int.TryParse(Console.ReadLine(), out option);
                } while (!flag);

                try
                {
                    switch (option)
                    {
                        
                        case 1:
                            Console.Clear();
                            Console.WriteLine("===== Add Employee =====");

                            do {
                                Console.Write("Employee ID: ");
                                flag = int.TryParse(Console.ReadLine(), out employeeId);
                            } while (!flag);

                            do {
                                Console.Write("Full Name: ");
                                fullName = Console.ReadLine() ?? "";
                            } while (string.IsNullOrEmpty(fullName));

                            do
                            {
                                Console.Write("Email: ");
                                email = Console.ReadLine() ?? "";
                            } while (string.IsNullOrEmpty(email));
                           

                            Console.WriteLine("Choose Department:");
                            Console.WriteLine("1. IT");
                            Console.WriteLine("2. Marketing");
                            Console.WriteLine("3. Software");
                            Console.WriteLine("4. Sales");
                            Console.Write("Choose: ");

                            while (!Enum.TryParse(Console.ReadLine(),out  department) ||!Enum.IsDefined(typeof(Department), department))
                            {
                                Console.WriteLine("Choose a valid Department: ");
                            }

                            do
                            {
                                Console.Write("Position: ");
                                position = Console.ReadLine() ?? "";
                            } while (string.IsNullOrEmpty(position));

                            do
                            {
                                Console.Write("Salary: ");
                                flag= decimal.TryParse(Console.ReadLine(), out salary);
                            } while (!flag);


                            do
                            {
                                Console.Write("Hire Date (yyyy-MM-dd): ");
                               flag= DateOnly.TryParse(Console.ReadLine(),out hireDate);
                            } while (!flag||hireDate>DateOnly.FromDateTime(DateTime.Now));


                            do
                            {
                                Console.Write("Phone Number: ");
                               flag = int.TryParse(Console.ReadLine(), out phoneNumber);
                            } while (!flag);



                            do
                            {
                                Console.Write("Manager Name: ");
                                managerName = Console.ReadLine() ?? "";
                            } while (string.IsNullOrEmpty(managerName));
                           

                            Employee employee = new Employee(
                                employeeId,
                                fullName,
                                email,
                                department,
                                position,
                                salary,
                                hireDate,
                                phoneNumber,
                                managerName
                            );

                            EmployeeService.AddEmployee(employee);

                            Console.WriteLine("Employee added successfully!");

                            break;


                        case 2:
                            Console.Clear();
                            Console.WriteLine("===== Update Employee =====");

                            do
                            {
                                Console.Write("Employee ID: ");
                                flag = int.TryParse(Console.ReadLine(), out employeeId);
                            } while (!flag);



                            do
                            {
                                Console.Write("Email: ");
                                email = Console.ReadLine() ?? "";
                            } while (string.IsNullOrEmpty(email));

                            Console.WriteLine("Choose New Department:");
                            Console.WriteLine("1. IT");
                            Console.WriteLine("2. Marketing");
                            Console.WriteLine("3. Software");
                            Console.WriteLine("4. Sales");
                            Console.Write("Choose: ");

                            while (!Enum.TryParse(Console.ReadLine(),out  department) ||!Enum.IsDefined(typeof(Department),department))
                            {
                                Console.WriteLine("Choose a valid Department: ");
                            }

                            do
                            {
                                Console.Write("Position: ");
                                position = Console.ReadLine() ?? "";
                            } while (string.IsNullOrEmpty(position));

                            do
                            {
                                Console.Write("Salary: ");
                                flag = decimal.TryParse(Console.ReadLine(), out salary);
                            } while (!flag);
                            EmployeeService.UpdateEmployee(
                                employeeId,
                                email,
                                department,
                                position,
                                salary
                            );

                            Console.WriteLine("Employee updated successfully!");

                            break;


                        case 3:
                            int deactivateId;
                            Console.Clear();
                            Console.WriteLine("===== Deactivate Employee =====");


                            do {

                                Console.Write("Employee ID: ");
                                flag = int.TryParse(Console.ReadLine(),  out  deactivateId);

                            } while (!flag);
                          

                            EmployeeService.DeactivateEmployee(deactivateId);

                            Console.WriteLine("Employee deactivated successfully!");

                            break;


                        case 4:
                            int searchOption;
                            string searchName;
                            List<Employee> foundEmployee=null!;
                            string partialName;
                            int searchId;

                           Console.Clear();
                            Console.WriteLine("===== Search Employee =====");

                          

                            do {
                                Console.WriteLine("Search By:");
                                Console.WriteLine("1. Employee ID");
                                Console.WriteLine("2. Full Name");
                                Console.WriteLine("3. Partial Name");
                                Console.Write("Choose: ");
                                flag =int.TryParse(Console.ReadLine(),out searchOption);
                            } while (!flag|| searchOption<1||searchOption>3);
                            

                          

                            if (searchOption == 1)
                            {
                                do {

                                    Console.Write("Employee ID: ");
                                   flag= int.TryParse(Console.ReadLine(),out searchId);
                                } while (!flag);
                              

                                foundEmployee =EmployeeService.SearchEmployees(searchId,null,null);
                            }
                            else if (searchOption == 2)
                            {
                                do
                                {
                                    Console.Write("Full Name: ");
                                    searchName = Console.ReadLine() ?? "";
                                } while (string.IsNullOrEmpty(searchName));

                                foundEmployee =EmployeeService.SearchEmployees(null,searchName,null);
                            }
                            else if (searchOption == 3)
                            {
                                do
                                {
                                    Console.Write("Partial Name: ");
                                    partialName = Console.ReadLine() ?? "";
                                } while (string.IsNullOrEmpty(partialName));

                                foundEmployee =EmployeeService.SearchEmployees(null, null,partialName);
                            }

                            foreach (Employee i in foundEmployee) {

                                Console.WriteLine("------------------------------");
                                Console.WriteLine(
                                    $"ID         : {i.EmployeeId}");
                                Console.WriteLine(
                                    $"Name       : {i.FullName}");
                                Console.WriteLine(
                                    $"Email      : {i.Email}");
                                Console.WriteLine(
                                    $"Department : {i.Department}");
                                Console.WriteLine(
                                    $"Position   : {i.Position}");
                                Console.WriteLine(
                                    $"Salary     : {i.Salary}");
                                Console.WriteLine(
                                    $"Status     : {(i.IsActive ? "Active" : "Inactive")}");
                                Console.WriteLine("------------------------------");
                            }
                           

                            break;


                        case 5:
                            Department filterDepartment;
                            Console.Clear();
                            Console.WriteLine("===== Filter By Department =====");

                            Console.WriteLine("1. IT");
                            Console.WriteLine("2. Marketing");
                            Console.WriteLine("3. Software");
                            Console.WriteLine("4. Sales");
                            Console.Write("Choose Department: ");

                            while (!Enum.TryParse(Console.ReadLine(), out  filterDepartment) ||!Enum.IsDefined(typeof(Department), filterDepartment))
                            {
                                Console.WriteLine("Choose a valid Department: ");
                            }

                            var employees = EmployeeService.FilterbyDepartment(filterDepartment);

                            foreach (var emp in employees)
                            {
                                Console.WriteLine(
                                    $"{emp.EmployeeId} | " +
                                    $"{emp.FullName} | " +
                                    $"{emp.Department} | " +
                                    $"{emp.Position} | " +
                                    $"{emp.Salary}");
                            }

                            break;


                        case 6:
                            int sortOption;

                           Console.Clear();
                            Console.WriteLine("===== Sort Employees =====");

                          

                            do
                            {
                                Console.WriteLine("1. Salary Ascending");
                                Console.WriteLine("2. Salary Descending");
                                Console.WriteLine("3. Hire Date Ascending");
                                Console.WriteLine("4. Hire Date Descending");
                                Console.WriteLine("5. Name Ascending");

                                Console.Write("Choose: ");
                                flag = int.TryParse(Console.ReadLine(), out sortOption);
                            } while (!flag || sortOption < 1 || sortOption > 5);
                           

                            var sortedEmployees =EmployeeService.SortEmployees(sortOption);

                            foreach (var emp in sortedEmployees)
                            {
                                Console.WriteLine(
                                    $"{emp.FullName,-20} " +
                                    $"{emp.Salary,-10} " +
                                    $"{emp.HireDate}");
                            }

                            break;


                        case 7:
                            Console.Clear();

                            EmployeeReportService.SalaryReports();

                            break;


                        case 8:
                            Console.Clear();
                            Console.WriteLine("===== All Employees =====");

                            foreach (var emp in EmployeeService.Employees)
                            {
                                Console.WriteLine(
                                    $"ID: {emp.EmployeeId} | " +
                                    $"Name: {emp.FullName} | " +
                                    $"Department: {emp.Department} | " +
                                    $"Salary: {emp.Salary} | " +
                                    $"Status: {(emp.IsActive ? "Active" : "Inactive")}");
                            }

                            break;


                        case 9:
                            exit = true;
                            Console.WriteLine("Goodbye!");

                            break;


                        default:
                            Console.WriteLine("Choose an option from 1 to 9.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Error: {ex.Message}");
                }

                if (!exit)
                {
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }

        }
    }
}
