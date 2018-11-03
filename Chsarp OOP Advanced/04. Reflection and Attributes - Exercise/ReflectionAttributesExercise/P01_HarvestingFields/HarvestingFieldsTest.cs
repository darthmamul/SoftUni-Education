 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var input = string.Empty;
            var allFields = typeof(HarvestingFields).GetFields(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Static);
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                Console.WriteLine(PrintAllFields(input, allFields));
                
            }
        }

        private static string PrintAllFields(string input, FieldInfo[] allFields)
        {
            var sb = new StringBuilder();
            var fieldClass = typeof(HarvestingFields);

            if (input == "public")
            {
                var publicFields = allFields.Where(f => f.IsPublic);
                foreach (var item in publicFields)
                {
                    sb.AppendLine($"public {item.FieldType.Name} {item.Name}");
                }
            }

            if (input == "private")
            {
                var privateFields = allFields.Where(f => f.IsPrivate);
                foreach (var item in privateFields)
                {
                    sb.AppendLine($"private {item.FieldType.Name} {item.Name}");
                }
            }

            if (input == "protected")
            {
                var protectedFields = allFields.Where(f => f.IsFamily);
                foreach (var item in protectedFields)
                {
                    sb.AppendLine($"protected {item.FieldType.Name} {item.Name}");
                }
            }

            if (input == "all")
            {
                foreach (var field in allFields)
                {
                    var attr = field.Attributes.ToString();
                    if (attr == "Family")
                    {
                        attr = "protected";
                    }
                    sb.AppendLine($"{attr.ToLower()} {field.FieldType.Name} {field.Name}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
