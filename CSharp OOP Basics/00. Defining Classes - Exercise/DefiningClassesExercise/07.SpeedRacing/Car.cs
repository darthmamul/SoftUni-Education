using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelConsumption;
    private double distance;

    public double Distance
    {
        get { return distance; }
        set { distance = value; }
    }

    public double FuelConsumption
    {
        get { return fuelConsumption; }
        set { fuelConsumption = value; }
    }

    public double FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public Car(string model, double fuelAmount, double fuelConsumption)
    {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelConsumption = fuelConsumption;
        this.distance = 0;
    }

    public void Drive(int amountOfKm)
    {
        if (amountOfKm <= this.fuelAmount / this.fuelConsumption)
        {
            this.distance += amountOfKm;
            this.fuelAmount -= this.fuelConsumption * amountOfKm;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }


}

