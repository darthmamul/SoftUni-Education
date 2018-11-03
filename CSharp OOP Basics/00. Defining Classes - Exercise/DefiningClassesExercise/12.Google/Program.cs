using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.Google
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("End"))
                {
                    break;
                }

                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var personName = tokens[0];

                if (!people.Any(p => p.Name == personName))
                {
                    people.Add(new Person(personName));
                }

                var currentPerson = people.FirstOrDefault(p => p.Name == personName);

                if (tokens[1].Equals("company"))
                {
                    currentPerson.Company.Name = tokens[2];
                    currentPerson.Company.Department = tokens[3];
                    currentPerson.Company.Salary = decimal.Parse(tokens[4]);
                }
                else if (tokens[1].Equals("pokemon"))
                {
                    var pokemon = new Pokemon(tokens[2], tokens[3]);
                    currentPerson.Pokemons.Add(pokemon);
                }
                else if (tokens[1].Equals("parents"))
                {
                    currentPerson.Parents.Add(new Parent(tokens[2], tokens[3]));
                }
                else if (tokens[1].Equals("children"))
                {
                    currentPerson.Children.Add(new Child(tokens[2], tokens[3]));
                }
                else
                {
                    currentPerson.Car.Model = tokens[2];
                    currentPerson.Car.Speed = int.Parse(tokens[3]);
                }
            }

            var name = Console.ReadLine().Trim();
            var person = people.FirstOrDefault(p => p.Name == name);
            Console.WriteLine(person);
        }
    }
}
