using System;
using System.Collections.Generic;
using System.Text;


public class Gandalf
{
    private int happinessPoints;

    public Gandalf()
    {
        this.happinessPoints = 0;
    }

    public int HappinessPoints => happinessPoints;

    public void EatFood(string food)
    {
        var foodHappinessPoints = new Dictionary<string, int>();
        foodHappinessPoints["cram"] = 2;
        foodHappinessPoints["lembas"] = 3;
        foodHappinessPoints["apple"] = 1;
        foodHappinessPoints["lemon"] = 1;
        foodHappinessPoints["honeycake"] = 5;
        foodHappinessPoints["mushrooms"] = -10;

        if (foodHappinessPoints.ContainsKey(food))
        {
            this.happinessPoints += foodHappinessPoints[food];
        }
        else
        {
            this.happinessPoints--;
        }
    }

    public string CalculateMood()
    {
        if (this.happinessPoints > 15)
        {
            return "JavaScrip";
        }

        if (this.happinessPoints >= 1)
        {
            return "Happy";
        }

        if (this.happinessPoints >= -5)
        {
            return "Sad";
        }

        return "Angry";
    }
}

