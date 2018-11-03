using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    
    class RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];

                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);

                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];

                double tire1Pressure = double.Parse(carInfo[5]);
                int tire1age = int.Parse(carInfo[6]);

                double tire2Pressure = double.Parse(carInfo[7]);
                int tire2age = int.Parse(carInfo[8]);

                double tire3Pressure = double.Parse(carInfo[9]);
                int tire3age = int.Parse(carInfo[10]);

                double tire4Pressure = double.Parse(carInfo[11]);
                int tire4age = int.Parse(carInfo[12]);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Tire[] tires = new Tire[4];
                tires[0] = new Tire(tire1Pressure, tire1age);
                tires[1] = new Tire(tire2Pressure, tire2age);
                tires[2] = new Tire(tire3Pressure, tire3age);
                tires[3] = new Tire(tire4Pressure, tire4age);

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .ToList()
                    .ForEach(c => Console.WriteLine($"{c.Model}"));
                
            }
            else
            {
                cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .ToList()
                    .ForEach(c => Console.WriteLine($"{c.Model}"));
            }
        }
    }
}
