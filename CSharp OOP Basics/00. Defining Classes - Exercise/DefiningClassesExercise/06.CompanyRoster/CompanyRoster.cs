using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CompanyRoster
{
    class CompanyRoster
    {
        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>();
            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] employeeInput = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string departmentName = employeeInput[3];


                if (!departments.Any(d => d.Name == departmentName))
                {
                    Department dep = new Department(departmentName);
                    departments.Add(dep);
                }

                var department = departments.FirstOrDefault(d => d.Name == departmentName);
                Employee employee = ParseEmployee(employeeInput);
                department.AddEmployee(employee);
            }

            var highestAverageDepartment = departments
                .OrderByDescending(d => d.AverageSalary)
                .First();

            Console.WriteLine($"Highest Average Salary: {highestAverageDepartment.Name}");

            foreach (var employee in highestAverageDepartment.Employees.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
            }

        }

        static Employee ParseEmployee(string[] employeeInput)
        {
            string name = employeeInput[0];
            decimal salary = decimal.Parse(employeeInput[1]);
            string position = employeeInput[2];
            string email = "n/a";
            int age = -1;

            if (employeeInput.Length == 6)
            {
                email = employeeInput[4];
                age = int.Parse(employeeInput[5]);
            }
            else if (employeeInput.Length == 5)
            {
                bool isAge = int.TryParse(employeeInput[4], out age);
                if (!isAge)
                {
                    email = employeeInput[4];
                    age = -1;
                }
            }

            Employee employee = new Employee(name, position, salary, age, email);
            return employee;
        }
    }
}
