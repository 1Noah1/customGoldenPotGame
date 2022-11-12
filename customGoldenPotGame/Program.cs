using System.Security.Cryptography;

namespace customGoldenPotGame
{
    internal class Program
    {


        public class GameManager
        {
            public static int Width { get; set; }
            public static int Height { get; set; }

            public GameManager(){
                // values aren't declared in renderCanvas because we need to acces these vals from other functions
                Width = 60;
                Height = 30;
            }
        }

        public class Map
        {

            private int padding { get; set; }

            public  Map()
            {

                padding = 12;

                Console.CursorVisible = false;
            }

            public void renderMap()
            {
                Console.Clear();
                // decreased Bufferheight for performance
                //probably doesn't affect performace drastically
                Console.BufferHeight = 50;
                Console.WindowHeight = GameManager.Height + padding / 2;
                Console.WindowWidth = GameManager.Width + padding;
                // top
                for (int i = 1; i < GameManager.Width; i++)
                {
                    Console.SetCursorPosition(padding / 2 + i, padding / 4);
                    Console.Write("_");
                }
                // bottom
                for (int i = 0; i <= GameManager.Width; i++)
                {
                    Console.SetCursorPosition(padding / 2 + i, GameManager.Height + padding / 4);
                    Console.Write("_");
                }
                // left
                for (int i = 1; i <= GameManager.Height; i++)
                {
                    Console.SetCursorPosition(padding / 2, i + padding / 4);
                    Console.Write("|");
                }
                // right
                for (int i = 1; i <= GameManager.Height; i++)
                {
                    Console.SetCursorPosition(GameManager.Width + padding / 2, i + padding / 4);
                    Console.Write("|");
                }
            }
        }
        public class Item
        {
            Random random = new();
            public char item = 'I';
            public int[] itemPos = new int[2];
            public Item()
            {
                //x
                itemPos[0] = random.Next(7, 65);
                //y
                itemPos[1] = random.Next(4, 32);
            }
            public void renderItem()
            {
                Console.SetCursorPosition(itemPos[0], itemPos[1]);
                Console.Write(item);
            }
        }

        public class Player
        {
            bool overwriteLastPos = true;

            // read char input properly
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();

            //array for saving Player pos
            public int[] mainPlayerPos = new int[2];
            public int[] mainPlayerPosHistory = new int[2];
            // Use Width and height from map instead
            private int[] boundaries = new int[4];
            private char playerCharacter = Convert.ToChar("0");

            public int x { get; set; }
            public int y { get; set; }

            public Player()
            {
                // main Player start Pos
                x = 30;
                y = 18;

                mainPlayerPos[0] = x;
                mainPlayerPos[1] = y;

                // these values should not have individual ints
                // they should just reference the Widht and Height vars from the Map class
                // maybe order these values differently (by wasd system) 

                //border right
                boundaries[0] = GameManager.Width + 5;
                //border left
                boundaries[1] = 7;
                //border bottom
                boundaries[2] = GameManager.Height + 2;
                //border top
                boundaries[3] = 4;
            }
            public void initializeCharacter()
            {
                // Set Cursor to next Pos 
                Console.SetCursorPosition(mainPlayerPos[0], mainPlayerPos[1]);
                // maybe make character out of multiple lines of chars
                // Character Symbol
                // the @ character causes weird bug to appear idk why
                Console.Write(playerCharacter);

                if (overwriteLastPos) {
                    removeTrail();
                }
            }
            private void removeTrail()
            {
                // Set Cursor to last Pos
                Console.SetCursorPosition(mainPlayerPosHistory[0], mainPlayerPosHistory[1]);

                // erase line by overwriting it with empty character
                Console.Write(" ");
            }

            public void movement()
            {
                // gets user Input 
                keyInfo = Console.ReadKey(true);
                char inputKey = keyInfo.KeyChar;

                // neccessary to remove trail
                mainPlayerPosHistory[0] = mainPlayerPos[0];
                mainPlayerPosHistory[1] = mainPlayerPos[1];
                if (inputKey == 'w')
                {
                    //up
                    // check for avoiding going out of bounds
                    // not the smartest solution but it works (optimize)
                    // flickering appears because trail is removed while not changing position
                    //on key hold char dissapears until you move the opposite direction
                    if (mainPlayerPos[1] > boundaries[3])
                    {
                        mainPlayerPos[1]--;
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
                    if (mainPlayerPos[0] > boundaries[1])
                    {
                        mainPlayerPos[0]--;
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
                    if (mainPlayerPos[1] < boundaries[2])
                    {
                        mainPlayerPos[1]++;
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
                    if (mainPlayerPos[0] < boundaries[0])
                    {
                        mainPlayerPos[0]++;
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
                Console.WriteLine("Just move to the items (item var)");
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
            GameManager gameManager = new GameManager();
            Map map = new();
            Player Player = new();
            while (!exit)
            {
                map.renderMap();
                //main Character is standard Character
                bool failed = false;
                while (!failed)
                {
                    Player.initializeCharacter();
                    Player.movement();
                }
            }
        }
    }
}