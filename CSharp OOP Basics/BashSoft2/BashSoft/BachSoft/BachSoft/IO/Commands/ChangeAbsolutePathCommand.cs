using System;
using System.Collections.Generic;
using System.Text;


public class ChangeAbsolutePathCommand : Command
{
    public ChangeAbsolutePathCommand(string input, string[] data, Tester judge, StudentRepository repository, IOManager inputOutputManager)
        : base(input, data, judge, repository, inputOutputManager)
    {
    }

    public override void Execute()
    {
        if (Data.Length != 2)
        {
            throw new InvalidCommandException(this.Input);
        }

        string absolutePath = Data[1];
        this.InputOutputManager.ChangeCurrentDirectoryAbsolute(absolutePath);
    }
}

