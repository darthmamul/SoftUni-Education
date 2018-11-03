using BachSoft.Contracts;
using BachSoft.IO;

namespace BachSoft
{
    public class Launcher
    {
        public static void Main(string[] args)
        {
            IContentComparer tester = new Tester();
            IDirectoryManager ioManager = new IOManager();
            IDatabase repo = new StudentRepository(new RepositorySorter(), new RepositoryFilter());

            IInterpreter currentInterpreter = new CommandInterpreter(tester, repo, ioManager);
            IInputReader reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}
