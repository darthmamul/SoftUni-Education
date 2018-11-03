namespace Forum.App.Commands
{
    using Contracts;

    public class LoginMenuCommand : NavigationCommand
    {
        public LoginMenuCommand(IMenuFactory menuFactory)
            : base(menuFactory)
        {
        }
    }
}
