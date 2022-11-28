using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Security;
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

            // Item should be placed inside of the boxes
            // we'll 
            public const char verLine = '|';
            public const char horiBoxLine = '_';
            public const char horiPathLine = '-';
            // implement later
            //const char boxHoriLine = '_';
            const char tiltToRightLine = '/';
            const char tiltToLeftLine = '\\';

            public static void testPaths()
            {
                Console.SetCursorPosition(20, 20);
                
                Path.genYPath(2);
            }

            public static void testCorners()
            {
                int pathLength = 2;

                Console.SetCursorPosition(20, 15);

                Path.genXPathRight(pathLength);
                Corner.genCorner(true, false);

                Box.genBoxOpTop();
                //SetCursorPosition(Console.CursorLeft, Console.CursorTop + (2*pathLength));
                //Path.genYPath(pathLength);
            }

            public static void renderAllBoxes()
            {
                Box.genBoxOpBot();
                Box.genBoxOpLeft();
                Box.genBoxOpRight();
                Box.genBoxOpTop();
            }


            public class Box
            {
                //short for Box with open top
                public static void genBoxOpTop()
                {
                    // line below only for debugging

                    Lines.drawYLine(false);
                    Lines.drawXLine(true, horiPathLine);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                    Lines.drawYLine(true);
                }
                public static void genBoxOpRight()
                {
                    Console.SetCursorPosition(40, 15);


                    Console.Write(horiBoxLine);
                    Lines.drawXLine(false, horiBoxLine);
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Lines.drawYLine(false);
                    Lines.drawXLine(true, horiBoxLine);

                }

                public static void genBoxOpLeft()
                {
                    Console.SetCursorPosition(15, 15);


                    Lines.drawXLine(true, horiBoxLine);
                    Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop + 1);
                    Lines.drawYLine(true);
                    Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop - 1);
                    Console.Write(horiBoxLine);
                    Lines.drawXLine(false, horiBoxLine);
                }

                public static void genBoxOpBot()
                {
                    Console.SetCursorPosition(30, 15);
                    Lines.drawYLine(true);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    Lines.drawXLine(true, horiPathLine);
                    Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                    Lines.drawYLine(false);
                }
            }
            public class Corner
            {
                public static void genCorner(bool startPointingRight, bool endingPointingUp)
                {
                    if (startPointingRight && endingPointingUp)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 2);
                        Console.Write(horiPathLine);
                        Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                        Console.Write(horiPathLine);
                        Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                        Console.Write(tiltToLeftLine);
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop - 1);
                        Console.Write(verLine);
                    }
                    else if (startPointingRight && !endingPointingUp)
                    {
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                        Console.Write(horiPathLine);
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                        Console.Write(tiltToLeftLine);
                        for (int i = 0; i <= 1; i++) 
                        { 
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
                            Console.Write(verLine);
                        }
                        Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);

                    }
                    else if(!startPointingRight && endingPointingUp)
                    {
                        Console.Write(verLine);
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 2);
                        Console.Write(horiPathLine);
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                        Console.Write(horiPathLine);
                        Console.Write(tiltToRightLine);
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                        Console.Write(verLine);
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop - 1);
                        Console.Write(verLine);
                        Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);

                    }
                    else if(!startPointingRight && !endingPointingUp)
                    {

                    }

                }
            }


            public class Lines
            {
                public static void drawXLine(bool right, char lineType)
                {
                    if (right)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                            Console.Write(lineType);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                            Console.Write(lineType);
                        }

                    }
                }
                public static void drawYLine(bool above)
                {
                    if (above)
                    {
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
            public class Path
            {
                // make no Argument possible
                // when no argument is given length should be one
                public static void genXPathRight(int pathLength)
                {
                    for (int i = 0; i <= pathLength; i++)
                    {

                        Lines.drawXLine(true, horiPathLine);
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 2);
                        Lines.drawXLine(false, horiPathLine);
                        for (int j = 0; j < 2; j++)
                        {
                            Console.Write(horiPathLine);
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
                        Lines.drawYLine(true);
                        Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop - 1);
                        Lines.drawYLine(false);
                        Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                    }
                }

                public static void genXPathRight()
                {
                    Console.SetCursorPosition(15, 20);

                    Lines.drawXLine(true, horiPathLine);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 2);
                    Lines.drawXLine(false, horiPathLine);
                    for (int j = 0; j < 2; j++)
                    {
                        Console.Write(horiPathLine);
                    }
                }
            }


        }
    }
}
