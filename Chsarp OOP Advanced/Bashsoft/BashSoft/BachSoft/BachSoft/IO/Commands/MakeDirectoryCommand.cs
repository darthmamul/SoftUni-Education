﻿using BachSoft.Attributes;
using BachSoft.Contracts;
using BachSoft.IO.Commands;

namespace BachSoft.IO
{
    [Alias("mkdir")]
    public class MakeDirectoryCommand : Command
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public MakeDirectoryCommand(string input, string[] data)
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

            string folderName = this.Data[1];
            this.inputOutputManager.CreateDirectoryInCurrentFolder(folderName);
        }
    }
}

