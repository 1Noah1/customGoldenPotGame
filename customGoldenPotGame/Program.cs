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

            
            public int x { get; set; }
            public int y { get; set; }
            // second Playeable shouldn't start at the same position
            public int secondPlayableOffset = 10;

            public Playables()
            {
                // main Playable start Pos
                x = 30;
                y = 18;

                mainPlayablePos[0] = x;
                mainPlayablePos[1] = y;

                secondPlayablePos[0] = x;
                secondPlayablePos[1] = y;


            }
            public void initializePlayables(bool mainPlayable)
            {
                if (mainPlayable)
                {
                    // starting point
                    Console.SetCursorPosition(mainPlayablePos[0], mainPlayablePos[1]);

                    // maybe make character out of multiple lines of chars
                    // Character Symbol
                    // main playable
                    Console.Write("O");
                    //Console.Write('^');
                    whichPlayable();

                }
                else
                {
                    // starting point
                    Console.SetCursorPosition(mainPlayablePos[0], mainPlayablePos[1] + secondPlayableOffset);

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
                    if(inputKey == 'w')
                    {
                        //up
                        mainPlayablePos[1]--;
                    }else if (inputKey == 'a')
                    {
                        //left
                        mainPlayablePos[0]--;
                    }else if (inputKey == 's')
                    {
                        //down
                        mainPlayablePos[1]++;
                    }else if (inputKey == 'd')
                    {
                        //right
                        mainPlayablePos[0]++;
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
            Menu menu = new Menu();
            menu.startMenu();


            bool exit = false;
            Map map = new Map();
            Playables Playables = new Playables();
            //Playables Playables = new Playables();
            // decreased Bufferheight for performance
            Console.BufferHeight = 50;
            while (!exit)
            {
                map.renderMap();
                //main Character is standard Character
                bool mainPlayable = true;
                Playables.initializePlayables(mainPlayable);
                Playables.whichPlayable();
                //for debugging/development
                //Thread.Sleep(20000);     
            }
        }
    }
}