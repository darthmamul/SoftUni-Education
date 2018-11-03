using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReflectionAttributesLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //Type list = typeof(List<>);
            //Console.WriteLine(list.Name);
            //Console.WriteLine(list.FullName);

            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            Type[] allTypes = currentAssembly.GetTypes();

            Type simpleClassType = typeof(SimpleClass);
            SimpleClass sclInstance = (SimpleClass)Activator.CreateInstance(simpleClassType, "ThisText");

            //FieldInfo[] fields = simpleClassType.GetFields(
            //    BindingFlags.Instance |
            //    BindingFlags.NonPublic |
            //    BindingFlags.Static |
            //    BindingFlags.Public);

            //foreach (FieldInfo field in fields)
            //{
            //    if (field.Name == "simpleStr")
            //    {
            //        field.SetValue(sclInstance, "teststr");
            //    }
            //}

            //FieldInfo wantedField = simpleClassType.GetField("simpleStr", BindingFlags.NonPublic | BindingFlags.Instance);

            //FieldInfo wantedField = fields.FirstOrDefault(f => f.Name == "simpleStr");

            //Console.WriteLine(wantedField.GetValue(sclInstance));

            MethodInfo[] allMethods = simpleClassType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (MethodInfo method in allMethods)
            {
                Console.WriteLine(method.Name);
            }


            //Type[] ctorParamsTypes = { typeof(string) };

            //ConstructorInfo[] ctors = simpleClassType.GetConstructors();

            //SimpleClass anotherInstance = null;

            //foreach (ConstructorInfo ctor in ctors)
            //{
            //    ParameterInfo[] ctorParams = ctor.GetParameters();
            //    if (ctorParams.Length == 1)
            //    {
            //        if (ctorParams.First().ParameterType == typeof(string))
            //        {
            //            anotherInstance = (SimpleClass)ctor.Invoke(new object[] { "Pesho" });
            //        }
            //    }
            //}

            //if (anotherInstance != null)
            //{
            //    Console.WriteLine(anotherInstance.SomeProp);
            //}

            //SimpleClass scSecondInstance = (SimpleClass)ctorStr.Invoke(new object[] { });

            //Console.WriteLine(scSecondInstance.SomeProp);


            //sclInstance.SomeProp = "AnotherText";

            //Console.WriteLine(sclInstance.SomeProp);


            //foreach (Type type in allTypes)
            //{
            //    Console.WriteLine(type.Name);
            //    Type[] interfaces = type.GetInterfaces();
            //    foreach (Type intrface in interfaces)
            //    {
            //        Console.WriteLine(intrface.FullName);
            //    }
            //}


        }
    }
}
