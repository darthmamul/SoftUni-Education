using System;
using System.Reflection;

namespace _02.CreatingConstructors
{
    class CreatingConstructors
    {
        static void Main(string[] args)
        {
            Type personType = typeof(Person);
            FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(fields.Length);

            //var pesho = new Person("Pesho", 20);
            //var gosho = new Person("Gosho", 18);
            //var stamat = new Person("Stamat", 43);

            //Console.WriteLine(pesho.name + " " + pesho.age);
            //Console.WriteLine(gosho.name + " " + gosho.age);
            //Console.WriteLine(stamat.name + " " + stamat.age);
        }
    }
}
