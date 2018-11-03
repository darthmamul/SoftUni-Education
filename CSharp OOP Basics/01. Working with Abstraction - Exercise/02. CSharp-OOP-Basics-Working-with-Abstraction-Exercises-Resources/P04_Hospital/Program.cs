using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] commandTokens = command.Split();
                var departament = commandTokens[0];
                var patient = commandTokens[3];
                var fullName = $"{commandTokens[1]} {commandTokens[2]}";

                CreateDepartment(doctors, departments, departament, fullName);

                AddPatient(doctors, departments, departament, patient, fullName);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split();

                int room = 0;

                List<string> result = GetResult(doctors, departments, room, tokens);

                Console.WriteLine(string.Join(Environment.NewLine, result));
                command = Console.ReadLine();
            }
        }

        private static List<string> GetResult(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, int room, string[] tokens)
        {
            if (tokens.Length == 1)
            {
                string department = tokens[0];
                return departments[department].Where(x => x.Count > 0).SelectMany(x => x).ToList();
            }
            else if (tokens.Length == 2 && int.TryParse(tokens[1], out room))
            {
                string department = tokens[0];
                return departments[department][room - 1].OrderBy(x => x).ToList();
            }
            else
            {
                string doctor = $"{tokens[0]} {tokens[1]}";
                return doctors[doctor].OrderBy(x => x).ToList();
            }
        }

        private static void CreateDepartment(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string departament,string fullName)
        {
            if (!doctors.ContainsKey(fullName))
            {
                doctors[fullName] = new List<string>();
            }
            if (!departments.ContainsKey(departament))
            {
                departments[departament] = new List<List<string>>();
                for (int rooms = 0; rooms < 20; rooms++)
                {
                    departments[departament].Add(new List<string>());
                }
            }
        }

        private static void AddPatient(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string departament, string patient, string fullName)
        {
            bool isFreePlace = departments[departament].SelectMany(x => x).Count() < 60;
            if (isFreePlace)
            {
                int room = 0;
                doctors[fullName].Add(patient);

                for (int i = 0; i < departments[departament].Count; i++)
                {
                    if (departments[departament][i].Count < 3)
                    {
                        room = i;
                        break;
                    }
                }
                departments[departament][room].Add(patient);
            }
        }
    }
}
