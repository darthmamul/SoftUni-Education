using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SpeedRacing
{
    class SpeedRacing
    {
        static void Main(string[] args)
        {
            int carsCount = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            for (int i = 0; i < carsCount; i++)
            {
                var carInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string carModel = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumption = double.Parse(carInfo[2]);

                Car car = new Car(carModel, fuelAmount, fuelConsumption);
                cars.Add(car);
            }
            string driveCommand = Console.ReadLine();
            while (driveCommand != "End")
            {
                string[] driveCommandsArgs = driveCommand.Split();
                string carModel = driveCommandsArgs[1];
                int amountOfKm = int.Parse(driveCommandsArgs[2]);
                Car carToDrive = cars.First(c => c.Model == carModel);
                carToDrive.Drive(amountOfKm);

                driveCommand = Console.ReadLine();
            }

            cars.ForEach(c => Console.WriteLine($"{c.Model} {c.FuelAmount:f2} {c.Distance}"));
        }
    }
}
