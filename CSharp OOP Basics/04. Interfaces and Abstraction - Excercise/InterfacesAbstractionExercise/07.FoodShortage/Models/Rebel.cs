using System;
using System.Collections.Generic;
using System.Text;


public class Rebel : IBuyer
{
    private const int rebelFoodPurchase = 5;

    private string name;
    private int age;
    private string group;
    private int food;

    public Rebel(string name, int age, string group)
    {
        this.Name = name;
        this.Age = age;
        this.Group = group;
    }

    public string Group
    {
        get => this.group; 
        private set { this.group = value; }
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
        this.food += rebelFoodPurchase;
    }
}

