﻿namespace P03.DependencyInversion.Strategies
{
    using Contracts;

    public class MultiplicationStrategy : ICalculationStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }
}