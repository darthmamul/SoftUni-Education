using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


abstract class Animal
{
    public Animal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = 0;
    }

    public string Name { get; set; }
    public double Weight { get; set; }
    public int FoodEaten { get; set; }

    protected abstract Type[] PreferredFoods { get; }

    protected virtual double WeightIncreaseMultiplier => 1;

    public void TryEatFood(Food food)
    {
        Type typeOfFood = food.GetType();

        if (!this.PreferredFoods.Contains(typeOfFood))
        {
            throw new InvalidOperationException($"{this.GetType().Name} does not eat {typeOfFood.Name}!");
        }

        this.FoodEaten += food.Quantity;
        this.Weight += food.Quantity * this.WeightIncreaseMultiplier;
    }

    public abstract string MakeSound();

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, " + "{0}" + $"{this.Weight}, " + "{1}" + $"{this.FoodEaten}]";
    }
}

