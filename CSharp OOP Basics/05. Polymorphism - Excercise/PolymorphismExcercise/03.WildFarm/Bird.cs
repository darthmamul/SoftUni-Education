using System;
using System.Collections.Generic;
using System.Text;


abstract class Bird : Animal
{
    public Bird(string name, double weight, double wingSize)
        : base(name, weight)
    {
        this.WingSize = wingSize;
    }

    protected double WingSize { get; set; }
    
    public override string ToString()
    {
        string fromBase = base.ToString();
        string result = string.Format(fromBase, $"{this.WingSize}, ", string.Empty);
        return result;
    }
}

