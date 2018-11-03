using System;
using System.Collections.Generic;
using System.Text;


public class SonicHarvester : Harvester
{
    public override string Type => "Sonic";

    public SonicHarvester(string id, double oreOutput, double energyRequriement, int sonicFactor)
        : base(id, oreOutput, energyRequriement / sonicFactor)
    {

    }
}

