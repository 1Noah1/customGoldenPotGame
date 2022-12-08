using System;
namespace customGoldenPotGame
{
    internal class Program { 

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            
            Menu menu = new Menu();
            char gametype = menu.startMenu();

            GameManager gameManager = new();
            Map map = new();
            Player Player = new();

            bool regularGame;

            if (gametype == 'S' || gametype == 's')
            {
                regularGame = true;
                Item Item = new();
            }
            else
            {
                menu.mazeMenu();
                Maze maze = new();
                while (true)
                {
                    regularGame = false;
                    Console.Clear();
                    Console.BufferHeight = 300;
                    Console.WindowHeight = 50;
                    Console.WindowWidth = 100;
                    
                    ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
                    keyInfo = Console.ReadKey(true);
                    if (keyInfo.KeyChar == 'l' || keyInfo.KeyChar == 'L')
                    {
                        break;
                    }else if(keyInfo.KeyChar == 'n' || keyInfo.KeyChar == 'N')
                    {
                        maze.genMaze();
                        Console.ReadKey();
                    }
                }

                
            }
            
            if (regularGame)
            {
                map.renderMap();

                bool failed = false;
                while (!failed)
                {
                    Item.renderItem();
                    Player.movePlayerToNextPos();
                    Player.movement();
                    failed = GameManager.detectItem();
                }
                bool playAgain = Menu.renderFailscreen();
                

            }
              
        }
    }
}
