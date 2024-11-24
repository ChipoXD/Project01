using System;

namespace Project01
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using var game = new Project01.Game1();
            game.Run();
        }
    }
}
