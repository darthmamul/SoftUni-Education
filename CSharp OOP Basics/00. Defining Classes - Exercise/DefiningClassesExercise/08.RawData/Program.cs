using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                var carInfo = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];

                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);

                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];

                double tireOnePressure = double.Parse(carInfo[5]);
                int tireOneAge = int.Parse(carInfo[6]);
                double tireTwoPressure = double.Parse(carInfo[7]);
                int tireTwoAge = int.Parse(carInfo[8]);
                double tireThreePressure = double.Parse(carInfo[9]);
                int tireThreeAge = int.Parse(carInfo[10]);
                double tireFourPressure = double.Parse(carInfo[11]);
                int tireFourAge = int.Parse(carInfo[12]);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Tire[] tires = new Tire[4];
                tires[0] = new Tire(tireOnePressure, tireOneAge);
                tires[1] = new Tire(tireTwoPressure, tireTwoAge);
                tires[2] = new Tire(tireThreePressure, tireThreeAge);
                tires[3] = new Tire(tireFourPressure, tireFourAge);

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                cars
                    .Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1))
                    .ToList()
                    .ForEach(c => Console.WriteLine($"{c.Model}"));
            }
            else
            {
                cars
                    .Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250)
                    .ToList()
                    .ForEach(c => Console.WriteLine($"{c.Model}"));
            }
        }
    }
}
