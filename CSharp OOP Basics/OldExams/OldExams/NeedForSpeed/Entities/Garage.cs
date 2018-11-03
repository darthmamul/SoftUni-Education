using System;
using System.Collections.Generic;
using System.Text;


public class Garage
{
    public List<int> ParkedCars { get; }

    public Garage()
    {
        this.ParkedCars = new List<int>();
    }

    public void AddCar(int carId)
    {
        this.ParkedCars.Add(carId);
    }

    public void RemoveCar(int carId)
    {
        this.ParkedCars.Remove(carId);
    }
}

