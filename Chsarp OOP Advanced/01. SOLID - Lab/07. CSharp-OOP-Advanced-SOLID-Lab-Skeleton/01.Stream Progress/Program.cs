namespace _01.Stream_Progress
{
    public class Program
    {
        public static void Main()
        {
            var progressInfo = new StreamProgressInfo(new File("my file", 100, 1000));
            var progressInfo2 = new StreamProgressInfo(new Music("lili", "album", 5, 13));
        }
    }
}
