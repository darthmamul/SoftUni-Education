using System;
using System.Collections.Generic;
using System.Text;


public abstract class Harvester : Unit
{
    //Класа е abstract, защото сам по себе си не го използваме;
    //използваме функцията му, защото ни трябват SonicHarvester и HammerHarvester,
    //които ще го наследят!!!!
    const int MaxEnergyRequirement = 20_000;
    private double oreOutput;

    public double OreOutput
    {
        get => this.oreOutput; 
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Harvester is not registered, because of it's OreOutput");
            }
            this.oreOutput = value;
        }
    }

    private double energyRequirement;

    public double EnergeyRequirement
    {
        get => this.energyRequirement; 
        private set
        {
            if (value < 0 || value >= MaxEnergyRequirement)
            {
                throw new ArgumentException("Harvester is not registered, because of it's EnergeyRequirement");
            }
            energyRequirement = value;
        }
    }

    protected Harvester(string id, double oreOutput, double energyRequirement)
        :base(id)
    {
        //при this.oreOutput = oreOutput, няма да минем през валидацията по-горе на private set-ъра 
        this.OreOutput = oreOutput;
        this.EnergeyRequirement = energyRequirement;
    }

    public override string ToString()
    {
        return $"“{Type} Harvester - {Id}" + Environment.NewLine +
               $"Ore Output: {OreOutput}" + Environment.NewLine +
               $"Energy Requirement: {EnergeyRequirement}";
    }
}

