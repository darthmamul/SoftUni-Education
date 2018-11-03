using BachSoft.Attributes;
using BachSoft.Contracts;
using BachSoft.IO.Commands;

namespace BachSoft.IO
{
    [Alias("cdabs")]
    public class ChangeAbsolutePathCommand : Command
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public ChangeAbsolutePathCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public IDirectoryManager InputOutputManager
        {
            get => this.inputOutputManager;
            private set => this.inputOutputManager = value;
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }
            string absolutePath = this.Data[1];
            this.inputOutputManager.ChangeCurrentDirectoryAbsolute(absolutePath);
        }
    }
}

