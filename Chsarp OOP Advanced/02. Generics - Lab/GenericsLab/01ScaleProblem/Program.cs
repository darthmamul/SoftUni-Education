using System;

namespace _01ScaleProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Scale<int> scaleInt = new Scale<int>(5, 8);
            Console.WriteLine(scaleInt.GetHeavier());

            Scale<string> stringScale = new Scale<string>("this", "scale");
            Console.WriteLine(stringScale.GetHeavier());

            Scale<bool> scaleBool = new Scale<bool>(true, false);
            Console.WriteLine(scaleBool.GetHeavier());
        }
    }
}
