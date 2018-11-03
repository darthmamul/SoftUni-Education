namespace BachSoft.IO.Commands
{
    using BachSoft.Attributes;
    using BachSoft.Contracts;
    using System;

    public abstract class Command : IExecutable
    {
        private string[] data;
        private string input;

        //[Inject]
        //private IDirectoryManager inputOutputManager;

        //[Inject]
        //private IContentComparer judge;

        //[Inject]
        //private IDatabase repository;

        public Command(string input, string[] data)
        {
            this.Input = input;
            this.Data = data;
        }

        public string[] Data
        {
            get => this.data;
            protected set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }

                this.data = value;
            }
        }

        public string Input
        {
            get => this.input;
            protected set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.input = value;
            }
        }

        public abstract void Execute();
    }
}

