using System.Security.Cryptography;

namespace customGoldenPotGame
{
    internal class Program
    {
        public class Map
        {
            public int Width { get; set; }
            public int Height { get; set; }
            private int padding { get; set; }

            public Map()
            {
                // values aren't declared in renderCanvas because we need to acces these vals from other functions
                Width = 60;
                Height = 30;
                padding = 12;

                Console.CursorVisible = false;
            }

            public void renderMap()
            {
                Console.Clear();
                Console.WindowHeight = Height + padding / 2;
                Console.WindowWidth = Width + padding;
                // top
                for (int i = 1; i < Width; i++)
                {
                    Console.SetCursorPosition(padding / 2 + i, padding / 4);
                    Console.Write("_");

                }
                // bottom
                for (int i = 0; i <= Width; i++)
                {
                    Console.SetCursorPosition(padding / 2 + i, Height + padding / 4);
                    Console.Write("_");
                }
                // left
                for (int i = 1; i <= Height; i++)
                {
                    Console.SetCursorPosition(padding / 2, i + padding / 4);
                    Console.Write("|");
                }
                // right
                for (int i = 1; i <= Height; i++)
                {
                    Console.SetCursorPosition(Width + padding / 2, i + padding / 4);
                    Console.Write("|");
                }
            }
        }

        public class Playable
        {

            bool overwriteLastPos = true;



            // read char input properly
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();

            //array for saving Playable pos
            public int[] mainPlayablePos = new int[2];
            public int[] mainPlayablePosHistory = new int[2];
            // Use Width and height from map instead
            public int[] boundaries = new int[4];


            public int x { get; set; }
            public int y { get; set; }

            public Playable()
            {
                // main Playable start Pos
                x = 30;
                y = 18;

                mainPlayablePos[0] = x;
                mainPlayablePos[1] = y;

                // these values should not have individual ints
                // they should just reference the Widht and Height vars from the Map class
                // maybe order these values differently (by wasd system) 
                //border right
                boundaries[0] = 65;
                //border left
                boundaries[1] = 7;
                //border bottom
                boundaries[2] = 32;
                //border top
                boundaries[3] = 4;
            }
            public void initializeCharacter()
            {
                // Set Cursor to next Pos 
                Console.SetCursorPosition(mainPlayablePos[0], mainPlayablePos[1]);
                // maybe make character out of multiple lines of chars
                // Character Symbol
                // the @ character causes weird bug to appear idk why
                Console.Write("0");

                if (overwriteLastPos) {
                    removeTrail();
                }



            }
            private void removeTrail()
            {
                // Set Cursor to last Pos
                Console.SetCursorPosition(mainPlayablePosHistory[0], mainPlayablePosHistory[1]);

                // erase line by overwriting it with empty character
                Console.Write(" ");
            }

            public void movement()
            {
                // gets user Input 
                keyInfo = Console.ReadKey(true);
                char inputKey = keyInfo.KeyChar;

                // neccessary to remove trail
                mainPlayablePosHistory[0] = mainPlayablePos[0];
                mainPlayablePosHistory[1] = mainPlayablePos[1];
                if (inputKey == 'w')
                {
                    //up
                    // check for avoiding going out of bounds
                    // not the smartest solution but it works (optimize)
                    // flickering appears because trail is removed while not changing position
                    //on key hold char dissapears until you move the opposite direction
                    if (mainPlayablePos[1] > boundaries[3])
                    {
                        mainPlayablePos[1]--;
                        overwriteLastPos = true;
                    }
                    else
                    {
                        overwriteLastPos = false;
                    }
                }
                else if (inputKey == 'a')
                {
                    //left
                    if (mainPlayablePos[0] > boundaries[1])
                    {
                        mainPlayablePos[0]--;
                        overwriteLastPos = true;
                    }
                    else
                    {
                        overwriteLastPos = false;
                    }
                }
                else if (inputKey == 's')
                {
                    //down
                    if (mainPlayablePos[1] < boundaries[2])
                    {
                        mainPlayablePos[1]++;
                        overwriteLastPos = true;
                    }
                    else
                    {
                        overwriteLastPos = false;
                    }
                }
                else if (inputKey == 'd')
                {
                    //right
                    if (mainPlayablePos[0] < boundaries[0])
                    {
                        mainPlayablePos[0]++;
                        overwriteLastPos = true;
                    }
                    else
                    {
                        overwriteLastPos = false;
                    }
                }
                else
                {
                    // character is not overwritten when unknown key is pressed
                    overwriteLastPos = false;
                }

            }
        }

        public class Menu
        {

            public void startMenu()
            {
                string divider = "___________________________________________________";
                Console.WriteLine("Welcome to my Game!");
                Thread.Sleep(1000);
                Console.WriteLine("Your task is collecting all the Items across the map");
                Thread.Sleep(1500);
                Console.WriteLine("Just move to the items ({collectable.})");
                Console.WriteLine(divider);
                Console.WriteLine("MOVEMENT:");
                Console.WriteLine("Move the Main Character (O) with the \"wasd\" Keys");
                Console.WriteLine("Move the Second Character (X) with the \"plöä\" Keys");
                Console.WriteLine(divider);
                Thread.Sleep(2500);
                Console.WriteLine();
                Console.WriteLine("Enjoy! :D");
                Console.WriteLine();
                Console.WriteLine("press any key to continue");
                Console.ReadKey();

            }
        }

        static void Main(string[] args)
        {
            /*
            Menu menu = new Menu();
            menu.startMenu();
            */

            bool exit = false;
            Map map = new Map();
            Playable Playable = new Playable();
            //Playable Playable = new Playable();
            // decreased Bufferheight for performance
            //probably doesn't affect performace drastically
            Console.BufferHeight = 50;
            while (!exit)
            {
                map.renderMap();
                //main Character is standard Character
                bool failed = false;
                while (!failed)
                {
                    Playable.initializeCharacter();
                    Playable.movement();
                }
                //for debugging/development
                //Thread.Sleep(20000);     
            }
        }
    }
}