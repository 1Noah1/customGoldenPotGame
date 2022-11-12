using System.Security.Cryptography;

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
            GameManager gameManager = new GameManager();
            Map map = new();
            Player Player = new();
            Item Item = new();
            while (!exit)
            {
                map.renderMap();
                //main Character is standard Character
                bool failed = false;
                while (!failed)
                {
                    Player.movePlayerToNextPos();
                    Player.movement();
                    Item.renderItem();
                }
            }
        }
    }
}
