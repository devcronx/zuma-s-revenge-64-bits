using System;

namespace ZumasRevenge
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new GameMain())
                game.Run();
        }
    }
}
