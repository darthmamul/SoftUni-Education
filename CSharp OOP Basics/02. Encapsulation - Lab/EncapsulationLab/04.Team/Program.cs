using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Teams
{
    class Program
    {
        static void Main(string[] args)
        {
            var team = new Team("my team");
            var personsCount = int.Parse(Console.ReadLine());
            //var persons = new List<Person>();
            for (int counter = 0; counter < personsCount; counter++)
            {
                var input = Console.ReadLine().Split();
                try
                {
                    var person = new Person(input[0], input[1], int.Parse(input[2]), decimal.Parse(input[3]));
                    team.AddPlayer(person);
                }
                catch (ArgumentException argEx)
                {
                    Console.WriteLine(argEx.Message);
                }

            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}

