using System;
using System.Collections.Generic;
using System.Text;


public class Vehicle
{
    private double fuelQuantity;
    private double fuelConsumptionPerKm;

    protected Vehicle(double fuelQuantity, double fuelConsumptptioNPerKm)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionPerKm = fuelConsumptptioNPerKm;
    }

    protected virtual double FuelQuantity
    {
        get => this.fuelQuantity; 
        set { this.fuelQuantity = value; }
    }

    protected double FuelConsumptionPerKm
    {
        get => this.fuelConsumptionPerKm;
        set { this.fuelConsumptionPerKm = value; }
    }

    public virtual void Refuel(double fuel)
    {
        this.FuelQuantity += fuel;
    }

    public string TryTravel(double distance)
    {
        if (this.FuelConsumptionPerKm * distance <= this.FuelQuantity)
        {
            this.FuelQuantity -= this.FuelConsumptionPerKm * distance;
            return $"{GetType().Name} travelled {distance} km";
        }

        return $"{GetType().Name} needs refueling";
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}

