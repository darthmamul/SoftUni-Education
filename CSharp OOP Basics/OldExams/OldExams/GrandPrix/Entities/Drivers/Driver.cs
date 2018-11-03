public abstract class Driver
{
    private string name;
    private double totalTime;
    private Car car;
    private double fuelConsumptionPerKm;
    
    protected Driver(string name, Car car, double fuelConsumptioPerKm)
    {
        this.Name = name;
        this.TotalTime = 0;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptioPerKm;
    }

    public double FuelConsumptionPerKm
    {
        get => this.fuelConsumptionPerKm; 
        protected set => this.fuelConsumptionPerKm = value;
    }

    public Car Car
    {
        get => this.car;
        private set => this.car = value; 
    }

    public double TotalTime
    {
        get => this.totalTime; 
        set => this.totalTime = value; 
    }
    
    public string Name
    {
        get => this.name; 
        private set => this.name = value; 
    }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public virtual void ReduceFuelAmount(int length)
    {
        this.Car.ReduceFuel(length, this.FuelConsumptionPerKm);
    }
}

