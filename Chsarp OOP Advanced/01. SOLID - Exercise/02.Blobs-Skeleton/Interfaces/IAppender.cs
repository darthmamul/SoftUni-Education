public interface IAppender
{
    ILayout Layout { get; }

    ReportLevel ReportLevel { get; }

    void Append(string timeStamp, string reportLevel, string message);
}

