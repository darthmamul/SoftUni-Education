namespace P03.DependencyInversion
{
    using System;
    using Contracts;
    using Strategies;

    class Program
    {
        static void Main(string[] args)
        {
            PrimitiveCalculator calculator = new PrimitiveCalculator(new AdditionStrategy());

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();
                string command = tokens[0];

                if (command == "mode")
                {
                    string @operator = tokens[1];

                    ICalculationStrategy strategy = null;

                    switch (@operator)
                    {
                        case "+":
                            strategy = new AdditionStrategy();
                            break;
                        case "-":
                            strategy = new SubtractionStrategy();
                            break;
                        case "*":
                            strategy = new MultiplicationStrategy();
                            break;
                        case "/":
                            strategy = new DivisionStrategy();
                            break;
                    }

                    if (strategy == null)
                    {
                        throw new ArgumentException("Invalid mode!");
                    }
                    
                    calculator.ChangeStrategy(strategy);
                }
                else
                {
                    int firstOperand = int.Parse(tokens[0]);
                    int seconOperand = int.Parse(tokens[1]);

                    int result = calculator.PerformCalculation(firstOperand, seconOperand);

                    Console.WriteLine(result);
                }
            }
        }
    }
}
