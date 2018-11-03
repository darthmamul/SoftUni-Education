using System;

public abstract class Car
{
    protected Car(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.HorsePower = horsePower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }

    public string Brand { get; }
    public string Model { get; }
    public int YearOfProduction { get; }
    public int HorsePower { get; protected set; }
    public int Acceleration { get; }
    public int Suspension { get; protected set; }
    public int Durability { get; set; }

    public virtual void Tune(int tuneIndex, string addOn)
    {
        this.HorsePower += tuneIndex;
        this.Suspension += tuneIndex / 2;
    }

    public override string ToString()
    {
        return $"{this.Brand} {this.Model} {this.YearOfProduction}" + Environment.NewLine +
            $"{this.HorsePower} HP, 100 m/h in {this.Acceleration} s" + Environment.NewLine +
            $"{this.Suspension} Suspension force, {this.Durability} Durability";
    }
}

