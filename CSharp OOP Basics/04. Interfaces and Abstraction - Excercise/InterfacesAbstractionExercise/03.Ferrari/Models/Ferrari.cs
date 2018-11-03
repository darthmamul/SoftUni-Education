using System;
using System.Collections.Generic;
using System.Text;


public class Ferrari : ICar
{
    private string model;
    private string driver;

    public Ferrari(string model, string driver)
    {
        this.Model = model;
        this.Driver = driver;
    }

    public string Model
    {
        get => this.model;
        private set { this.model = value; }
    }
    
    public string Driver
    {
        get => this.driver;
        private set { this.driver = value; }
    }

    public string UseBrakes()
    {
        return "Brakes!";
    }

    public string UseGasPedal()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        var sb = new StringBuilder()
            .Append($"{this.model}/{this.UseBrakes()}/{this.UseGasPedal()}/{this.driver}");

        return sb.ToString().Trim();
    }
}

