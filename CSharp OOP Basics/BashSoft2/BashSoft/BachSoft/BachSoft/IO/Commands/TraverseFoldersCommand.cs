using System;
using System.Collections.Generic;
using System.Text;


public class TraverseFoldersCommand : Command
{
    public TraverseFoldersCommand(string input, string[] data, Tester judge, StudentRepository repository, IOManager inputOutputManager)
        : base(input, data, judge, repository, inputOutputManager)
    {
    }

    public override void Execute()
    {
        if (Data.Length == 1)
        {
            this.InputOutputManager.TraverseDirectory(0);
        }
        else if (Data.Length == 2)
        {
            int depth;
            bool hasParsed = int.TryParse(Data[1], out depth);
            if (hasParsed)
            {
                this.InputOutputManager.TraverseDirectory(depth);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.UnableToParseNumber);
            }
        }
    }
}

