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

        public class Playables {

            // read char input properly
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();

            //array for saving Playables pos
            public int[] mainPlayablePos = new int[2];
            public int[] secondPlayablePos = new int[2];
            public int[] mainPlayablePosHistory = new int[2];

            // Use Width and height from map instead
            public int[] boundaries = new int[4];

            
            public int x { get; set; }
            public int y { get; set; }

            public Playables()
            {
                // main Playable start Pos
                x = 30;
                y = 18;

                mainPlayablePos[0] = x;
                mainPlayablePos[1] = y;

                secondPlayablePos[0] = x;
                // second Player offset is 20
                secondPlayablePos[1] = y + 20;

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
            public void initializePlayables(bool mainPlayable)
            {
                bool outOfBounds = false;
                if (mainPlayable)
                {
                    // Cursor set to modified Pos
                    if (mainPlayablePos[0] > boundaries[0] || mainPlayablePos[0] < boundaries[1])
                    {
                        outOfBounds = true;
                    }else if (mainPlayablePos[1] > boundaries[2] || mainPlayablePos[1] < boundaries[3])
                    {
                        outOfBounds = true;

                    }
                    if (!outOfBounds)
                    {
                        // Set Cursor to next Pos 
                        Console.SetCursorPosition(mainPlayablePos[0], mainPlayablePos[1]);
                        // maybe make character out of multiple lines of chars
                        // Character Symbol
                        // main playable
                        Console.Write("O");

                        // Set Cursor to last Pos
                        Console.SetCursorPosition(mainPlayablePosHistory[0], mainPlayablePosHistory[1]);

                        // erase line by overwriting it with empty character
                        Console.Write(" ");


                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(30, 18);
                        Console.Write("You left the PLayground");
                    }


                }
                else
                {
                    // Cursor set to modified Pos
                    Console.SetCursorPosition(secondPlayablePos[0], secondPlayablePos[1]);

                    // maybe make character out of multiple lines of chars
                    // Character Symbol
                    // second playable
                    Console.Write("X");
                    //Console.Write('^');
                }
 
            }
            public void whichPlayable()
            {
                if (Console.KeyAvailable)
                {
                    keyInfo = Console.ReadKey(true);
                    char inputKey = keyInfo.KeyChar;
                    if (inputKey == 'w' || inputKey == 'a' || inputKey == 's' || inputKey == 'd')
                    {
                        bool mainPlayable = true;
                        movement(mainPlayable, inputKey);
                    }else if (inputKey == 'p' || inputKey == 'l' || inputKey == 'ö' || inputKey == 'ä')
                    {
                        bool mainPlayable = false;
                        initializePlayables(mainPlayable);
                        movement(mainPlayable, inputKey);

                    }
                }
            }
            public void movement(bool mainPlayable, char inputKey )
            {
                if (mainPlayable)
                {
                    mainPlayablePosHistory[0] = mainPlayablePos[0];
                    mainPlayablePosHistory[1] = mainPlayablePos[1];

                    if(inputKey == 'w')
                    {
                        //up
                        // check for avoiding going out of bounds
                            // not the smartest solution but it works (optimize)
                        // flickering appears because trail is removed while not changing position
                            //on key hold char dissapears until you move the opposite direction
                        if (mainPlayablePos[1] > boundaries[3]) {
                            mainPlayablePos[1]--;
                        }

                    }else if (inputKey == 'a')
                    {
                        //left
                        if (mainPlayablePos[0] > boundaries[1])
                        {
                            mainPlayablePos[0]--;
                        }
                    }
                    else if (inputKey == 's')
                    {
                        //down
                        if (mainPlayablePos[1] < boundaries[2])
                        {
                            mainPlayablePos[1]++;
                        }
                    }else if (inputKey == 'd')
                    {
                       if (mainPlayablePos[0] < boundaries[0])
                       {
                            //right
                            mainPlayablePos[0]++;
                       }
                    }
                    Thread.Sleep(100);
                    
                }
                else
                {
                    if (inputKey == 'p')
                    {
                        //up
                        secondPlayablePos[1]++;
                    }
                    else if (inputKey == 'l')
                    {
                        //left
                        secondPlayablePos[0]--;
                    }
                    else if (inputKey == 'ö')
                    {
                        //down
                        secondPlayablePos[1]--;
                    }
                    else if (inputKey == 'ä')
                    {
                        //right
                        secondPlayablePos[0]++;
                    }
                    Thread.Sleep(100);

                }
            }
        }
        public class Menu
        {
            public Menu()
            {

            }

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
            Playables Playables = new Playables();
            //Playables Playables = new Playables();
            // decreased Bufferheight for performance
                //probably doesn't affect performace drastically
            Console.BufferHeight = 50;
            while (!exit)
            {
                map.renderMap();
                //main Character is standard Character
                bool mainPlayable = true;
                bool failed = false;
                while (!failed)
                {
                    Playables.initializePlayables(mainPlayable);
                    Playables.whichPlayable();
                }
                //for debugging/development
                //Thread.Sleep(20000);     
            }
        }
    }
}