using System;
using System.Collections.Generic;
using System.Text;


class Hen : Bird
{
    public Hen(string name, double weight, double wingSize)
        : base(name, weight, wingSize)
    {
    }

    protected override Type[] PreferredFoods => new Type[] { typeof(Vegetable), typeof(Meat), typeof(Fruit), typeof(Seeds) };

    protected override double WeightIncreaseMultiplier => 0.35;

    public override string MakeSound()
    {
        return "Cluck";
    }
}

