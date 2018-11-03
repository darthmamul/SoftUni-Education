using MiniORM.App.Data;
using MiniORM.App.Data.Entities;
using System.Linq;

namespace MiniORM.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            const string connectionString = @"Server=\\EnterServeName\SQLEXPRESS;Database=MiniORM;Integrated Security=True";

            var context = new SoftUniDbContext(connectionString);

            //var employees = context.Employees.ToList();

            var newEmployee = new Employee
            {
                FirstName = "Gosho",
                LastName = "Goshev",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            };

            context.Employees.Add(newEmployee);
            context.SaveChanges();

            var secondEmployee = new Employee
            {
                FirstName = "Sasho",
                LastName = "Sashev",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            };

            context.Employees.Add(secondEmployee);
            context.SaveChanges();
        }
    }
}
