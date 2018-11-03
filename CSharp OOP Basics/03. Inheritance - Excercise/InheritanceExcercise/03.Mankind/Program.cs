using System;

namespace _03.Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var studentInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                string facultyNumber = studentInfo[2];
                var student = new Student(firstName, lastName, facultyNumber);

                var workerInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string workerFirstName = workerInfo[0];
                string workerLastName = workerInfo[1];
                decimal salary = decimal.Parse(workerInfo[2]);
                decimal workingHoursPerDay = decimal.Parse(workerInfo[3]);
                var worker = new Worker(workerFirstName, workerLastName, salary, workingHoursPerDay);

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            


        }
    }
}
