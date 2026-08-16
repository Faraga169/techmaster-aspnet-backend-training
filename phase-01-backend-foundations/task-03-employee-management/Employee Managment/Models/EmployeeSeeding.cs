using System;
using System.Collections.Generic;
using System.Text;

namespace task_03_employee_management.Employee_Managment.Models
{
    public static class EmployeeSeeding
    {
        public static List<Employee> Seeding()
        {
            List<Employee> employees = new List<Employee>() {

            new Employee(
            1,
            "Ahmed Ali",
            "ahmed.ali@company.com",
            Department.IT,
            "Backend Developer",
            25000,
            new DateOnly(2022, 3, 15),
            1000000001,
            "Mohamed Hassan"
        ),

        new Employee(
            2,
            "Sara Mohamed",
            "sara.mohamed@company.com",
            Department.Marketing,
            "Marketing Specialist",
            19000,
            new DateOnly(2023, 1, 10),
            1000000002,
            "Mona Ahmed"
        ),

        new Employee(
            3,
            "Omar Hassan",
            "omar.hassan@company.com",
            Department.Software,
            "Software Engineer",
            22000,
            new DateOnly(2021, 7, 20),
            1000000003,
            "Khaled Samir"
        ),

        new Employee(
            4,
            "Mariam Adel",
            "mariam.adel@company.com",
            Department.IT,
            "Frontend Developer",
            23000,
            new DateOnly(2024, 2, 5),
            1000000004,
            "Ahmed Ali"
        ),

        new Employee(
            5,
            "Youssef Mostafa",
            "youssef.mostafa@company.com",
            Department.Sales,
            "Sales Executive",
            16000,
            new DateOnly(2023, 9, 12),
            1000000005,
            "Hany Mahmoud"
        ),

        new Employee(
            6,
            "Nour Ibrahim",
            "nour.ibrahim@company.com",
            Department.Marketing,
            "Marketing Coordinator",
            18000,
            new DateOnly(2022, 11, 1),
            1000000006,
            "Dina Samir"
        ),

        new Employee(
            7,
            "Mahmoud Tarek",
            "mahmoud.tarek@company.com",
            Department.Software,
            "Senior Software Engineer",
            28000,
            new DateOnly(2020, 5, 18),
            1000000007,
            "Ahmed Ali"
        ),

        new Employee(
            8,
            "Hana Khaled",
            "hana.khaled@company.com",
            Department.IT,
            "System Administrator",
            21000,
            new DateOnly(2024, 6, 25),
            1000000008,
            "Ahmed Ali"
        ),

        new Employee(
            9,
            "Karim Sameh",
            "karim.sameh@company.com",
            Department.Software,
            "Software Architect",
            32000,
            new DateOnly(2019, 8, 30),
            1000000009,
            "Khaled Samir"
        ),

        new Employee(
            10,
            "Nada Emad",
            "nada.emad@company.com",
            Department.Sales,
            "Sales Manager",
            30000,
            new DateOnly(2018, 4, 10),
            1000000010,
            "Hany Mahmoud"
        )

            };

            return employees;
        }
    }
}
