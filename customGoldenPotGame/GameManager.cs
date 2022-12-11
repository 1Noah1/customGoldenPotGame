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
        public static int[] badItemPos = new int[2];

        private static int score;

        public static int countedLength = 0;

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
        public static bool detectItem()
        {
            if (mainPlayerPos[0] == itemPos[0] 
                && mainPlayerPos[1] == itemPos[1])
            {
                Console.SetCursorPosition(badItemPos[0], badItemPos[1]);
                Console.Write(" ");
                Item Item = new();
                score++;
                Console.SetCursorPosition(8, 0);
                Console.Write(score);
                return false;
            }
            else if(mainPlayerPos[0] == badItemPos[0]
                && mainPlayerPos[1] == badItemPos[1])
                {
                Console.SetCursorPosition(itemPos[0], itemPos[1]);
                Console.Write(" ");
                Item Item = new();
                score--;
                if(score < 0)
                {
                    Menu.renderFailscreen();
                    return true;
                }
                else
                {
                    Console.SetCursorPosition(8, 0);
                    Console.Write(score);
                    return false;

                }
            }
            return false;
        }
    }
}
