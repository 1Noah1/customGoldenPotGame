using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
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
