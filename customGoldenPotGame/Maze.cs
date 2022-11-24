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
            const char horiLine = '-';


            //short for Box with open top
            public static void genBoxOpTop()
            {
                // line below only for debugging
                Console.SetCursorPosition(30, 15);
                // y-axis, down, last var doesnt matter because its for x-axis generating only
                genLine(true, false, false);                
                // x-Axis, doesnt matter, left
                genLine(false, false, false);
                // y- Axis, up, doesn't matter
                genLine(true, true, false);
            }
            //bool y asks if it is supposed to be a vertical line
            //bool up asks if up or down, left asks for left or right
            //Cursor Position might automatically advance to the right !!!
            //make this more efficient
            private static void genLine(bool y, bool up, bool right)
            {
                if (y)
                {
                    if (up) {
                        for (int i = 0; i <= 1; i++) { 
                            // prevents overwriting and or wrong position
                            if (i < 1)
                            {

                                Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop - 1);
                                Console.Write(verLine);
                            }
                            else {
                                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop - 1);
                                Console.Write(verLine);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= 1; i++)
                        {
                            Console.Write(verLine);
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
                        }
                    }
                }
                else
                {
                    if (right)
                    {
                        for (int i = 0; i <= 4; i++)
                        {
                            Console.Write(horiLine);
                            Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= 4; i++)
                        {
                            Console.Write(horiLine);
                            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop );
                        }
                    }

                }
            }
        }
    }
}
