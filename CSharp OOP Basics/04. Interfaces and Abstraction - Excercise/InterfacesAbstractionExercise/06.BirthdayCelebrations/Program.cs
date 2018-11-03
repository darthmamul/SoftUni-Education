using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.BirthdayCelebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBirthday> societyMembersWithBirthdates = GetSocietyMembers();
            GetMembersByBirthdate(societyMembersWithBirthdates);
        }

        private static void GetMembersByBirthdate(List<IBirthday> societyMembers)
        {
            var year = Console.ReadLine();

            societyMembers
                .Where(sm => sm.BirthDate.EndsWith(year))
                .ToList()
                .ForEach(sm => Console.WriteLine(sm.BirthDate));
        }

        private static List<IBirthday> GetSocietyMembers()
        {
            var societyMembers = new List<IBirthday>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var tokens = ParseInput(input);

                var memberType = tokens[0].ToLower();
                tokens = tokens.Skip(1).ToArray();

                switch (memberType)
                {
                    case "citizen":
                        string name = tokens[0];
                        int age = int.Parse(tokens[1]);
                        string id = tokens[2];
                        string birthdate = tokens[3];
                        societyMembers.Add(new Citizen(id, name, age, birthdate));
                        break;
                    case "pet":
                        name = tokens[0];
                        birthdate = tokens[1];
                        societyMembers.Add(new Pet(name, birthdate));
                        break;
                    default:
                        break;
                }
            }

            return societyMembers;
        }

        private static string[] ParseInput(string input)
        {
            return input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
