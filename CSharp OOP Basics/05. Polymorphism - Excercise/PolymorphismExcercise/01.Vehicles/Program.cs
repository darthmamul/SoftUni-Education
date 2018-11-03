using System;

namespace _01.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] truckInfo = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int commandsCount = int.Parse(Console.ReadLine());

            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            for (int i = 0; i < commandsCount; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens[1].Equals("Car"))
                {
                    DriveOrRefuel(car, tokens[0], double.Parse(tokens[2]));
                }
                else if (tokens[1].Equals("Truck"))
                {
                    DriveOrRefuel(truck, tokens[0], double.Parse(tokens[2]));
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void DriveOrRefuel(Vehicle vehicle, string command, double parameter)
        {
            if (command.Equals("Drive"))
            {
                string result = vehicle.TryTravel(parameter);
                Console.WriteLine(result);
            }
            else
            {
                vehicle.Refuel(parameter);
            }
        }
    }
}
