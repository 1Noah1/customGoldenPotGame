using System;
namespace customGoldenPotGame
{
    internal class Program { 

        static void Main(string[] args)
        {
            /*
            Menu menu = new Menu();
            menu.startMenu();
            */
            bool exit = false;
            GameManager gameManager = new();
            Map map = new();
            Player Player = new();
            Maze maze = new();
            Item Item = new();

            map.renderMap();
            //Item.renderItem();
            //maze.genMaze();

            Maze.testAssets();
            Console.ReadKey();

            bool failed = false;
            /*while (!failed)
            {
               Player.movePlayerToNextPos();
               Player.movement();
               //Item.renderItem();
               GameManager.detectItem();
            }*/
        }
    }
}
