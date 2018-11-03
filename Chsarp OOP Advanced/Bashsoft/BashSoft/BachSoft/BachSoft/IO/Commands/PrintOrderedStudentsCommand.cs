﻿namespace BachSoft.IO
{
    using BachSoft.Attributes;
    using BachSoft.Contracts;
    using BachSoft.IO.Commands;
    using System;

    [Alias("order")]
    public class PrintOrderedStudentsCommand : Command
    {
        [Inject]
        private IDatabase repository;

        public PrintOrderedStudentsCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public IDatabase Repository
        {
            get => this.repository;
            private set => this.repository = value;
        }

        private void TryParseParameterForOrderAndTake(string takeCommand, string takeQuantity, string courseName, string comparison)
        {
            if (takeCommand.Equals("take"))
            {
                if (takeQuantity.Equals("all"))
                {
                    this.repository.OrderAndTake(courseName, comparison);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        this.repository.OrderAndTake(courseName, comparison, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
        }

        public override void Execute()
        {
            if (this.Data.Length != 5)
            {
                throw new InvalidCommandException(this.Input);
            }
            string courseName = this.Data[1];
            string order = this.Data[2].ToLower();
            string takeCommand = this.Data[3].ToLower();
            string takeQuantity = this.Data[4].ToLower();

            this.TryParseParameterForOrderAndTake(takeCommand, takeQuantity, courseName, order);
        }
    }
}
