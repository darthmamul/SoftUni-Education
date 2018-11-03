using System;
using System.Collections.Generic;
using System.Text;


public class Citizen : SocietyMember
{
    private string name;
    private int age;

    public Citizen(string id, string name, int age)
        : base(id)
    {
        this.Name = name;
        this.Age = age;
    }

    public int Age
    {
        get => this.age;
        private set { this.age = value; }
    }

    public string Name
    {
        get => this.name;
        private set { this.name = value; }
    }

}

