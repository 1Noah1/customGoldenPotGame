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

        public static int[] mainPlayerPos = new int[2];
        
        public static int[] itemPos = new int[2];


        // make 2 dimensional array or 2 dimensional list
        //public int[] possibleItemPos = new int[];

        private static int score;

        public GameManager()
        {
            score = 0;
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
        public static void detectItem()
        {
            if (mainPlayerPos[0] == itemPos[0] 
                && mainPlayerPos[1] == itemPos[1])
            {
                Item Item = new();
                score++;
                Console.SetCursorPosition(8, 0);
                Console.Write(score);
            }
        }
    }
}
