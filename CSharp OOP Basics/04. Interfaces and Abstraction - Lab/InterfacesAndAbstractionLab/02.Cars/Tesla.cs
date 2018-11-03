﻿using System;
using System.Collections.Generic;
using System.Text;


public class Tesla : ICar, IElectricCar
{
    public Tesla(string model, string color, int battery)
    {
        this.Model = model;
        this.Color = color;
        this.Battery = battery;
    }

    public string Model { get; }

    public string Color { get; }

    public int Battery { get; }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        var sb = new StringBuilder()
            .Append(this.Color + " ")
            .Append("Tesla ")
            .Append(this.Model)
            .AppendLine(" with " + this.Battery + " Batteries")
            .AppendLine(Start())
            .Append(Stop());

        return sb.ToString();
    }
}

