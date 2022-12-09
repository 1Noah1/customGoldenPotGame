using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace customGoldenPotGame
{
    internal class Gen2Assets
    {
        internal const char verLine = '|';
        internal const char horiBoxLine = '_';
        internal const char horiPathLine = '-';
        internal const char tiltToRightLine = '/';
        internal const char tiltToLeftLine = '\\';


        public static void genXLine(int length)
        {
            // default from left to Right
            //use Offset if right to left is needed
            //end Point is same as the last written char ( the one all the way to the right ) 
            
            for (int i = 0; i <= length - 1; i++)
            {
                Console.Write(horiPathLine);
            }
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);



        }
        public static void genXPath(int length)
        {
            //defaul from left to Right
            // Use Offset if right to left is needed Offset should never be needed because next asset isn't dependend on the one before
            // top line is written first
            // end Point is same as the last written char (default: bottom right)

            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop - 1);
            genXLine(length);
            Console.SetCursorPosition(Console.CursorLeft - (length -1), Console.CursorTop + 2);
            genXLine(length);

        }


        public void genYLine(int length)
        {
            // last Cursor Pos should be highest point ( last line if you count from bottom to top)
            // is written from bottom to top

            for (int i = 0; i <= length - 1; i++)
            {
                Console.Write(verLine);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
            }
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);

        }


    }
}
