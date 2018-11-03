using System;

namespace _04.Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneNumbers = ParseInput();
            var websites = ParseInput();

            var smartphone = new Smartphone();
            foreach (var phoneNumber in phoneNumbers)
            {
                Console.WriteLine(smartphone.Call(phoneNumber));
            }
            foreach (var website in websites)
            {
                Console.WriteLine(smartphone.Browse(website));
            }
        }

        private static string[] ParseInput()
        {
            return Console.ReadLine()
                .Split(new[] { ' ' });
        }
    }
}
