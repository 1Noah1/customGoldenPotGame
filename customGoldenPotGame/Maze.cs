using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace customGoldenPotGame
{
    public class Maze
    {
        private int pathLength;

        public Maze()
        {

            pathLength = 2;
            
        }
        public void genMaze()
        {
            Random random = new();

            Console.SetCursorPosition(GameManager.mainPlayerPos[0], GameManager.mainPlayerPos[1] + 1);
            assets.Path.genYPath(pathLength);

            int rndNum = random.Next(1,4);
            if ( rndNum < 4)
            {
                decideOnRnd(false, rndNum, random);
            }
            else
            {
                decideOnRnd(true, rndNum, random);
            }

            
        }
        public void decideOnRnd(bool isBox, int uniqueRndNum, Random rndObj)
        {
            if (isBox)
            {
                uniqueRndNum = rndObj.Next(1, 2);
            }

            int[] dirAndCorner = getRealitiveDirection(uniqueRndNum, lastDir);

            if (uniqueRndNum == 1)
            {
                if (isBox)  
                {
                    assets.Box.genBoxOpRight();
                    //drawRelativeBox (non relative relative left)
                    //return lastDir;

                }
                else
                {
                    
                    
                    //left
                    // drawRelativePath (non relative relative left)
                    //return lastDir;
                }

            }
            else if (uniqueRndNum == 2)
            {
                //irght

                if (isBox)
                {
                    assets.Box.genBoxOpLeft();
                    //drawRelativeBox
                    //return lastDir;

                }
                else
                {
                    // drawRelativePath
                    //return lastDir;
                }

            }
            else if(uniqueRndNum == 3)
            {


                // up


                // drawRelativePath
                //return lastDir;

            }
            else
            {
                //bottom / down case
            }

            


        }
        public static int[] getRealitiveDirection(int nextDir, int lastDir)
        {
            if(lastDir == 1)
            {
                if (nextDir == 1)
                {
                    // corner opLeftToBot (4)
                    // dirAndCorner[0] = 4, dirAndCorner = 4
                    int[] dirAndCorner = { 4, 4 };
                    return dirAndCorner;
                }else if(nextDir == 2)
                {
                    //corner 2
                    int[] dirAndCorner = { 3, 2 };    
                    return dirAndCorner;
                }else
                {
                    int[] dir = { 5 };
                    return dir;
                }
            }else if (lastDir == 2)
            {
                if (nextDir == 1)
                {
                    // corner 1
                    int[] dirAndCorner = { 3, 3 };

                    return dirAndCorner;
                }
                else if (nextDir == 2)
                {
                    int[] dirAndCorner = { 4, 3 }
                    return dirAndCorner;
                }
                else
                {
                    int[] dir = { 2 };
                    return dir;
                }
            }
            else if(lastDir == 3)
            {
                if(nextDir == 1)
                {

                    int[] dirAndCorner = { nextDir, 3 };
                    return dirAndCorner;
                }else if(nextDir == 2)
                {
                    int[] dirAndCorner = { nextDir, 4 };
                    return dirAndCorner;
                }else
                {
                    int[] dir = { nextDir };
                    return dir;
                }

            }
            else
            {
                if (nextDir == 1)
                {
                    int[] dirAndCorner = { 2, 2 };
                    return dirAndCorner;
                }
                else if (nextDir == 2)
                {
                    int[] dirAndCorner = { 1, 1 };
                    return dirAndCorner;
                }
                else
                {
                    int[] dir = { lastDir };
                    return dir;
                }
            }
            

            //next dir 1 == left
            // next dir 


        }

        public class assets
        {

            // Item should be placed inside of the boxes
            internal const char verLine = '|';
            internal const char horiBoxLine = '_';
            internal const char horiPathLine = '-';
            internal const char tiltToRightLine = '/';
            internal const char tiltToLeftLine = '\\';


            
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
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(horiPathLine);
                        Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                        Console.Write(tiltToRightLine);
                        Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop + 1);
                        Console.Write(verLine);
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
                        Console.Write(verLine);
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
