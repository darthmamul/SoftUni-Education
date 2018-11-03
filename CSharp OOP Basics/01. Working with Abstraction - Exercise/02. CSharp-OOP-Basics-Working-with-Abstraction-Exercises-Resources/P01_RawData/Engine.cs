using System;
using System.Collections.Generic;
using System.Text;


public class Engine
{
    private int engineSpeed;
    private int enginePower;

    public Engine(int speed, int power)
    {
        this.engineSpeed = speed;
        this.enginePower = power;
    }

    public int Power => this.enginePower;
}

