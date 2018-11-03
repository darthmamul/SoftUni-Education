using System;
using System.Collections.Generic;
using System.Text;


abstract class Feline : Mammal
{
    public Feline(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion)
    {
        this.Breed = breed;
    }

    protected string Breed { get; set; }

    public override string ToString()
    {
        string fromBase = base.ToString();
        string result = string.Format(fromBase, $"{this.Breed}, ");
        return result;
    }
}

