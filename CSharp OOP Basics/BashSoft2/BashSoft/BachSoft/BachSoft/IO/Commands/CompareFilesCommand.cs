using System;
using System.Collections.Generic;
using System.Text;


public class CompareFilesCommand : Command
{
    public CompareFilesCommand(string input, string[] data, Tester judge, StudentRepository repository, IOManager inputOutputManager)
        : base(input, data, judge, repository, inputOutputManager)
    {
    }

    public override void Execute()
    {
        if (Data.Length != 3)
        {
            throw new InvalidCommandException(this.Input);
        }

        string firstPath = Data[1];
        string secondPath = Data[2];

        this.Judge.CompareContent(firstPath, secondPath);
    }
}

