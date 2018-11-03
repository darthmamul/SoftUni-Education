using System;
using System.Collections.Generic;
using System.Text;


public interface IMyList : IAddCollection, IAddRemoveCollection
{
    int Used { get; }
}

