using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customGoldenPotGame
{
    internal class MazeGen2
    {
        public static void genGrid()
        {
            Console.CursorVisible = true;

            Console.SetCursorPosition(7, 3);
            int i = Console.CursorLeft;


            while (i <= GameManager.Width){
                // the x must be one lower than the actual 5 length i need
                i += 6;
                Console.SetCursorPosition(i, Console.CursorTop);
                int j = 0;
                while ( j <= GameManager.Height - 2){
                    // -1 to compensate for automatic position advancement
                    Console.SetCursorPosition(Console.CursorLeft-1, Console.CursorTop + 1);
                    Console.Write("|");
                    Thread.Sleep(10);
                    j++;
                }
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - j);

                i++;
            }
            Console.Write(GameManager.countedLength);
        }

    }
}
