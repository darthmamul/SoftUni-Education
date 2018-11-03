using System;
using System.Collections;
using System.Collections.Generic;

public class RandomList : List<string>
{
    private Random random;

    public RandomList()
    {
        this.random = new Random();
    }

    public object RemoveRandomElement()
    {
        int index = random.Next(0, this.Count - 1);
        string str = this[index];
        this.RemoveAt(index);
        return str;

    }
}

