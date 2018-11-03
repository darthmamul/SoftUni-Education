﻿namespace P03.DependencyInversion
{
    using Contracts;

    public class PrimitiveCalculator
    {
        private ICalculationStrategy calculationStrategy;

        public PrimitiveCalculator(ICalculationStrategy calculationStrategy)
        {
            this.ChangeStrategy(calculationStrategy);
        }

        public void ChangeStrategy(ICalculationStrategy calculationStrategy)
        {
            this.calculationStrategy = calculationStrategy;
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.calculationStrategy.Calculate(firstOperand, secondOperand);
        }
    }
}
