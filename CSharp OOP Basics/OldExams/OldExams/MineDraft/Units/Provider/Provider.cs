using System;
using System.Collections.Generic;
using System.Text;


public abstract class Provider : Unit
{
    const double MaxEnergyOutput = 10_000;
    private double energyOutput;

    public double EnergyOutput
    {
        get => this.energyOutput; 
        private set
        {
            if (value < 0 || value >= MaxEnergyOutput)
            {
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
            }
            this.energyOutput = value;
        }
    }

    protected Provider(string id, double energyOutput) 
        : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public override string ToString()
    {
        return $"{Type} Provider - {Id}" + Environment.NewLine +
               $"Energy Output: {EnergyOutput}";
    }
}

