using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    private const string offset = "  ";

    public string model;
    public Engine engine;
    public string weight;
    public string color;

    public Car(string model, Engine engine)
    {
        this.model = model;
        this.engine = engine;
        this.weight = "n/a";
        this.color = "n/a";
    }

    public string Model => model;

    public Engine Engine => engine;

    public string Weight
    {
        get => this.weight;
        set => this.weight = value;
    }

    public string Color
    {
        get => this.color;
        set => this.color = value;
    }

    public override string ToString()
    {
        var builder = new StringBuilder()
            .AppendLine($"{this.model}:")
            .AppendLine($"  {this.Engine.Model}:")
            .AppendLine($"    Power: {this.Engine.Power}")
            .AppendLine($"    Displacement: {this.engine.Displacement}")
            .AppendLine($"    Efficiency: {this.Engine.Efficiency}")
            .AppendLine($"  Weight: {this.weight}")
            .AppendLine($"  Color: {this.color}");

        return builder.ToString();
    }
}

