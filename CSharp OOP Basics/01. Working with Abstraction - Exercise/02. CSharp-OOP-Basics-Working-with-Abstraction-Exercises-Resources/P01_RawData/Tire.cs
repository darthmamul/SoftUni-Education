using System;
using System.Collections.Generic;
using System.Text;


public class Tire
{
    private int tireAge;
    private double tirePressure;

    public Tire(double pressure, int age)
    {
        this.tireAge = age;
        this.tirePressure = pressure;
    }

    public double Pressure => tirePressure;
}

