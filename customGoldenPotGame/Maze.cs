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
            public const char verLine = '|';
            public const char horiLine = '_';
            // implement later
            //const char boxHoriLine = '_';
            const char tiltToRightLine = '/';
            const char tiltToLeftLine = '\\';


            public static void testPathsAndCorners()
            {
                int pathLength = 2;

                Console.SetCursorPosition(20, 15);

                //setup for corner
                // input of 2 translates to lenght of 9
                Path.genXPathRight(pathLength);
                // set cursor Position to beginning of genXPathRight**
                Console.SetCursorPosition(Console.CursorLeft -  (1 + (4 * pathLength)), Console.CursorTop);
                // position checker
                Console.Write("*");


                Corner.genCorner(true, true);

                //Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop);
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
                    Console.SetCursorPosition(30, 15);

                    Lines.drawYLine(false);
                    Lines.drawXLine(true);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                    Lines.drawYLine(true);
                }
                public static void genBoxOpRight()
                {
                    Console.SetCursorPosition(40, 15);


                    Console.Write(horiLine);
                    Lines.drawXLine(false);
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Lines.drawYLine(false);
                    Lines.drawXLine(true);

                }

                public static void genBoxOpLeft()
                {
                    Console.SetCursorPosition(15, 15);


                    Lines.drawXLine(true);
                    Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop + 1);
                    Lines.drawYLine(true);
                    Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop - 1);
                    Console.Write(horiLine);
                    Lines.drawXLine(false);
                }

                public static void genBoxOpBot()
                {
                    Console.SetCursorPosition(30, 15);
                    Lines.drawYLine(true);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    Lines.drawXLine(true);
                    Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                    Lines.drawYLine(false);
                }
            }
            public class Corner
            {
                public static void genCorner(bool startPointingRight, bool endingPointingUp)
                {
                    if(startPointingRight && endingPointingUp)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                        Console.Write(tiltToLeftLine);
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 2);
                        Console.Write(horiLine);
                        
                        Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                        Console.Write(horiLine);
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(tiltToLeftLine);
                        Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                        //Console.SetCursorPosition();


                    }
                    else if (startPointingRight && !endingPointingUp)
                    {

                    }else if(!startPointingRight && endingPointingUp)
                    {
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
                    else if(!startPointingRight && !endingPointingUp)
                    {

                    }

                }
            }


            public class Lines
            {
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

                        Lines.drawXLine(true);
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 2);
                        Lines.drawXLine(false);
                        for (int j = 0; j < 2; j++)
                        {
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
                        Lines.drawYLine(true);
                        Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop - 1);
                        Lines.drawYLine(false);
                        Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                    }
                }

                public static void genXPathRight()
                {
                    Console.SetCursorPosition(15, 20);

                    Lines.drawXLine(true);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 2);
                    Lines.drawXLine(false);
                    for (int j = 0; j < 2; j++)
                    {
                        Console.Write(horiLine);
                    }
                }
            }


        }
    }
}
