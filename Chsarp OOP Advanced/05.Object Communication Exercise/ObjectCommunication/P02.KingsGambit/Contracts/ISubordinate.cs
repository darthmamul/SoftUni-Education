namespace P02.KingsGambit.Contracts
{
    public interface ISubordinate : INameable, IMortal
    {
        string Action { get; }

        void ReactToAttack();
    }
}