using System;
using System.Collections.Generic;

namespace _08.TrafficLightsProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] startTrafficColors = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int numberOfChanges = int.Parse(Console.ReadLine());

            List<TrafficLight> trafficLights = new List<TrafficLight>();
            foreach (string color in startTrafficColors)
            {
                TrafficLight trafficLight = new TrafficLight(color);
                trafficLights.Add(trafficLight);
            }

            for (int i = 0; i < numberOfChanges; i++)
            {
                foreach (TrafficLight trafficLight in trafficLights)
                {
                    trafficLight.ChangeColor();
                }

                Console.WriteLine(string.Join(" ", trafficLights));
            }
        }
    }
}
