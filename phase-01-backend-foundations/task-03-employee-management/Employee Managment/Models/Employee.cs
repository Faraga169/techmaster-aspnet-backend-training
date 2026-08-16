using System;
using System.Collections.Generic;
using System.Text;
using task_03_employee_management.Employee_Managment.Models;

namespace task_03_employee_management
{
    public class Employee
    {
        public Employee(int employeeId,string fullName,string email,Department department,string position,decimal salary,DateOnly hireDate,int phoneNumber,string managerName)
        {
            EmployeeId= employeeId;
            FullName= fullName;
            Email= email;
            Department= department;
            Position= position;
            Salary= salary;
            HireDate= hireDate;
            IsActive = true;
            PhoneNumber= phoneNumber;
            ManagerName= managerName;
        }
        public int EmployeeId { get; private set; }

        public string FullName { get; private set; } = null!;

        public string Email { get; private set; } = null!;

        public Department Department { get; private set; }

        public string Position { get; private set; } = null!;

        public decimal Salary { get; private set; }

        public DateOnly HireDate { get; private set; }

        public bool IsActive { get; private set; }

        public int PhoneNumber { get;private set; }

        public string ManagerName { get; private set; } = null!;

        public DateTime CreateAt { get; private set; } = DateTime.Now;

        public void UpdateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required.");

            Email = email;
        }

        public void UpdatePosition(string position)
        {
            if (string.IsNullOrWhiteSpace(position))
                throw new ArgumentException("position is required.");

            Position= position;
        }

        public void UpdateDepartment(Department department)
        {
            if ( !Enum.IsDefined(typeof(Department), department))
            {

                throw new InvalidOperationException("department is invalid");
            }

            Department = department;
        }

        public void UpdateSalary(decimal salary)
        {
            if (salary < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(salary),"Salary cannot be negative.");
            }

            Salary=salary;
        }

        public void UpdateStatus() {

            IsActive = false;
        }

    }
}
