﻿using BachSoft.Attributes;
using BachSoft.Contracts;
using BachSoft.IO.Commands;

namespace BachSoft.IO
{
    [Alias("readdb")]
    public class ReadDatabaseCommand : Command
    {
        [Inject]
        private IDatabase repository;

        public ReadDatabaseCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public IDatabase Repository
        {
            get => this.repository;
            private set => this.repository = value;
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }
            string fileName = this.Data[1];
            this.repository.LoadData(fileName);
        }
    }
}

