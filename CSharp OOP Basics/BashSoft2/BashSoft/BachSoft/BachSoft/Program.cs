using System;
using System.IO;
//using BachSoft.StudentRepository;

namespace BachSoft
{
    public class Launcher
    {
        public static void Main(string[] args)
        {
            Tester tester = new Tester();
            IOManager ioManager = new IOManager();
            StudentRepository repo = new StudentRepository(new RepositorySorter(), new RepositoryFilter());

            CommandInterpreter currentInterpreter = new CommandInterpreter(tester, repo, ioManager);
            InputReader reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}
