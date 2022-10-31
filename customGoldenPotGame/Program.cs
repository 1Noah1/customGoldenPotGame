using System.Security.Cryptography;

namespace customGoldenPotGame
{
    internal class Program
    {
        public class Map
        {
            public int Width { get; set; }
            public int Height { get; set; }
            private int padding { get; set; }

            public Map()
            {
                // values aren't declared in renderCanvas because we need to acces these vals from other functions
                Width = 60;
                Height = 30;
                padding = 12;

                Console.CursorVisible = false;
            }

            public void renderMap()
            {
                Console.Clear();
                Console.WindowHeight = Height + padding / 2;
                Console.WindowWidth = Width + padding;
                // top
                for (int i = 1; i < Width; i++)
                {
                    Console.SetCursorPosition(padding / 2 + i, padding / 4);
                    Console.Write("_");

                }
                // bottom
                for (int i = 0; i <= Width; i++)
                {
                    Console.SetCursorPosition(padding / 2 + i, Height + padding / 4);
                    Console.Write("_");
                }
                // left
                for (int i = 1; i <= Height; i++)
                {
                    Console.SetCursorPosition(padding / 2, i + padding / 4);
                    Console.Write("|");
                }
                // right
                for (int i = 1; i <= Height; i++)
                {
                    Console.SetCursorPosition(Width + padding / 2, i + padding / 4);
                    Console.Write("|");
                }
            }
        }
        public class Pos
        {

        }
        public class Hero {

        }

        static void Main(string[] args)
        {
            bool exit = false;
            Map map = new Map();
            //Hero hero = new Hero();
            // decreased Bufferheight for performance
            Console.BufferHeight = 50;
            while (!exit)
            {
                map.renderMap();
                //for debugging
                Thread.Sleep(20000);     
            }
        }
    }
}