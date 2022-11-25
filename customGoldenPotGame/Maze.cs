using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace customGoldenPotGame
{
    public class Maze
    {
        public class assets
        {
            const char verLine = '|';
            const char horiLine = '_';
            const char tiltToRightLine = '/';
            const char tiltToLeftLine = '\\';


            public static void renderAllPaths()
            {
                int pathLength = 2;

                Console.SetCursorPosition(12, 15);

                //setup for corner
                genXPathRight(pathLength);

                genCorner(false, true);

                //Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop);
                genYPath(pathLength);

                

            }

            public static void genCorner(bool startPointingRight, bool endingPointingUp)
            {
                //reference line
                Console.Write(tiltToRightLine);

                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 2);
                Console.Write(horiLine);
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                Console.Write(horiLine);
                Console.Write(tiltToRightLine);

                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                Console.Write(verLine);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop - 1);
                Console.Write(verLine);
                Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);





            }



            // make no Argument possible
            // when no argument is given length should be one
            public static void genXPathRight(int pathLength)
            {
                for (int i = 0; i <= pathLength; i++) { 
 
                    drawXLine(true);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 2);
                    drawXLine(false);
                    for (int j = 0; j < 2; j++) { 
                        Console.Write(horiLine);
                    }
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 2);
                }
            }

            public static void genYPath(int pathLength)
            {
                // deafault direction is up offset is needed when down should be down
                // SetCursorPos(CursorLeft, 2 * pathLength)

                for (int i = 0; i <= pathLength; i++)
                {
                    drawYLine(true);
                    Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop - 1);
                    drawYLine(false);
                    Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                }
            }

            public static void genXPathRight()
            {
                Console.SetCursorPosition(15, 20);

               drawXLine(true);
               Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 2);
               drawXLine(false);
               for (int j = 0; j < 2; j++)
               {
                    Console.Write(horiLine);
               }
                

            }

            public static void renderAllBoxes()
            {
                genBoxOpBot();
                genBoxOpLeft();
                genBoxOpRight();
                genBoxOpTop();
                  
            }
            //short for Box with open top
            public static void genBoxOpTop()
            {
                // line below only for debugging
                Console.SetCursorPosition(30, 15);

                drawYLine(false);
                drawXLine(true);
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                drawYLine(true);
            }
            public static void genBoxOpRight()
            {
                Console.SetCursorPosition(40, 15);


                Console.Write(horiLine);
                drawXLine(false);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                drawYLine(false);
                drawXLine(true);

            }

            public static void genBoxOpLeft()
            {
                Console.SetCursorPosition(15,15);


                drawXLine(true);
                Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop + 1);
                drawYLine(true);
                Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop - 1);
                Console.Write(horiLine);
                drawXLine(false);
            }

            public static void genBoxOpBot()
            {
                Console.SetCursorPosition(30, 15);
                drawYLine(true);
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                drawXLine(true);
                Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                drawYLine(false);
            }
            public static void drawXLine(bool right)
            {
                if (right)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                        Console.Write(horiLine);
                    }
                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                        Console.Write(horiLine);
                    }

                }
            }
            public static void drawYLine(bool above)
            {
                if (above) {
                    for (int i = 0; i < 2; i++)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop - 1);
                        Console.Write(verLine);
                    }
                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
                        Console.Write(verLine);
                    }

                }
            }
        }
    }
}
