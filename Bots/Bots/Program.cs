using System;

namespace Bots
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            if(!Constants.Load("Settings.txt"))
            {
                return;
            }

            using (Game1 game = new Game1())
            {
                game.Run();
            }
        }
    }
#endif
}

