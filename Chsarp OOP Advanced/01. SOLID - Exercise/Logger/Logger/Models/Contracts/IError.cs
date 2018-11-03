using System;

namespace LoggerProblem.Models.Contracts
{
    public interface IError : ILevelable
    {
        DateTime DateTime { get; }

        string Message { get; }
    }
}