public abstract class Employee
{
    public Employee(string name, int hoursPerWeek)
    {
        this.Name = name;
        this.HoursPerWeek = hoursPerWeek;
    }

    public int HoursPerWeek { get; private set; }

    public string Name { get; private set; }

}

