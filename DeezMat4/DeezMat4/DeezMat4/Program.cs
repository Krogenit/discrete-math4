using System;

namespace DeezMat4
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Core game = new Core(0,0,0))
            {
                game.Run();
            }
        }
    }
#endif
}

