using System;
using System.Collections.Generic;
using System.Text;


public interface IPerson : IBuyer
{
    string Name { get; }
    int Age { get; }
}

