namespace Forum.App.ViewModels
{
    using Contracts;

    public class ReplyViewModel : ContentViewModel, IReplyViewModel
    {
        ReplyViewModel(string author, string text)
            : base(text)
        {
            this.Author = author;
        }

        public string Author { get; }
        
    }
}
