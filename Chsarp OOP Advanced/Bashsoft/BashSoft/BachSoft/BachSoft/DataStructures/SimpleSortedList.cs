﻿using BachSoft.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BachSoft.DataStructures
{
    public class SimpleSortedList<T> : ISimpleOrderedBag<T> where T : IComparable<T>
    {
        private const int DefaultSize = 16;

        private IComparer<T> comparison;
        private T[] innerCollection;
        private int size;

        public SimpleSortedList(IComparer<T> comparer, int capacity)
        {
            this.InitializeInnerCollection(capacity);
            this.comparison = comparer;
            this.size = 0;
        }

        public SimpleSortedList(int capacity) : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), capacity)
        {
        }

        public SimpleSortedList(IComparer<T> comparer) : this(comparer, DefaultSize)
        {
        }

        public SimpleSortedList() : this(DefaultSize)
        {
        }

        public int Capacity
        {
            get { return this.innerCollection.Length; }
        }

        public int Size
        {
            get { return this.size; }
        }

        public void Add(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Element to add cannot be null!");
            }

            if (this.innerCollection.Length == this.size)
            {

                this.Resize();
            }

            this.innerCollection[this.size] = element;
            this.size++;
            Array.Sort(this.innerCollection, 0, this.size, this.comparison);
        }

        public void AddAll(ICollection<T> collection)
        {
            if (this.size + collection.Count >= this.innerCollection.Length)
            {
                this.MultiResize(collection);
            }

            foreach (var element in collection)
            {
                if (element == null)
                {
                    throw new ArgumentNullException("Collection to add cannot be null!");
                }

                this.innerCollection[this.size] = element;
                this.size++;
            }

            Array.Sort(this.innerCollection, 0, this.size, this.comparison);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.size; i++)
            {
                yield return this.innerCollection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public string JoinWith(string joiner)
        {
            if (joiner == null)
            {
                throw new ArgumentNullException("string to join cannot be null!");
            }

            StringBuilder builder = new StringBuilder();
            foreach (var element in this)
            {
                builder.Append(element);
                builder.Append(joiner);
            }

            builder.Remove(builder.Length - joiner.Length, joiner.Length);

            return builder.ToString();
        }

        public bool Remove(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Element to be removed cannot be null!");
            }

            bool hasBeenRemoved = false;
            int indexOfRemovedElement = 0;
            for (int i = 0; i < this.size; i++)
            {
                if (this.innerCollection[i].Equals(element))
                {
                    indexOfRemovedElement = i;
                    this.innerCollection[i] = default(T);
                    hasBeenRemoved = true;
                    break;
                }
            }

            if (hasBeenRemoved)
            {
                for (int i = indexOfRemovedElement; i < this.size - 1; i++)
                {
                    this.innerCollection[i] = this.innerCollection[i + 1];
                }

                this.innerCollection[this.size - 1] = default(T);
                this.size--;
            }

            return hasBeenRemoved;
        }

        private void InitializeInnerCollection(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacity cannot be negative");
            }

            this.innerCollection = new T[capacity];
        }

        private void MultiResize(ICollection<T> collection)
        {
            int newSize = this.innerCollection.Length * 2;
            while (this.size + collection.Count >= newSize)
            {
                newSize *= 2;
            }

            T[] newCollection = new T[size];
            Array.Copy(this.innerCollection, newCollection, this.size);
            this.innerCollection = newCollection;
        }

        private void Resize()
        {
            T[] newCollection = new T[this.size * 2];
            Array.Copy(this.innerCollection, newCollection, this.size);
            this.innerCollection = newCollection;
        }
    }
}