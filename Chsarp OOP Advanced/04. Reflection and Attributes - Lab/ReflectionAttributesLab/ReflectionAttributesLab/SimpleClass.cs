using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionAttributesLab
{
    class SimpleClass : IComparable<int>
    {
        protected static int simpleInt;
        private string publicStr;
        private string simpleStr;

        public SimpleClass()
            :this("SomeText")
        {
        }

        public SimpleClass(string someProp)
        {
            this.SomeProp = someProp;
        }

        public string SomeProp
        {
            get;
            private set;
            //get => this.simpleStr;
            //set => this.simpleStr = value;
        }

        public int CompareTo(int other)
        {
            throw new NotImplementedException();
        }
    }
}
