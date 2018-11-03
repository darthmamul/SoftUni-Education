using System;
using System.Collections.Generic;
using System.Text;


public class Pet : IBirthday
{
    private string name;
    private string birthdate;

    public Pet(string name, string birthdate)
    {
        this.Name = name;
        this.BirthDate = birthdate;
    }

    public string BirthDate
    {
        get => this.birthdate; 
        private set { this.birthdate = value; }
    }

    public string Name
    {
        get => this.name; 
        private set { this.name = value; }
    }

}

