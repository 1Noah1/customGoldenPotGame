using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customGoldenPotGame
{
    public class Map
    {

        private int padding { get; set; }

        public Map()
        {

            padding = 12;

            Console.CursorVisible = false;
        }

        public void renderMap()
        {
            Console.Clear();
            // decreased Bufferheight for performance
            //probably doesn't affect performace drastically
            Console.BufferHeight = 50;

            //Score
            Console.SetCursorPosition(1, 0);
            Console.Write("Score: 0");


            Console.WindowHeight = GameManager.Height + padding / 2;
            Console.WindowWidth = GameManager.Width + padding;
            // top
            for (int i = 1; i < GameManager.Width; i++)
            {
                Console.SetCursorPosition(padding / 2 + i, padding / 4);
                Console.Write(Maze.assets.horiBoxLine);
            }
            // bottom
            for (int i = 0; i <= GameManager.Width; i++)
            {
                Console.SetCursorPosition(padding / 2 + i, GameManager.Height + padding / 4);
                Console.Write(Maze.assets.horiPathLine);
            }
            // left
            for (int i = 1; i <= GameManager.Height; i++)
            {
                Console.SetCursorPosition(padding / 2, i + padding / 4);
                Console.Write(Maze.assets.verLine);
            }
            // right
            for (int i = 1; i <= GameManager.Height; i++)
            {
                Console.SetCursorPosition(GameManager.Width + padding / 2, i + padding / 4);
                Console.Write(Maze.assets.verLine);
            }
        }
    }
}
