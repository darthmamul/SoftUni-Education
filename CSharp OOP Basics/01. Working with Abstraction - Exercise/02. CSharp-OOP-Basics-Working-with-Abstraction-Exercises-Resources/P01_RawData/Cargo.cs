using System;
using System.Collections.Generic;
using System.Text;


public class Cargo
{
    private int cargoWeight;
    private string cargoType;

    public Cargo(int weigth, string type)
    {
        this.cargoWeight = weigth;
        this.cargoType = type;
    }

    public string Type => this.cargoType;
}

