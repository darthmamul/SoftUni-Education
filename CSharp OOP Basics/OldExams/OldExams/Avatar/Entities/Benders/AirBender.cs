public class AirBender : Bender
{
    private double aerialIntegrity;

    public AirBender(string name, int power, double aerialIntegrity)
        : base(name, power)
    {
        this.aerialIntegrity = aerialIntegrity;
    }

    public override double GetPower() => this.Power * this.aerialIntegrity;

    public override string ToString() => $"{base.ToString()}, Aerial Integrity: {this.aerialIntegrity:f2}";
}

