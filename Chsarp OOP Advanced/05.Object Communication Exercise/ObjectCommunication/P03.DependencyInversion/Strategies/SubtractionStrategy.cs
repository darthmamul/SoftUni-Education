﻿namespace P03.DependencyInversion.Strategies
{
    using Contracts;

    public class SubtractionStrategy : ICalculationStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}
