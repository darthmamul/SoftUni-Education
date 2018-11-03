﻿namespace P03.DependencyInversion.Contracts
{
    public interface ICalculationStrategy
    {
        int Calculate(int firstOperand, int secondOperand);
    }
}
