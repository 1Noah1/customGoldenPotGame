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
        public static void testAssets()
        {
            Console.SetCursorPosition(5, 20);
            Console.Write("1");
            Console.SetCursorPosition(10, 20);
            assets.Corner.genCorner(false, true);

            Console.SetCursorPosition(15, 20);

            Console.Write("2");
            Console.SetCursorPosition(20, 20);
            assets.Corner.genCorner(true, true);

            Console.SetCursorPosition(25, 20);

            Console.Write("3");
            Console.SetCursorPosition(30, 20);
            assets.Corner.genCorner(false, false);
        }
        public void genMaze()
        {
            Random random = new();

            Console.SetCursorPosition(GameManager.mainPlayerPos[0], GameManager.mainPlayerPos[1] - 15);
            //no offset
            assets.Path.genYPath(pathLength, false);
            Console.Write("A");
            
            int lastDir = 3;
            
            for (int i = 0; i<1; i++) { 
                int rndNum = random.Next(1,4);
                if ( rndNum < 4)
                {

                    lastDir = decideOnRnd(lastDir,false, rndNum, random);
                    Console.Write("B");

                }
                else
                {
                    lastDir = decideOnRnd(lastDir, true, rndNum, random);
                }
            }


        }
        public int decideOnRnd(int lastDir, bool isBox, int uniqueRndNum, Random rndObj)
        {
            int standardPathLength = 2;

            if (isBox)
            {
                uniqueRndNum = rndObj.Next(1, 2);
            }

            int[] dirAndCorner = getRealitiveDirection(uniqueRndNum, lastDir);

            if (dirAndCorner[0] == 1)
            {
                if (isBox)
                {
                    assets.Box.genBoxOpRight();
                    //drawRelativeBox (non relative relative left)

                    return 5;
                }
                else
                {

                    assets.Corner.decideOnCorrectCorner(dirAndCorner);
                    // offset for left
                    // might need to change to Console.CursorLeft - (1+(2*standardPathLength),
                    Console.SetCursorPosition(Console.CursorLeft - (2 * standardPathLength), Console.CursorTop);
                    assets.Path.genXPathRight(standardPathLength);

                    return 1;
                }


            }
            else if (dirAndCorner[0] == 2)
            {
                //right

                if (isBox)
                {
                    assets.Box.genBoxOpLeft();
                    //drawRelativeBox
                    return 6;

                }
                else
                {
                    assets.Corner.decideOnCorrectCorner(dirAndCorner);
                    assets.Path.genXPathRight(standardPathLength);
                    
                    return 2;
                }

            }
            else if (dirAndCorner[0] == 3)
            {
                //up
                if (isBox)
                {
                    assets.Box.genBoxOpBot();
                    return 7;
                }
                else
                {
                    assets.Corner.decideOnCorrectCorner(dirAndCorner);
                    assets.Path.genYPath(standardPathLength, false);
                    return 3;
                }
            }
            else
            {
                //bottom / down case
                if (isBox)
                {
                    assets.Box.genBoxOpTop();
                    return 8;
                }
                else
                {
                    assets.Corner.decideOnCorrectCorner(dirAndCorner);

                    //offset for down
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 2 * standardPathLength);

                    assets.Path.genYPath(standardPathLength, true);
                    return 4;
                }

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
                    int[] dir = { 5, 0 };
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
                    int[] dirAndCorner = { 4, 3 };
                    return dirAndCorner;
                }
                else
                {
                    int[] dir = { 2, 0 };
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
                    int[] dir = { nextDir, 0 };
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
                    int[] dir = { lastDir, 0 };
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
                public static void decideOnCorrectCorner(int[] dirAndCorner)
                {
                    if (dirAndCorner[1] != 0) { 
                        if (dirAndCorner[1] == 1)
                        {
                            assets.Corner.genCorner(false, true);
                        }
                        else if (dirAndCorner[1] == 2)
                        {
                            assets.Corner.genCorner(true, true);
                        }
                        else if (dirAndCorner[1] == 3)
                        {
                            assets.Corner.genCorner(false, false);
                        }
                        else
                        {
                            assets.Corner.genCorner(true, false);
                        }
                    }
                }
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

                public static void genYPath(int pathLength, bool offset)
                {
                    // deafault direction is up offset is needed when down should be down
                    // SetCursorPos(CursorLeft, ConsoleTop + (2 * pathLength))
                    for (int i = 0; i <= pathLength; i++)
                    {
                        // needs to be fixed
                        Lines.drawYLine(true);
                        Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop + 2);
                        Lines.drawYLine(true);
                        Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                    }
                    if (!offset)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        //Console.Write("U");//debug
                    }
                    else
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + ( 1 + (2 * pathLength)));
                        //Console.Write("D");//debug
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
        }
    }
}
