using System;

public class ConsoleAppender : IAppender
{
    public ConsoleAppender(ILayout layout)
    {
        this.Layout = layout;
    }

    public ILayout Layout { get; }

    public ReportLevel ReportLevel { get; set; }

    public void Append(string timeStamp, string reportLevel, string message)
    {
        string formattedMsg = this.Layout.FormatMessage(timeStamp, reportLevel, message);
        Console.WriteLine(formattedMsg);
    }
}

