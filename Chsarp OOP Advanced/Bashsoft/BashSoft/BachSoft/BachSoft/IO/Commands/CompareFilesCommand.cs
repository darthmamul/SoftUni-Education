using BachSoft.Attributes;
using BachSoft.Contracts;
using BachSoft.IO.Commands;

namespace BachSoft.IO
{
    [Alias("cmp")]
    public class CompareFilesCommand : Command
    {
        [Inject]
        private IContentComparer judge;

        public CompareFilesCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public IContentComparer Judge
        {
            get => this.judge;
            private set => this.judge = value;
        }

        public override void Execute()
        {
            if (this.Data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }
            string firstPath = this.Data[1];
            string secondPath = this.Data[2];
            this.judge.CompareContent(firstPath, secondPath);
        }
    }
}

