﻿namespace P01EventImplementation
{
    using Contracts;


    public class Dispatcher : INameChangeable, INameable
    {
        public event NameChangeEventHandler NameChange;

        private string name;

        public Dispatcher(string name)
        {

        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.OnNameChange(new NameChangeEventArgs(value));
                this.name = value;
            }
        }

        public void OnNameChange(NameChangeEventArgs args)
        {
            if (this.NameChange != null)
            {
                this.NameChange.Invoke(this, args);
            }
        }
    }
}
