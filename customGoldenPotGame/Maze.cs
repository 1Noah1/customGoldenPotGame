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
            // all Paths with and without offset checked for last Cursor Pos edit: put more effort into checking next time, they failed the first test i did
                // Cursor Pos has to be on the relative left
                    // no offset = regular left top, offset = regular right bottom
            Console.SetCursorPosition(30, 15);
            Console.Write("R");
            int stdPathLength = 2;

            assets.Path.genXPathRight(stdPathLength, true);
            assets.Corner.genCorner(true, false);
            assets.Path.genYPath(stdPathLength, true);



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
                    Console.Write("C");
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
                    assets.Path.genXPathRight(standardPathLength, false);

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
                    assets.Path.genXPathRight(standardPathLength, false);
                    
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

                    Console.Write(horiBoxLine);
                    Lines.drawXLine(false, horiBoxLine);
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Lines.drawYLine(false);
                    Lines.drawXLine(true, horiBoxLine);




                }

                public static void genBoxOpLeft()
                {
                    

                    Lines.drawXLine(true, horiBoxLine);
                    Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop + 1);
                    Lines.drawYLine(true);
                    Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop - 1);
                    Console.Write(horiBoxLine);
                    Lines.drawXLine(false, horiBoxLine);
                }

                public static void genBoxOpBot()
                {
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
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop - 2);
                        Console.Write(horiPathLine);
                        Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                        Console.Write(tiltToRightLine);
                        Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop + 1);
                        Console.Write(verLine);
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
                        Console.Write(verLine);
                        Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop);
                        Console.Write(tiltToRightLine);
                        Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                    }
                    else if(!startPointingRight && endingPointingUp)
                    {
                        Console.Write(tiltToRightLine);
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
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                        Console.Write(horiPathLine);
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                        Console.Write(tiltToLeftLine);
                        for (int i = 0; i <= 1; i++)
                        {
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
                            Console.Write(verLine);
                        }
                        Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop);
                        Console.Write(tiltToLeftLine);
                        // if following asset seems off might be line below
                        Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);


                    }

                }
            }
            public class Path
            {
                // make no Argument possible
                // when no argument is given length should be one
                // this offset works for pathlength of 2
                // Console.SetCursorPosition(Console.CursorLeft - (5+(2* stdPathLength)), Console.CursorTop);

                public static void genXPathRight(int pathLength, bool offset)
                {
                    if (offset)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - (3 +(2 * pathLength)), Console.CursorTop);
                    }
                    for (int i = 0; i <= 2/pathLength; i++)
                    {
                        Lines.drawXLine(true, horiPathLine);
                    }
                    Console.SetCursorPosition(Console.CursorLeft +1, Console.CursorTop + 2);
                    for (int i = 0; i <= 2 / pathLength; i++)
                    {
                        Lines.drawXLine(false, horiPathLine);
                    }
                    if (!offset) { 
                        Console.SetCursorPosition(Console.CursorLeft + (1+(2 * pathLength)), Console.CursorTop - 2);
                    }
                    else
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    }

                }

                public static void genYPath(int pathLength, bool offset)
                {
                    // deafault direction is up offset is needed when down should be down
                    // SetCursorPos(CursorLeft, ConsoleTop + (2 * pathLength))
                    // checked
                    
                    if (!offset)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        //Console.Write("U");//debug
                    }
                    else
                    {
                        // works for pathLength of 2
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + ( 1 + (3 * pathLength)));
                        //Console.Write("D");//debug
                    }

                    for (int i = 0; i <= pathLength; i++)
                    {


                        Lines.drawYLine(true);
                        Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop + 2);
                        Lines.drawYLine(true);
                        
                        Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                    }
                    if (offset)
                    {
                        Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop + (1 + (2 * pathLength)));
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
                        for (int i = 0; i < 3; i++)
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
