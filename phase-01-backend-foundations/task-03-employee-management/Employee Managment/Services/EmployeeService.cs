using System;
using System.Collections.Generic;
using System.Text;
using task_03_employee_management.Employee_Managment.Models;

namespace task_03_employee_management
{
    public static class EmployeeService
    {
        public static List<Employee> Employees { get;private  set; } = EmployeeSeeding.Seeding();

        public static void AddEmployee(Employee employee) {

            if (employee is null) {

                throw new ArgumentNullException(nameof(employee));
            }
            var Employee = Employees.Find(e => e.EmployeeId == employee.EmployeeId);
            if (Employee is not null) {

                throw new InvalidOperationException("EmployeeId must be unique");

            }

            if (employee.Salary < 0) {

                throw new InvalidOperationException("Salary must not to be negative");

            }

            if (employee.HireDate > DateOnly.FromDateTime(DateTime.Now)) {
                throw new InvalidOperationException("HireDate must not to be in future");
            }

            Employees.Add(employee);
        
        }


        public static void UpdateEmployee(int employeeId,string email,Department department,string position,decimal salary) {

            var employee = Employees.Find(e => e.EmployeeId == employeeId);

            if (employee is null) {

                throw new InvalidOperationException("Employee is not Found! ");
            }


            employee.UpdateEmail(email);
            employee.UpdateDepartment(department);
            employee.UpdatePosition(position);
            employee.UpdateSalary(salary);
            

        }

        public static void DeactivateEmployee(int employeeId) {
            var employee = Employees.Find(e => e.EmployeeId == employeeId);

            if (employee is null)
            {

                throw new InvalidOperationException("Employee is not Found! ");
            }

            employee.UpdateStatus();
        }

        public static List<Employee> SearchEmployees(int? employeeId,string? fullName,string? partialName)
        {
            List<Employee> employees = new List<Employee>();

            if (employeeId.HasValue)
            {
               var employee = Employees.Find(e => e.EmployeeId == employeeId.Value);
                if (employee is  null) {
                    throw new InvalidOperationException("employee is not found");
                }

                employees.Add(employee);
               
            }
            else if (!string.IsNullOrWhiteSpace(fullName))
            {
                var employee = Employees.Find(e =>e.FullName.Equals(fullName, StringComparison.OrdinalIgnoreCase));
                if (employee is null)
                {
                    throw new InvalidOperationException("employee is not found");
                }

                employees.Add(employee);
            }
            else if (!string.IsNullOrWhiteSpace(partialName))
            {
                employees = Employees.Where(e =>e.FullName.Contains(partialName, StringComparison.OrdinalIgnoreCase)).ToList();
                if (employees.Count == 0)
                    throw new InvalidOperationException("employee not found");
            }

           

            return employees;
        }
        public static List<Employee> FilterbyDepartment(Department department) {

            if ( !Enum.IsDefined(typeof(Department), department))
            {

                throw new InvalidOperationException("department is invalid");
            }

            var EmployeesInDepartment = Employees.Where(e => e.Department == department && e.IsActive).ToList();

            if (EmployeesInDepartment.Count == 0) {

                throw new InvalidOperationException($"No Active Employees in Department {department}");

            }


            return EmployeesInDepartment;
        }


        public static List<Employee>  SortEmployees(int sortoption) {

            var employees = new List<Employee>();
            switch (sortoption) {
                case 1:
                    employees = Employees.OrderBy(e => e.Salary).ToList();
                    break;

                case 2:
                    employees = Employees.OrderByDescending(e => e.Salary).ToList();
                    break;

                case 3:
                    employees = Employees.OrderBy(e => e.HireDate).ToList();
                    break;

                case 4:
                    employees = Employees.OrderByDescending(e => e.HireDate).ToList();
                    break;

                case 5:
                    employees = Employees.OrderBy(e => e.FullName).ToList();
                    break;

                default:
                    throw new InvalidOperationException("You must Choose option from 1 to 5 ");
                      
            }

            return employees;
        }
    }
}
