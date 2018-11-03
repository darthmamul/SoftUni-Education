namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var type = typeof(BlackBoxInteger);
            var classInstance = Activator.CreateInstance(type, true);
            var fields = type.GetFields(
               BindingFlags.Instance |
               BindingFlags.NonPublic);

            var methods = type.GetMethods(
                BindingFlags.Instance |
                BindingFlags.NonPublic);

            var input = Console.ReadLine();
            while (input != "END")
            {
                var commands = input.Split('_');
                var methodName = commands[0];
                var value = int.Parse(commands[1]);

                methods.FirstOrDefault(m => m.Name == methodName).Invoke(classInstance, new object[] { value });

                foreach (var field in fields)
                {
                    Console.WriteLine(field.GetValue(classInstance));
                }
                input = Console.ReadLine();
            }
        }
    }
}
