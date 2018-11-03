namespace _02.Graphic_Editor
{
    public class Program
    {
        public static void Main()
        {
            IShape circle = new Circle();
            GraphicEditor graph = new GraphicEditor();
            graph.DrawShape(circle);
        }
    }
}
