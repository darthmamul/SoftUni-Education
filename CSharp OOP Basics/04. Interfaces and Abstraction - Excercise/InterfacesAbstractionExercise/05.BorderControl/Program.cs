using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            List<SocietyMember> societyMembers = GetSocietyMembers();
            GetMembersWithInvalidIds(societyMembers);
        }

        private static List<SocietyMember> GetSocietyMembers()
        {
            var societyMembers = new List<SocietyMember>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var tokens = ParseInput(input);
                switch (tokens.Length)
                {
                    case 2:
                        string model = tokens[0];
                        string id = tokens[1];
                        societyMembers.Add(new Robot(id, model));
                        break;
                    case 3:
                        string name = tokens[0];
                        int age = int.Parse(tokens[1]);
                        id = tokens[2];
                        societyMembers.Add(new Citizen(id, name, age));
                        break;
                    default:
                        break;
                }
            }

            return societyMembers;
        }

        private static void GetMembersWithInvalidIds(List<SocietyMember> societyMembers)
        {
            var idEnding = Console.ReadLine();

            societyMembers
                .Where(m => m.HasInvalidEnding(idEnding))
                .ToList()
                .ForEach(m => Console.WriteLine(m.Id));
        }

        private static string[] ParseInput(string input)
        {
            return input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
