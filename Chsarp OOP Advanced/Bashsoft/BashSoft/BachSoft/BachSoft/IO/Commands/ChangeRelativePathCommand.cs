namespace BachSoft.IO
{
    using BachSoft.Attributes;
    using BachSoft.Contracts;
    using BachSoft.IO.Commands;
    using System;

    [Alias("cdrel")]
    public class ChangePathRelativelyCommand : Command
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public ChangePathRelativelyCommand(string input, string[] data)
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
            string relativePath = this.Data[1];
            this.inputOutputManager.ChangeCurrentDirectoryRelative(relativePath);
        }
    }
}

