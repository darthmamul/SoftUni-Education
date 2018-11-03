using System;
using System.Collections.Generic;
using System.Text;


public class PrintOrderedStudentsCommand : Command
{
    public PrintOrderedStudentsCommand(string input, string[] data, Tester judge, StudentRepository repository, IOManager inputOutputManager)
        : base(input, data, judge, repository, inputOutputManager)
    {
    }

    private void TryParseParameterForOrderAndTake(string takeCommand, string takeQuantity, string courseName, string comparison)
    {
        if (takeCommand.Equals("take"))
        {
            if (takeQuantity.Equals("all"))
            {
                this.Repository.OrderAndTake(courseName, comparison);
            }
            else
            {
                int studentsToTake;
                bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                if (hasParsed)
                {
                    this.Repository.OrderAndTake(courseName, comparison, studentsToTake);
                }
                else
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTakeQuantityParameter);
                }
            }
        }
        else
        {
            throw new ArgumentException(ExceptionMessages.InvalidTakeCommand);
        }
    }

    public override void Execute()
    {
        if (this.Data.Length != 5)
        {
            string courseName = Data[1];
            string orderType = Data[2].ToLower();
            string orderCommand = Data[3].ToLower();
            string orderQuantity = Data[4].ToLower();

            this.TryParseParameterForOrderAndTake(orderCommand, orderQuantity, courseName, orderType);
        }
    }
}

