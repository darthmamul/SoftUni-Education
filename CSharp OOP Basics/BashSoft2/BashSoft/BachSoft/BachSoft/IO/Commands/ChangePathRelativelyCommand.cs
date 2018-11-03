using System;
using System.Collections.Generic;
using System.Text;


public class ChangePathRelativelyCommand : Command
{
    public ChangePathRelativelyCommand(string input, string[] data, Tester judge, StudentRepository repository, IOManager inputOutputManager)
        : base(input, data, judge, repository, inputOutputManager)
    {
    }

    public override void Execute()
    {
        throw new NotImplementedException();
    }
}

