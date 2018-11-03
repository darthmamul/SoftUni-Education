﻿using System;
using System.Reflection;

namespace _01.DefineAClassPerson
{
    class DefineAClassPerson
    {
        static void Main(string[] args)
        {
            Type personType = typeof(Person);
            ConstructorInfo emptyCtor = personType.GetConstructor(new Type[] { });
            ConstructorInfo ageCtor = personType.GetConstructor(new[] { typeof(int) });
            ConstructorInfo nameAgeCtor = personType.GetConstructor(new[] { typeof(string), typeof(int) });

            bool swapped = false;
            if (nameAgeCtor == null)
            {
                nameAgeCtor = personType.GetConstructor(new[] { typeof(int), typeof(string) });
                swapped = true;
            }

            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Person basePerson = (Person)emptyCtor.Invoke(new object[] { });
            Person personWithAge = (Person)ageCtor.Invoke(new object[] { age });
            Person personWithAgeAndName = swapped ? (Person)nameAgeCtor.Invoke(new object[] { age, name }) :
                (Person)nameAgeCtor.Invoke(new object[] { name, age });

            Console.WriteLine($"{basePerson.Name} {basePerson.Age}");
            Console.WriteLine($"{personWithAge.Name} {personWithAge.Age}");
            Console.WriteLine($"{personWithAgeAndName.Name} {personWithAgeAndName.Age}");



        }
    }
}