using System;

namespace _07.InfernoInfinity
{
    class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();
            Engine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
