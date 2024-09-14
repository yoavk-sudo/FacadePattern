namespace FacadePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShapeDrawer.DrawRect(30, 0, 20, 10, ConsoleColor.Cyan, true);
            ShapeDrawer.DrawRect(10, 0, 8, 13, ConsoleColor.Green, true);
            ShapeDrawer.DrawCircle(0, 10, 4, ConsoleColor.Yellow, true);
            ShapeDrawer.DrawCircle(30, 12, 3);
        }
    }
}
