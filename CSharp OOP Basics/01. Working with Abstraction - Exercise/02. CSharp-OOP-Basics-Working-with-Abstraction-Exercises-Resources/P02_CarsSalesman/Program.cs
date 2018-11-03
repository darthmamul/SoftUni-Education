using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{
    class CarSalesman
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();
            int engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = parameters[0];
                double power = double.Parse(parameters[1]);

                var engine = new Engine(model, power);

                if (parameters.Length > 2)
                {
                    string displacementOrEfficiency = parameters[2];
                    double result;
                    bool isNumber = double.TryParse(displacementOrEfficiency, out result);

                    if (isNumber)
                    {
                        engine.Displacement = parameters[2];
                    }
                    else
                    {
                        engine.Efficiency = parameters[2];
                    }
                }

                if (parameters.Length > 3)
                {
                    engine.Efficiency = parameters[3];
                }
                engines.Add(engine);
            }

            int carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = parameters[0];
                string engineModel = parameters[1];
                Car car = new Car(model, engines.FirstOrDefault(x => x.model == engineModel));


                if (parameters.Length > 2)
                {
                    var colorOrWeight = parameters[2];
                    double result;
                    var isNumber = double.TryParse(colorOrWeight, out result);

                    if (isNumber)
                    {
                        car.Weight = colorOrWeight;
                    }
                    else
                    {
                        car.Color = colorOrWeight;
                    }
                }

                if (parameters.Length > 3)
                {
                    car.Color = parameters[3];
                }

                cars.Add(car);
            }

            cars.ForEach(c => Console.Write(c.ToString()));
        }
    }
}
