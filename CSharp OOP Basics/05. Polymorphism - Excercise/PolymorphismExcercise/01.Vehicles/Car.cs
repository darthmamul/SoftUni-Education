using System;
using System.Collections.Generic;
using System.Text;


public class Car : Vehicle
{
    private const double ACFuelIncrease = 0.9;

    public Car(double fuelQuantity, double fuelConsumptptioNPerKm) : base(fuelQuantity, fuelConsumptptioNPerKm)
    {
        this.FuelConsumptionPerKm += ACFuelIncrease;
    }
}

