namespace GrandPrix
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var raceTower = new RaceTower();
            var engine = new Engine(raceTower);
            engine.Start();
        }
    }
}
