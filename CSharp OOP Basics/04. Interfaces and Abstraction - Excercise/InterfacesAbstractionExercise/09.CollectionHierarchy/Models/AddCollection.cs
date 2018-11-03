using System;
using System.Collections.Generic;
using System.Text;


public class AddCollection : IAddCollection
{
    public AddCollection()
    {
        this.Items = new List<string>();
    }

    private List<string> Items { get; }

    public int Add(string item)
    {
        this.Items.Add(item);
        return this.Items.Count - 1;
    }
}

