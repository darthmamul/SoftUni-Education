using System;
using System.Collections.Generic;
using System.Text;


public abstract class Command
{
    private string input;
    private string[] data;
    private Tester judge;
    private StudentRepository repository;
    private IOManager inputOutputManager;

    public Command(string input, string[] data, Tester judge, StudentRepository repository, IOManager inputOutputManager)
    {
        this.Input = input;
        this.Data = data;
        this.judge = judge;
        this.repository = repository;
        this.inputOutputManager = inputOutputManager;
    }

    protected string Input
    {
        get => this.input;
        private set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new InvalidStringException();
            }

            this.input = value;
        }
    }

    protected string[] Data
    {
        get => this.data;
        private set
        {
            if (value == null || value.Length == 0)
            {
                throw new NullReferenceException();
            }

            this.data = value;
        }
    }

    protected Tester Judge
    {
        get => this.judge;
    }

    protected StudentRepository Repository
    {
        get => this.repository;
    }

    protected IOManager InputOutputManager
    {
        get => this.inputOutputManager;
    }

    public abstract void Execute();
}

