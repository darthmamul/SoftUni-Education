using System;
using System.Collections.Generic;
using System.Text;


public class Person : IPerson
{
    protected Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
        this.Food = 0;
    }

    public string Name { get; }

    public int Age  { get; }

    public int Food { get; protected set; }

    public void BuyFood()
    {
        throw new NotImplementedException();
    }
}

