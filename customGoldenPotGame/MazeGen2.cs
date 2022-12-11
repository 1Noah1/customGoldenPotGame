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
        // this saves the last quadrant
        // [0] = row, [1] = 1 column
        private static int[] lastPos = { 4, 4 };

        private static int stdLength = 5;

        private static int startX = 7;
        private static int startY = 3;

        internal static int[][,] middlePoints = new int[5][,] {

             new int[,] { { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
             new int[,] { { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
             new int[,] { { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
             new int[,] { { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
             new int[,] { { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 },{ 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
            };
        public static void genGrid()
        {

            Console.SetCursorPosition(startX, startY);
            Console.CursorVisible = true;
            genVerLines();
            Console.SetCursorPosition(startX, startY);
            genHoriLines();
            Console.SetCursorPosition(startX, startY);
            genMiddlePoints();
            //printMiddlePoints();
            
        }

        private static void placeItem()
        {
            for (int i = 0; i < middlePoints.GetLength(0); i++)
            {
                for (int j = 0; j < middlePoints[i].GetLength(0); j++)
                {
                    //debugging
                    //Thread.Sleep(10);
                    if (middlePoints[i][j,0] == 1)
                    {
                        Item item = new Item(middlePoints[i][j, 1], middlePoints[i][j, 2]);
                        Item.renderItem();
                    }


                }
            }
        }


        private static void placeAsset(int row, int column, string asset, int length)
        {


            Console.SetCursorPosition(middlePoints[row][column,1], middlePoints[row][column, 2]);
            switch (asset)
            {
                case "genXPath":
                    Gen2Assets.genXPath(length);
                    break;
                case "genYPath":
                    Gen2Assets.genYPath(length);
                    break;
                case "genCornerLeftAndTop":
                    Gen2Assets.genCornerLeftAndTop(length);
                    break;
                case "genCornerRightAndTop":
                    Gen2Assets.genCornerRightAndTop(length);
                    break;
                case "genCornerLeftAndBottom":
                    Gen2Assets.genCornerLeftAndBottom(length);
                    break;
                case "genCornerRightAndBottom":
                    Gen2Assets.genCornerRightAndBottom(length);
                    break;
                default:
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Invalid switch case in placeAsset function (default case triggered)");
                    break;


            }

            // marks the spots as occupied
            middlePoints[row][column, 0] = 1;
        }

        public static void testV2Assets()
        {
            int testLength = 5;


            // should be middle of top left
            Console.SetCursorPosition(middlePoints[0][0, 1], middlePoints[0][0, 2]);
            middlePoints[0][0, 0] = 1;

            Gen2Assets.genCornerRightAndBottom(testLength);
            
        }

        public static void printMiddlePoints()
        {

            for (int i = 0; i < middlePoints.GetLength(0); i++)
            {
                for (int j = 0; j < middlePoints[i].GetLength(0); j++)
                {
                    //debugging
                    //Thread.Sleep(10);

                    Console.SetCursorPosition(middlePoints[i][j, 1], middlePoints[i][j, 2]);
                    
                    Console.Write("O");

                }
            }
        }

        public static void genMaze()
        {
            Random random = new();
            int amountOfElements = 10;
            Console.SetCursorPosition(startX, startY);
            genMiddlePoints();


            // standard Position
            placeAsset(lastPos[0], lastPos[1], "genYPath", stdLength);
            int lastDir = 3;
            for (int i = 0; i < amountOfElements; i++)
            {
                // chooses on of the 3 possible directions
                int randomNum = random.Next(1, 4);
                // debugging
                Thread.Sleep(10);
                lastDir = decideOnNextElement(randomNum, lastDir);
            }

            Console.SetCursorPosition(middlePoints[lastPos[0]][lastPos[1], 1], middlePoints[lastPos[0]][lastPos[1], 2]);
            switch (lastDir)
            {
                case 1:
                    Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop);
                    Console.Write("|");
                    break;
                case 2:
                    Console.SetCursorPosition(Console.CursorLeft + 3, Console.CursorTop);
                    Console.Write("|");
                    break;
                case 3:
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 3);
                    Console.Write("-");
                    break;
                case 4:
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 3);
                    Console.Write("-");
                    break;

            }
            placeItem();




        }
        private static int decideOnNextElement(int nextDir, int lastDirection)
        {
            // first value in array ist direction second is the corner that will be used
            int[] nextDirAndCorner = getDirectionByRelativeDirection(nextDir, lastDirection);

            // Directions:
            // 1 = left
            // 2 = right
            // 3 = up
            // 4 = down
            // Corners:
            // 1 = LeftAndTop
            // 2 = RightAndTop
            // 3 = LeftAndBottom
            // 4 = RightAndBottom


            switch (nextDirAndCorner[0])
            {
                case 0: Console.SetCursorPosition(0, 0); Console.Write("This direction does not exist"); break;
                
                case 1:
                    if(lastDirection != 4)
                    {
                        // check if next quadrant will be out of range of too close to border
                        if (lastPos[0] > 0 && lastPos[1] > 0)
                        {
                            //next quadrant is straight left
                            if (lastDirection == 1)
                            {
                                if (lastPos[1] > 1)
                                {
                                    // no corner

                                    //check if quadrant is occupied
                                    if (middlePoints[lastPos[0]][lastPos[1] - 1, 0] == 0)
                                    {
                                        //quadrant is free
                                        placeAsset(lastPos[0], lastPos[1] - 1, "genXPath", stdLength);

                                        // lastPos[0] doesn't need a new value because the row doesn't change 
                                        lastPos[1] = lastPos[1] - 1;
                                        return nextDirAndCorner[0];
                                    }
                                    else
                                    {
                                        return lastDirection;
                                    }
                                }
                            }
                            else if (lastDirection == 3)
                            {
                                if (lastPos[0] > 0 && lastPos[1] > 1)
                                {
                                    // corner needed (LeftAndBottom)
                                    // check if next Quadrant and quadrant for corner are free
                                    if (middlePoints[lastPos[0] - 1][lastPos[1] - 1, 0] == 0 && middlePoints[lastPos[0] - 1][lastPos[1], 0] == 0 && middlePoints[lastPos[0] - 1][lastPos[1] - 2,0] == 0)
                                    {
                                        // quadrants are both free
                                        placeAsset(lastPos[0] - 1, lastPos[1], getCornerString(nextDirAndCorner[1]), stdLength);
                                        placeAsset(lastPos[0] - 1, lastPos[1] - 1, "genXPath", stdLength);
                                        lastPos[0] = lastPos[0] - 1;
                                        lastPos[1] = lastPos[1] - 1;
                                        return nextDirAndCorner[0];
                                    }
                                    else
                                    {
                                        return lastDirection;
                                        // One of the quadrant are already occupied
                                    }

                                }
                            }
                            else
                            {
                                return lastDirection;
                            }
                        }
                        else
                        {
                            return lastDirection;
                            // next Position would be out of range or too close to the border
                        }
                    }
                    else
                    {
                        // is down case
                        // check if next quadrant will be out of range
                        if (lastPos[0] < 4 && lastPos[1] > 0)
                        {
                            // check if quadrant will be occupied or not
                            if (middlePoints[lastPos[0] + 1][lastPos[1] - 1, 0] == 0 && middlePoints[lastPos[0] + 1][lastPos[1],0] == 0 && middlePoints[lastPos[0] + 1][lastPos[1] - 2, 0] == 0)
                            {
                                // quadrant is free
                                placeAsset(lastPos[0] + 1, lastPos[1], getCornerString(nextDirAndCorner[1]), stdLength);
                                placeAsset(lastPos[0] + 1, lastPos[1] - 1, "genXPath", stdLength);
                                lastPos[0] = lastPos[0] + 1;
                                lastPos[1] = lastPos[1] - 1;
                                return nextDirAndCorner[0];
                            }
                            else
                            {
                                return lastDirection;
                            }
                        }
                        else
                        {
                            return lastDirection;
                        }
                    }
                    return lastDirection;
                case 2:
                    if (lastDirection != 4)
                    {
                        if (lastPos[0] > 0 && lastPos[1] < 9)
                        {
                            if (lastDirection == nextDirAndCorner[0])
                            {
                                if (lastPos[1] < 8)
                                {
                                    // no corner
                                    //check if quadrant is occupied
                                    if (middlePoints[lastPos[0]][lastPos[1] + 1, 0] == 0)
                                    {
                                        // quadrant is free
                                        placeAsset(lastPos[0], lastPos[1] + 1, "genXPath", stdLength);

                                        lastPos[1] = lastPos[1] + 1;
                                        return nextDirAndCorner[0];
                                    }
                                    else
                                    {
                                        return lastDirection;
                                        // quadrant is occupied
                                    }
                                }
                            }else if (lastDirection == 3)
                            {
                                if (middlePoints[lastPos[0] - 1][lastPos[1],0] == 0 && middlePoints[lastPos[0]- 1][lastPos[1] + 1,0] == 0)
                                {
                                    // quadrants are both free

                                    placeAsset(lastPos[0] - 1, lastPos[1], getCornerString(4), stdLength);
                                    placeAsset(lastPos[0] - 1, lastPos[1] + 1, "genXPath", stdLength);
                                    lastPos[0] = lastPos[0] - 1;
                                    lastPos[1] = lastPos[1] + 1;
                                    return nextDirAndCorner[0];
                                }
                                else
                                {
                                    return lastDirection;
                                    // One or both quadrants are already occupied
                                }
                            }
                            else
                            {
                                return lastDirection;
                            }
                        }
                        else
                        {
                            return lastDirection;
                            // next Position would be out of range or too close to border
                        }
                    }
                    else
                    {
                        // down case

                        // check if next quadrant will be out of range
                        if (lastPos[0] < 4 && lastPos[1] < 8)
                        {
                            if (middlePoints[lastPos[0] + 1][lastPos[1],0] == 0 && middlePoints[lastPos[0]+ 1][lastPos[1] + 1, 0] == 0 && middlePoints[lastPos[0] + 1][lastPos[1] + 2, 0] == 0)
                            {
                                placeAsset(lastPos[0] + 1, lastPos[1], getCornerString(2), stdLength);
                                placeAsset(lastPos[0] + 1, lastPos[1] + 1, "genXPath", stdLength);
                                lastPos[0] = lastPos[0] + 1;
                                lastPos[1] = lastPos[1] + 1;
                                return nextDirAndCorner[0];
                            }
                            else
                            {
                                return lastDirection;
                                // Atleast one of the quadrants is already occupied
                            }
                        }
                        else
                        {
                            return lastDirection;
                        }
                    }
                    return lastDirection;
                case 3:
                    if( lastDirection == 1)
                    {
                        // check if it will be out of range
                        if (lastPos[0] > 1 && lastPos[1] > 0)
                        {
                            // check if quadrantes are occupied
                            if (middlePoints[lastPos[0]][lastPos[1] - 1, 0] == 0 && middlePoints[lastPos[0] - 1][lastPos[1] - 1, 0] == 0)
                            {
                                // quadrant is free
                                placeAsset(lastPos[0], lastPos[1] - 1, getCornerString(2), stdLength);
                                placeAsset(lastPos[0] - 1, lastPos[1] - 1, "genYPath", stdLength);
                                lastPos[0] = lastPos[0] - 1;
                                lastPos[1] = lastPos[1] - 1;
                                return nextDirAndCorner[0];
                            }
                            else
                            {
                                return lastDirection;
                                // quadrant is occupied
                            }
                        }
                        else
                        {
                            return lastDirection;
                            // element would be out of range
                        }
                    }else if ( lastDirection == 2)
                    {
                        if (lastPos[0] > 1 && lastPos[1] < 9)
                        {
                            if (middlePoints[lastPos[0]][lastPos[1] + 1,0] == 0 && middlePoints[lastPos[0] - 1][lastPos[1] + 1, 0] == 0)
                            {
                                placeAsset(lastPos[0], lastPos[1] + 1, getCornerString(1), stdLength);
                                placeAsset(lastPos[0] - 1, lastPos[1] + 1, "genYPath", stdLength);
                                lastPos[0] = lastPos[0] - 1;
                                lastPos[1] = lastPos[1] + 1;
                                return nextDirAndCorner[0];
                            }
                            else
                            {
                                return lastDirection;
                                // Quadrants are occupied
                            }
                        }
                        else
                        {
                            return lastDirection;
                            // item would be placed out of range
                        }
                    }else if (lastDirection == 3)
                    {
                        if (lastPos[0] > 1)
                        {
                            if (middlePoints[lastPos[0] - 1][lastPos[0],0] == 0 && middlePoints[lastPos[0] - 2][lastPos[0],0] == 0)
                            {
                                // quadrant is free
                                placeAsset(lastPos[0] - 1, lastPos[0], "genYPath", stdLength);
                                lastPos[0] = lastPos[0] - 1;
                                return nextDirAndCorner[0];
                            }
                            else
                            {
                                // qudrants are occupied
                                return lastDirection;
                            }

                        }
                        else
                        {
                            return lastDirection;
                            // Item would be outside of range
                        }
                    }
                    return lastDirection;
                case 4:
                    if (lastDirection == 1)
                    {
                        if (lastPos[0] < 3 && lastPos[1] > 0)
                        {
                            if (middlePoints[lastPos[0]][lastPos[1] - 1, 0] == 0 && middlePoints[lastPos[0] + 1][lastPos[1] - 1, 0] == 0 && middlePoints[lastPos[0] +2][lastPos[1] - 1,0] == 0)
                            {
                                placeAsset(lastPos[0], lastPos[1] - 1, getCornerString(4), stdLength);
                                placeAsset(lastPos[0] + 1, lastPos[1] - 1, "genYPath", stdLength);
                                lastPos[0] = lastPos[0] + 1;
                                lastPos[1] = lastPos[1] - 1;
                                return nextDirAndCorner[0];
                            }
                            else
                            {
                                return lastDirection;
                                // Quadrant is be occupied
                            }
                        }
                        else
                        {
                            return lastDirection;
                            // element would be placed out range
                        }
                    }
                    else if (lastDirection == 2)
                    {
                        if (lastPos[0] < 3 && lastPos[1] < 9)
                        {
                            if (middlePoints[lastPos[0]][lastPos[1] + 1, 0] == 0 && middlePoints[lastPos[0] + 1][lastPos[1] + 1, 0] == 0 && middlePoints[lastPos[0] + 2][lastPos[1] + 1, 0] == 0)
                            {
                                // quadrant is free

                                placeAsset(lastPos[0], lastPos[1] + 1, getCornerString(3), stdLength);
                                placeAsset(lastPos[0] + 1, lastPos[1] + 1, "genYPath", stdLength);
                                lastPos[0] = lastPos[0] + 1;
                                lastPos[1] = lastPos[1] + 1;
                                return nextDirAndCorner[0];
                            }
                            else
                            {
                                return lastDirection;
                                // quadrants are occupied
                            }
                        }
                        else
                        {
                            return lastDirection;
                            // item is out of range
                        }
                    }
                    // maybe need to add case for lastdir and next dir being the same
                    else if (lastDirection == 4)
                    {
                        if (lastPos[0] < 3 && lastPos[1] < 9)
                        {
                            if (middlePoints[lastPos[0] + 1][lastPos[1], 0] == 0 && middlePoints[lastPos[0] + 2][lastPos[1],0] == 0)
                            {
                                placeAsset(lastPos[0] + 1, lastPos[1], "genYPath", stdLength);
                                lastPos[0] = lastPos[0] + 1;
                                return nextDirAndCorner[0];
                            }
                            else
                            {
                                // quadrant is occupied
                                return lastDirection;
                            }
                        }
                        else
                        {
                            return lastDirection;
                            // Next Pos is out of range
                        }

                    }
                    else
                    {
                        return lastDirection;
                    }

            }


            return lastDirection;
            // must return last written non rel dir
            
        }

        private static string getCornerString (int cornerValue)
        {
            switch (cornerValue) {
                case 1:
                    return "genCornerLeftAndTop";
                case 2:
                    return "genCornerRightAndTop";
                case 3:
                    return "genCornerLeftAndBottom";
                case 4:
                    return "genCornerRightAndBottom";
            }
            return "Switch case wasn't triggered";

        }

        private static int[] getDirectionByRelativeDirection(int nextDirection, int lastDirection)
        {
            // if not all code paths return values check the defaul option on the switch case
            // might need to extend array by one more el to know if down or up
            int[] dirAndCorner = new int[2];
            if(nextDirection == 3)
            {
                dirAndCorner[0] = lastDirection;
                dirAndCorner[1] = 0;
                return dirAndCorner;

            }
            else
            {
                switch (lastDirection)
                {
                    case 1:
                        switch (nextDirection)
                        {
                            case 1:
                                dirAndCorner[0] = 4;
                                dirAndCorner[1] = 4;
                                return dirAndCorner;
                            case 2:
                                dirAndCorner[0] = 3;
                                dirAndCorner[1] = 2;
                                return dirAndCorner;
                        }
                        break;
                    case 2:
                        switch (nextDirection)
                        {
                            case 1:
                                dirAndCorner[0] = 3;
                                dirAndCorner[1] = 1;
                                return dirAndCorner;
                            case 2:
                                dirAndCorner[0] = 4;
                                dirAndCorner[1] = 3;
                                return dirAndCorner;
                        }
                        break;
                    case 3:
                        switch (nextDirection)
                        {
                            case 1:
                                dirAndCorner[0] = 1;
                                dirAndCorner[1] = 3;
                                return dirAndCorner;
                            case 2:
                                dirAndCorner[0] = 2;
                                dirAndCorner[1] = 4;
                                return dirAndCorner;
                        }
                        break;
                    case 4:
                        // might need to extend array by one more element to know if down or up
                        switch (nextDirection)
                        {
                            case 1:
                                dirAndCorner[0] = 2;
                                dirAndCorner[1] = 2;
                                return dirAndCorner;
                            case 2:
                                dirAndCorner[0] = 1;
                                dirAndCorner[1] = 1;
                                return dirAndCorner;
                        }
                        break;

                }
            }
            return dirAndCorner;
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
