using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace customGoldenPotGame
{



    internal class MazeGen2
    {
        internal static int[][,] middlePoints = new int[5][,] {

             new int[,] { { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
             new int[,] { { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
             new int[,] { { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
             new int[,] { { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
             new int[,] { { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
            };
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
            genMiddlePoints();
            printMiddlePoints();
            
        }
        private void placeAsset(int row, int column)
        {
            // this should place the asset and mark the assets as occupied (look at local documentation
        }

        public static void testV2Assets()
        {
            int testLength = 5;


            // should be middle of top left
            Console.SetCursorPosition(middlePoints[0][0, 1], middlePoints[0][0, 2]);
            middlePoints[0][0, 0] = 1;

            Gen2Assets.genYLine(testLength);
            
        }

        public static void printMiddlePoints()
        {
            // this functio draws only 3 points

            for (int i = 0; i < middlePoints.GetLength(0); i++)
            {
                for (int j = 0; j < middlePoints[i].GetLength(0); j++)
                {
                    //debugging
                    Thread.Sleep(10);

                    Console.SetCursorPosition(middlePoints[i][j, 1], middlePoints[i][j, 2]);
                    
                    Console.Write("*");

                }
            }

        }
        private static void genMiddlePoints()
        {
            // points are placed in array from top to bottom, left to right


            //debugging
            Console.Write("I");

            Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop +3);
            
            for (int i = 0; i <= 4; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    //increase by Console.CursorLeft by one more after printMiddlePoints
                    middlePoints[i][j, 1] = Console.CursorLeft;
                    middlePoints[i][j, 2] = Console.CursorTop;
                    Console.SetCursorPosition(Console.CursorLeft + 6, Console.CursorTop);

                    //debugging
                    //Thread.Sleep(10);

                }
                Console.SetCursorPosition(Console.CursorLeft- (Console.CursorLeft - 9), Console.CursorTop + 6);
            }
        }

        
        private static void genHoriLines()
        {
            

            int i = Console.CursorTop;
            
            while (i <= GameManager.Height)
            {
                i += 6;
                Console.SetCursorPosition(Console.CursorLeft, i);
                int j = 1;
                while ( j <= GameManager.Width)
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                    Console.Write("-");
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
