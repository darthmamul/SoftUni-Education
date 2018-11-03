using System;
using System.Collections.Generic;
using System.Text;


public class Citizen : SocietyMember, IBirthdate, IBuyer
{
    private const int citizenFoodPurchase = 10;

    private string name;
    private int age;
    private string birthdate;
    private int food;

    public Citizen(string id, string name, int age, string birthdate)
       : base(id)
    {
        this.Name = name;
        this.Age = age;
        this.BirthDate = birthdate;
    }

    public string BirthDate
    {
        get => this.birthdate;
        private set { this.birthdate = value; }
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

    public int Food => this.food;

    public void BuyFood()
    {
        this.food += citizenFoodPurchase;
    }

}

