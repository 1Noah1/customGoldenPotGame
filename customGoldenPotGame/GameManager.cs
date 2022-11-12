using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customGoldenPotGame
{
    public class GameManager
    {
        public static int[] boundaries = new int[4];
        public static int Width { get; set; }
        public static int Height { get; set; }

        public GameManager()
        {
            // values aren't declared in renderCanvas because we need to acces these vals from other functions
            Width = 60;
            Height = Width / 2;

            // these values should not have individual ints
            // they should just reference the Widht and Height vars from the Map class
            // maybe order these values differently (by wasd system) 

            //border right
            GameManager.boundaries[0] = GameManager.Width + 5;
            //border left
            GameManager.boundaries[1] = 7;
            //border bottom
            GameManager.boundaries[2] = GameManager.Height + 2;
            //border top
            GameManager.boundaries[3] = 4;
        }
        public static void renderCharAtPos(int[] pos, char item)
        {
            Console.SetCursorPosition(pos[0], pos[1]);
            Console.Write(item);
        }
    }
}
