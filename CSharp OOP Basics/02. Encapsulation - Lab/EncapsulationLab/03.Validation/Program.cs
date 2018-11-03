using System;
using System.Collections.Generic;

namespace _03.Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            var personsCount = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int counter = 0; counter < personsCount; counter++)
            {
                var input = Console.ReadLine().Split();
                try
                {
                    var person = new Person(input[0], input[1], int.Parse(input[2]), decimal.Parse(input[3]));
                    persons.Add(person);
                }
                catch (ArgumentException argEx)
                {
                    Console.WriteLine(argEx.Message);
                }
                
            }

            var percentage = decimal.Parse(Console.ReadLine());
            persons.ForEach(p => p.IncreaseSalary(percentage));
            persons.ForEach(p => Console.WriteLine(p));
        }
    }
}
