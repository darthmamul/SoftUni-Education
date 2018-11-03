using System;
using System.Collections.Generic;
using System.Reflection;

namespace _01.StealerProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.StealFieldInfo("Hacker", "username", "password");
            Console.WriteLine(result);
        }
    }
}
