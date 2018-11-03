using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
{
    private T boxValue;
    public T Value { get; private set; }

    public Box(T value)
    {
        this.Value = value;
    }

    public override string ToString()
    {
        return $"{this.boxValue.GetType().FullName}: {this.boxValue}";
    }
}

