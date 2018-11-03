namespace BachSoft.IO
{
    using BachSoft.Attributes;
    using BachSoft.IO.Commands;
    using System.Diagnostics;

    [Alias("open")]
    public class OpenFileCommand : Command
    {
        public OpenFileCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string fileName = Data[1];
            Process.Start(SessionData.currentPath + "\\" + fileName);
        }
    }
}

