using System;

public class Scale<T> where T : IComparable<T>
{
    private T first;
    private T second;
    
    public Scale(T first, T second)
    {
        this.first = first;
        this.second = second;
    }



    public T GetHeavier()
    {
        if (first.CompareTo(second) > 0)
        {
            return first;
        }
        else if(first.CompareTo(second) < 0)
        {
            return second;
        }
            return default(T);

    }
}

