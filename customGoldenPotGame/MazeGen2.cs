using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace customGoldenPotGame
{
    // !!! when middle points of boxes are saved in array check if they are actually in the middle, because they might not be, because of weird offset to the right after character has been writtej


    internal class MazeGen2
    {
        public static void genGrid()
        {
            int startX = 7;
            int startY = 3;
            Console.SetCursorPosition(startX, startY);
            Console.CursorVisible = true;
            genVerLines();
            Console.SetCursorPosition(startX, startY);
            genHoriLines();
            Console.SetCursorPosition(startX, startY);
            int [][,] middlePoints= genMiddlePoints();
            printMiddlePoints(middlePoints);
            
            Console.ReadKey();
        }

        public static void printMiddlePoints(int[][,] middlePoints)
        {
            // this functio draws only 3 points

            for (int i = 0; i < middlePoints.GetLength(0); i++)
            {
                for (int j = 0; j < middlePoints[i].GetLength(1); j++)
                {
                    // i'm probably itteration wrong thorugh the array
                    Thread.Sleep(500);
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine(Convert.ToString(middlePoints[i][j, 1]) + " " +  Convert.ToString(middlePoints[i][j, 2]));
                    Console.SetCursorPosition(middlePoints[i][j, 1], middlePoints[i][j, 2]);
                    Console.Write("*");

                }
            }

        }
        private static int[][,] genMiddlePoints()
        {
            int[][,] middlePoints = new int[5][,] {

             new int[,] { { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
             new int[,] { { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
             new int[,] { { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
             new int[,] { { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
             new int[,] { { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
            };

            // some offset is wrong (Console.CursorLeft needs to be increased)


            Console.Write("I");
            Console.SetCursorPosition(Console.CursorLeft -4, Console.CursorTop +3);
            
            for (int i = 0; i <= 4; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    //increase by Console.CursorLeft by one more after debuggin
                    middlePoints[i][j, 1] = Console.CursorLeft;
                    middlePoints[i][j, 2] = Console.CursorTop;
                    Console.SetCursorPosition(Console.CursorLeft + 5, Console.CursorTop);
                    //Console.Write("*");
                    Thread.Sleep(100);

                }
                Console.SetCursorPosition(Console.CursorLeft- (Console.CursorLeft - 4), Console.CursorTop + 6);
            }



            return middlePoints;
        }

        
        private static void genHoriLines()
        {
            

            int i = Console.CursorTop;
            
            while (i <= GameManager.Height)
            {
                int column = 0;
                int row = 0;
                i += 6;
                Console.SetCursorPosition(Console.CursorLeft, i);
                int j = 1;
                while ( j <= GameManager.Width)
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                    Console.Write("-");
                    //middle Points should be set by different Function

                    // this sets the middle point
                    /*if (j != 0)
                     {
                         if (j % 2 != 0 && j % 3 == 0)
                         {
                             // if middle is off take away -1 on CursorLeft
                             Console.SetCursorPosition(Console.CursorLeft , Console.CursorTop - 3);
                             Thread.Sleep(100);
                             Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                             Console.Write("*");

                             column++;
                             Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 3);
                         }
                     }
                    if(column == 5)
                     {
                         row++;
                         column = 0;
                     }
                    */
                    j++;
                   
                }
                Console.SetCursorPosition(Console.CursorLeft - (j - 1), Console.CursorTop);
            }
            

        }
        
        private static void genVerLines()
        {

            //Console.Write("I");
            Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
            int i = Console.CursorLeft;
            while (i <= GameManager.Width)
            {
                i += 5;
                Console.SetCursorPosition(i, Console.CursorTop);
                int j = 0;
                while (j <= GameManager.Height - 1)
                {
                    // -1 to compensate for automatic position advancement
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
                    Console.Write("|");
                    j++;
                }
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - j);

                i++;
            }

        }

    }
}
