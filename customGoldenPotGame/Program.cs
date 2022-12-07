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
            

            if (gametype == 'S' || gametype == 's')
            {
                bool exit = false;
                Item Item = new();
            }
            else
            {
                menu.mazeMenu();
                Maze maze = new();
                while (true)
                {
                    maze.genMaze();
                    ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
                    if (keyInfo == ConsoleKey.Escape)
                    {
                        break;
                    }
                }

                //Console.ReadKey();
            }


            //map.renderMap();
            //Item.renderItem();
            
            //Maze.testAssets();
            

            bool failed = false;
            while (!failed)
            {
               Player.movePlayerToNextPos();
               Player.movement();
               //Item.renderItem();
               GameManager.detectItem();
            }
            
                map.renderMap();
                Item.renderItem();
                bool failed = false;
                while (!failed)
                {
                    Player.movePlayerToNextPos();
                    Player.movement();
                    Item.renderItem();
                    failed = GameManager.detectItem();
                }
              
        }
    }
}
