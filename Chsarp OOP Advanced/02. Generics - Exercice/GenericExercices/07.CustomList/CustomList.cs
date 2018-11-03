﻿using System;

public class CustomList<T> where T : IComparable<T>
{
    private T[] data;

    public CustomList()
    {
        this.data = new T[4];
    }

    public int InnerArraySize => this.data.Length;

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            return this.data[index];
        }
        set
        {
            this.data[index] = value;
        }
    }

    public void Add(T element)
    {
        this.Count++;
        if (this.Count > this.InnerArraySize)
        {
            T[] newData = new T[this.InnerArraySize * 2];
            Array.Copy(this.data, newData, this.InnerArraySize);
            this.data = newData;
        }

        this.data[Count - 1] = element;
    }

    public T Remove(int index)
    {
        T element = this.data[index];

        this.Count--;

        for (int i = index; i < this.Count; i++)
        {
            this.data[i] = this.data[i + 1];
        }

        //defalt - за да не изгърми, ако е string ще вземе null, ако е int ще вземе 0 и т.н.
        this.data[this.Count] = default(T);

        if (this.Count < this.InnerArraySize / 3)
        {
            T[] newData = new T[this.InnerArraySize / 2];
            Array.Copy(this.data, newData, this.Count);
            this.data = newData;
        }

        return element;
    }

    public bool Contains(T element)
    {
        for (int i = 0; i < this.Count; i++)
        {
            //проверяваме с Equals, т.к. за обектите не става с ==, работим с T
            if (this.data[i].Equals(element))
            {
                return true;
            }
        }

        return false;
    }

    public void Swap(int firstIndex, int secondIndex)
    {
        T temp = this.data[firstIndex];
        this.data[firstIndex] = this.data[secondIndex];
        this.data[secondIndex] = temp;
    }

    public int CountGreaterThan(T element)
    {
        int counter = 0;

        for (int i = 0; i < this.Count; i++)
        {
            T currentElement = this.data[i];

            if (currentElement.CompareTo(element) > 0)
            {
                counter++;
            }
        }

        return counter; 
    }

    public T Min()
    {
        T minElement = this.data[0];

        for (int i = 1; i < this.Count; i++)
        {
            T currentElement = this.data[i];

            if (currentElement.CompareTo(minElement) < 0)
            {
                minElement = currentElement;
            }
        }

        return minElement;
    }

    public T Max()
    {
        T maxElement = this.data[0];

        for (int i = 1; i < this.Count; i++)
        {
            T currentElement = this.data[i];

            if (currentElement.CompareTo(maxElement) > 0)
            {
                maxElement = currentElement;
            }
        }

        return maxElement;
    }
}
